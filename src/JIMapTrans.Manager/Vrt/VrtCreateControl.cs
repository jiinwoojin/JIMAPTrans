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

namespace JIMapTrans.Vrt
{
    public partial class VrtCreateControl : UserControl
    {
        private BackgroundWorker _vrtCreateWorker;
        private VrtCreateInfo _vrtCreateInfo;
        private VrtCreatePathSettingControl _vrtCreatePathSettingControl;
        private VrtCreateOptionControl _vrtCreateOptionControl;

        private ProcessResultInfo _vrtCreateResultInfo;

        private Timer _progressTimer;
        private System.Diagnostics.Stopwatch _progressStopWatch;

        public delegate void VrtCreateStartedEvent(object sender);
        public delegate void VrtCreateStopedEvent(object sender);

        public event VrtCreateStartedEvent CreateStarted;
        public event VrtCreateStopedEvent CreateStoped;

        public VrtCreateControl()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            InitVrtCreateResultInfo();
            InitControls();
            InitBackgroundWorker();
            InitTimer();
            InitStopWatch();
        }

        private void InitControls()
        {
            InitVrtCreatePathSettingControl();
            InitVrtCreateOptionControl();
            SetControlEnabled(false);
        }

        private void InitVrtCreateOptionControl()
        {
            _vrtCreateOptionControl = new VrtCreateOptionControl();
            groupBox2.Controls.Add(_vrtCreateOptionControl);
            _vrtCreateOptionControl.Dock = DockStyle.Fill;
        }

        private void InitBackgroundWorker()
        {
            _vrtCreateWorker = new BackgroundWorker();
            _vrtCreateWorker.WorkerReportsProgress = true;
            _vrtCreateWorker.WorkerSupportsCancellation = true;

            _vrtCreateWorker.DoWork += _vrtCreateWorker_DoWork;
            _vrtCreateWorker.RunWorkerCompleted += _vrtCreateWorker_RunWorkerCompleted;
        }

        private void InitVrtCreateResultInfo()
        {
            _vrtCreateResultInfo = new ProcessResultInfo("VRT 생성");
        }

