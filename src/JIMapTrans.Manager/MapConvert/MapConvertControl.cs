using JIMapTrans.Common.Infos;
using JIMapTrans.Common.Utils;
using JIMapTrans.Logger;
using JIMapTrans.Process;
using OSGeo.GDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace JIMapTrans.MapConvert
{
    public partial class MapConvertControl : UserControl
    {
        private BackgroundWorker _mapConvertWorker;
        private MapConvertOptionControl _mapConvertOptionControl;
        private MapConvertPathSettingControl _mapConvertPathSettingControl;

        private MapConvertInfo _mapConvertInfo;
        private ProcessResultInfo _mapConvertResultInfo;

        private Timer _progressTimer;
        private System.Diagnostics.Stopwatch _progressStopWatch;

        public delegate void MapConvertStartedEvent(object sender);
        public delegate void MapConvertStopedEvent(object sender);

        public event MapConvertStartedEvent ConvertStarted;
        public event MapConvertStopedEvent ConvertStoped;


        public MapConvertControl()
        {
            InitializeComponent();
            Initialize();           
        }

        private void Initialize()
        {
            InitDataSources();
            InitMapConvertInfo();
            InitMapConvertResultInfo();
            InitControls();
            InitBackgroundWorker();
            InitTimer();
            InitStopWatch();
        }

        private void InitDataSources()
        {
            MapConvertDataSource.Initialize();
        }

        private void InitBackgroundWorker()
        {
            _mapConvertWorker = new BackgroundWorker();
            _mapConvertWorker.WorkerReportsProgress = true;
            _mapConvertWorker.WorkerSupportsCancellation = true;

            _mapConvertWorker.DoWork += MapConvertWorker_DoWork;
            _mapConvertWorker.RunWorkerCompleted += MapConvertWorker_RunWorkerCompleted;
        }

        private void InitMapConvertInfo()
        {
            _mapConvertInfo = new MapConvertInfo();
        }

        private void InitMapConvertResultInfo()
        {
            _mapConvertResultInfo = new ProcessResultInfo("변환");
        }

        private void InitControls()
        {            
            InitMapConvertOptionControl();
            InitMapConvertPathSettingControl();
            SetControlEnabled(false);
        }

        private void InitMapConvertPathSettingControl()
        {
            _mapConvertPathSettingControl = new MapConvertPathSettingControl();
            groupBox1.Controls.Add(_mapConvertPathSettingControl);
            _mapConvertPathSettingControl.Dock = DockStyle.Fill;
        }

        private void InitMapConvertOptionControl()
        {
            _mapConvertOptionControl = new MapConvertOptionControl();
            groupBox2.Controls.Add(_mapConvertOptionControl);
            _mapConvertOptionControl.Dock = DockStyle.Fill;
        }

        private void InitTimer()
        {
            _progressTimer = new Timer
            {
                Interval = 10
            };
            _progressTimer.Tick += _progressTimer_Tick;
        }

        private void InitStopWatch()
        {
            _progressStopWatch = new System.Diagnostics.Stopwatch();
        }

        private long ConvertMap(BackgroundWorker worker, DoWorkEventArgs e)
        {
            long result = 0;

            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return result;
            }

            int count = 0;
            var pathInfo = _mapConvertInfo.MapConvertPathInfo;
            var inputPaths = pathInfo.InputPathList;
            int listCount = inputPaths.Count;

            _mapConvertResultInfo.InputFileCount = listCount;
            _mapConvertResultInfo.OutputFileCount = listCount;
            
            LoggerManager.WriteInfoLog("변환 작업을 시작합니다.");
            LoggerManager.WriteDebugLog(LoggerManager.SubSeparatorString);

            _mapConvertResultInfo.StartTime = DateTime.Now;

            ControlsUtil.SetLabelText(this, label4, string.Format("{0}/{1}", count, listCount));

            var size = Gdal.GetConfigOption("GDAL_SWATH_SIZE", "");
            var size1 = Gdal.GetConfigOption("GDAL_CACHEMAX", "");

            foreach (string inputFilePath in inputPaths)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                string outputFilePath = "";

                if (pathInfo.SelectedPathType == PathType.FilePathType)
                {
                    outputFilePath = pathInfo.OutputPathString;
                }
                else
                {
                    string ext = Path.GetExtension(inputFilePath);
                    outputFilePath = inputFilePath.Replace(ext, ".tif").Replace(pathInfo.InputPathString, pathInfo.OutputPathString);
                }

                FileSystemUtil.CreateDirectoryByFilePath(outputFilePath);

                count++;
                
                DateTime startTime = DateTime.Now;

                string logString = string.Format(" [{0}/{1}]변환 시작", count, listCount);

                LoggerManager.WriteDebugLog(logString);
                LoggerManager.WriteFileInfoLog(inputFilePath, outputFilePath);

                bool isConverted = MapConverter.EcwToTiff(inputFilePath, outputFilePath, _mapConvertInfo.GdalTranslateOptions
                    , new Gdal.GDALProgressFuncDelegate(ProgressFunc));

                WriteResultLog(isConverted, count, startTime);

                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                ControlsUtil.SetLabelText(this, label4, string.Format("{0}/{1}", count, listCount));
                ControlsUtil.SetProgressBarValue(progressBar1, count);
            }

            return result;
        }

        private void WriteResultLog(bool isConverted, int count, DateTime startTime)
        {
            string resultString = "변환 성공";

            if (isConverted)
            {
                _mapConvertResultInfo.SuccessCount++;
            }
            else
            {
                resultString = "변환 실패";
                _mapConvertResultInfo.FailCount++;
            }

            string logString = string.Format(" [{0}/{1}]{2} - 소요 시간 : {3}", count, 
                _mapConvertResultInfo.InputFileCount, resultString, (DateTime.Now - startTime).ToString(@"hh\:mm\:ss\.ff"));

            logString += Environment.NewLine;
            logString += LoggerManager.SubSeparatorString;
            LoggerManager.WriteDebugLog(logString);
        }

        private GDALTranslateOptions CreateGdalTransOptions(string[] options)
        {
            GDALTranslateOptions transOptions = null;

            try
            {
                transOptions = new GDALTranslateOptions(options);
            }
            catch(Exception ex)
            {
                string errorMsg = "변환 옵션 정보를 확인해주세요.";
                errorMsg += Environment.NewLine;
                errorMsg += ex.Message;

                MessageBox.Show(errorMsg, "변환 옵션 설정", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return transOptions;
        }

        private bool SetMapConvertInfo()
        {
            _mapConvertInfo = new MapConvertInfo();

            PathInfo pathInfo = _mapConvertPathSettingControl.GetMapConvertPathInfo();

            if (pathInfo.InputPathList.Count < 1)
            {
                MessageBox.Show("변환 경로 정보를 확인해주세요.", "변환", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(pathInfo.OutputPathString.Length < 1)
            {
                MessageBox.Show("변환 경로 정보를 확인해주세요.", "변환", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            _mapConvertInfo.MapConvertPathInfo = pathInfo;

            List<string> convertOptions = _mapConvertOptionControl.GetMapConvertOptions();
            GDALTranslateOptions translateOptions = CreateGdalTransOptions(convertOptions.ToArray());

            if(translateOptions == null)
            {                
                return false;
            }

            _mapConvertInfo.ConvertOptions = convertOptions;
            _mapConvertInfo.GdalTranslateOptions = translateOptions;

            WriteInfoLog(_mapConvertInfo);
            //LoggerManager.WriteMapConvertInfoLog(_mapConvertInfo);

            return true;
        }

        private void WriteInfoLog(MapConvertInfo mapConvertInfo)
        {
            string logString = "";
            logString += LoggerManager.MainSeparatorString;
            logString += Environment.NewLine;
            logString += "[변환 정보]";
            logString += Environment.NewLine;
            logString += string.Format(" 경로 유형 : {0}", ControlsUtil.GetEnumDescription(mapConvertInfo.MapConvertPathInfo.SelectedPathType));
            logString += Environment.NewLine;

            if (mapConvertInfo.MapConvertPathInfo.SelectedPathType == PathType.DirectoryPathType)
            {
                logString += string.Format(" 선택 확장자 : {0}", mapConvertInfo.MapConvertPathInfo.InputExtensions);
                logString += Environment.NewLine;
                logString += string.Format(" 입력 파일 개수 : {0}", mapConvertInfo.MapConvertPathInfo.InputPathList.Count);
                logString += Environment.NewLine;
            }

            logString += string.Format(" 입력 경로 : {0}", mapConvertInfo.MapConvertPathInfo.InputPathString);
            logString += Environment.NewLine;
            logString += string.Format(" 출력 경로 : {0}", mapConvertInfo.MapConvertPathInfo.OutputPathString);
            logString += Environment.NewLine;

            string optionsString = string.Join(" ", mapConvertInfo.ConvertOptions.ToArray());

            if (optionsString.Length < 1)
            {
                logString += string.Format(" 입력 옵션 : {0}", "없음");
            }
            else
            {
                logString += string.Format(" 입력 옵션 : {0}", optionsString);
            }

            logString += Environment.NewLine;
            logString += LoggerManager.MainSeparatorString;

            LoggerManager.WriteInfoLog(logString);
        }

        private void SetProgressControls()
        {
            ControlsUtil.SetProgressBar(progressBar1, 0, _mapConvertInfo.MapConvertPathInfo.InputPathList.Count, 1, 0);
            
            _progressStopWatch.Reset();
            _progressStopWatch.Start();
            _progressTimer.Start();
        }

        private void StartConvert()
        {
            if (_mapConvertWorker.IsBusy)
            {
                return;
            }

            if (!SetMapConvertInfo())
            {
                return;
            }

            _mapConvertResultInfo.Clear();

            SetProgressControls();

            _mapConvertWorker.RunWorkerAsync();

            SetControlEnabled(true);

            ConvertStarted?.Invoke(this);
        }
        
        private void StopConvert(RunWorkerCompletedEventArgs e)
        {
            _mapConvertResultInfo.EndTime = DateTime.Now;

            _progressTimer.Stop();
            _progressStopWatch.Stop();

            SetControlEnabled(false);

            if (e.Error != null)
            {
                LoggerManager.WriteErrorLog(e.Error.Message);
            }

            if (e.Cancelled)
            {
                LoggerManager.WriteInfoLog("작업이 취소되었습니다.");
            }
            else
            {
                LoggerManager.WriteInfoLog("작업이 완료되었습니다.");
            }

            ProcessManager.Instance.WriteProcessLog(_mapConvertResultInfo);

            ConvertStoped?.Invoke(this);
        }

        private void SetControlEnabled(bool isStarted)
        {           
            _convertButton.Enabled = !isStarted;
            _cancelConvertButton.Enabled = isStarted;
        }

        private DialogResult CancelConvert()
        {
            DialogResult result = MessageBox.Show("변환 작업이 진행중입니다. 취소하시겠습니까?"
                +  Environment.NewLine + "**취소한 작업은 되돌릴 수 없습니다.**", "변환 취소",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return result;
            }

            if (_mapConvertWorker.WorkerSupportsCancellation == true)
            {
                _mapConvertWorker.CancelAsync();
            }

            return result;
        }
        public int ProgressFunc(double complete, IntPtr message, IntPtr data)
        {
            if (_mapConvertWorker != null && _mapConvertWorker.CancellationPending)
            {
                return 0;
            }

            int completedValue = Convert.ToInt32(complete * 100);

            ControlsUtil.SetLabelText(this, _progressStateLabel, string.Format("{0}% 완료", completedValue));
            ControlsUtil.SetProgressBarValue(_progressBar, completedValue);

            return 1;
        }

        public bool IsMapConvertWorkerBusy()
        {
            return _mapConvertWorker.IsBusy;
        }

        public DialogResult CancelMapConvertWorker()
        {
            return CancelConvert();
        }

        private void _progressTimer_Tick(object sender, EventArgs e)
        {
            _timerLabel.Text = _progressStopWatch.Elapsed.ToString(@"hh\:mm\:ss\.ff");
        }

        private void MapConvertWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StopConvert(e);
        }

        private void MapConvertWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            e.Result = ConvertMap(worker, e);
        }

        private void _convertButton_Click(object sender, EventArgs e)
        {
            StartConvert();
        }

        private void _cancelConvertButton_Click(object sender, EventArgs e)
        {
            CancelConvert();
        }
    }
}