        private void _vrtCreateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StopCreate(e);
        }

        private void _vrtCreateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            e.Result = CreateVrt(worker, e);
        }

        private bool SetVrtCreateInfo()
        {
            _vrtCreateInfo = new VrtCreateInfo();

            PathInfo pathInfo = _vrtCreatePathSettingControl.GetVrtCreatePathInfo();

            if (pathInfo.InputPathList.Count < 1)
            {
                MessageBox.Show("변환 경로 정보를 확인해주세요.", "변환", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (pathInfo.OutputPathString.Length < 1)
            {
                MessageBox.Show("변환 경로 정보를 확인해주세요.", "변환", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            _vrtCreateInfo.VrtCreatePathInfo = pathInfo;

            List<string> options = _vrtCreateOptionControl.GetVrtCreateOptions();
            GDALBuildVRTOptions buildVrtOptions = CreateGdalBuildVrtOptions(options.ToArray());

            if(buildVrtOptions == null)
            {
                return false;
            }

            _vrtCreateInfo.CreateOptions = options;
            _vrtCreateInfo.BuildVrtOptions = buildVrtOptions;

            string outputDirectory = Path.GetDirectoryName(pathInfo.OutputPathString);

            DirectoryInfo di = new DirectoryInfo(outputDirectory);

            if(!di.Exists)
            {
                di.Create();
                //Directory.CreateDirectory(outputDirectory);
            }

            WriteInfoLog(_vrtCreateInfo);

            return true;
        }

        private void WriteInfoLog(VrtCreateInfo info)
        {
            string logString = "";
            logString += LoggerManager.MainSeparatorString;
            logString += Environment.NewLine;
            logString += "[VRT 생성 정보]";

            logString += Environment.NewLine;
            logString += string.Format(" 경로 유형 : {0}", ControlsUtil.GetEnumDescription(info.VrtCreatePathInfo.SelectedPathType));
            logString += Environment.NewLine;

            if (info.VrtCreatePathInfo.SelectedPathType == PathType.DirectoryPathType)
            {
                logString += string.Format(" 선택 확장자 : {0}", info.VrtCreatePathInfo.InputExtensions);
                logString += Environment.NewLine;
                logString += string.Format(" 입력 파일 개수 : {0}", info.VrtCreatePathInfo.InputPathList.Count);
                logString += Environment.NewLine;
            }

            logString += string.Format(" 입력 경로 : {0}", info.VrtCreatePathInfo.InputPathString);
            logString += Environment.NewLine;
            logString += string.Format(" 출력 경로 : {0}", info.VrtCreatePathInfo.OutputPathString);
            logString += Environment.NewLine;

            string optionsString = string.Join(" ", info.CreateOptions.ToArray());

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

        private GDALBuildVRTOptions CreateGdalBuildVrtOptions(string[] options)
        {
            GDALBuildVRTOptions buildVrtOptions = null;

            try
            {
                buildVrtOptions = new GDALBuildVRTOptions(options);
            }
            catch (Exception ex)
            {
                string errorMsg = "VRT 생성 옵션 정보를 확인해주세요.";
                errorMsg += Environment.NewLine;
                errorMsg += ex.Message;
                
                MessageBox.Show(errorMsg, "VRT 생성 옵션 설정", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return buildVrtOptions;
        }

        private long CreateVrt(BackgroundWorker worker, DoWorkEventArgs e)
        {
            long result = 0;

            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return result;
            }
            
            _vrtCreateResultInfo.InputFileCount = _vrtCreateInfo.VrtCreatePathInfo.InputPathList.Count;
            _vrtCreateResultInfo.OutputFileCount = 1;

            LoggerManager.WriteInfoLog("VRT 생성 작업을 시작합니다.");
            LoggerManager.WriteDebugLog(LoggerManager.SubSeparatorString);

            _vrtCreateResultInfo.StartTime = DateTime.Now;

            bool isCreated = VrtCreator.Create(_vrtCreateInfo.VrtCreatePathInfo.OutputPathString, _vrtCreateInfo.VrtCreatePathInfo.InputPathList.ToArray(),
                _vrtCreateInfo.BuildVrtOptions, new Gdal.GDALProgressFuncDelegate(ProgressFunc));

            if(isCreated)
            {
                ConvertUtf8Encoding(_vrtCreateInfo.VrtCreatePathInfo.OutputPathString);
            }
            
            WriteResultLog(isCreated);

            return result;
        }

        private void ConvertUtf8Encoding(string path)
        {
            if (!File.Exists(path))
            {
                return;
            }

            if (".vrt" != Path.GetExtension(path))
            {
                return;
            }

            EncodingUtil.SetFileEncodingToUtf8Bom(path);
        }

        private void WriteResultLog(bool isCreated)
        {
            string resultString = "생성 성공";

            if (isCreated)
            {
                _vrtCreateResultInfo.SuccessCount++;
            }
            else
            {
                resultString = "생성 실패";
                _vrtCreateResultInfo.FailCount++;
            }

            string logString = string.Format(" {0} - 소요 시간 : {1}", resultString, (DateTime.Now - _vrtCreateResultInfo.StartTime).ToString(@"hh\:mm\:ss\.ff"));

            logString += Environment.NewLine;
            logString += LoggerManager.SubSeparatorString;
            LoggerManager.WriteDebugLog(logString);
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
        
        public int ProgressFunc(double complete, IntPtr message, IntPtr data)
        {
            if (_vrtCreateWorker != null && _vrtCreateWorker.CancellationPending)
            {
                return 0;
            }

            int completedValue = Convert.ToInt32(complete * 100);

            ControlsUtil.SetLabelText(this, _progressStateLabel, string.Format("{0}% 완료", completedValue));
            ControlsUtil.SetProgressBarValue(_progressBar, completedValue);

            return 1;
        }

        private void InitVrtCreatePathSettingControl()
        {
            _vrtCreatePathSettingControl = new VrtCreatePathSettingControl();
            groupBox1.Controls.Add(_vrtCreatePathSettingControl);
            _vrtCreatePathSettingControl.Dock = DockStyle.Fill;
        }

        private void _progressTimer_Tick(object sender, EventArgs e)
        {
            _timerLabel.Text = _progressStopWatch.Elapsed.ToString(@"hh\:mm\:ss\.ff");
        }

        private void SetControlEnabled(bool isStarted)
        {
            _createButton.Enabled = !isStarted;
            _cancelConvertButton.Enabled = isStarted;
        }

        private void StartCreate()
        {
            if (_vrtCreateWorker.IsBusy)
            {
                return;
            }

            if (!SetVrtCreateInfo())
            {
                return;
            }

            _vrtCreateResultInfo.Clear();

            SetProgressControls();

            _vrtCreateWorker.RunWorkerAsync();
            
            SetControlEnabled(true);

            CreateStarted?.Invoke(this);
        }
        
        private void StopCreate(RunWorkerCompletedEventArgs e)
        {
            _vrtCreateResultInfo.EndTime = DateTime.Now;

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

            ProcessManager.Instance.WriteProcessLog(_vrtCreateResultInfo);

            CreateStoped?.Invoke(this);
        }

        private void SetProgressControls()
        {
            //CommonUtil.SetProgressBar(progressBar1, 0, _vrtCreateInfo.VrtCreatePathInfo.InputPathList.Count, 1, 0);

            _progressStopWatch.Reset();
            _progressStopWatch.Start();
            _progressTimer.Start();
        }

        private DialogResult CancelCreate()
        {
            DialogResult result = MessageBox.Show("VRT 생성 작업이 진행중입니다. 취소하시겠습니까?"
    + Environment.NewLine + "**취소한 작업은 되돌릴 수 없습니다.**", "VRT 생성 취소",
    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return result;
            }

            if (_vrtCreateWorker.WorkerSupportsCancellation == true)
            {
                _vrtCreateWorker.CancelAsync();
            }

            return result;
        }

        private void _createButton_Click(object sender, EventArgs e)
        {
            StartCreate();
        }

        private void _cancelConvertButton_Click(object sender, EventArgs e)
        {
            CancelCreate();
        }
    }
}
