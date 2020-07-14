using JIMapTrans.Common;
using JIMapTrans.Logger;
using JIMapTrans.Process;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace JIMapTrans.Overview
{
    public partial class OverviewCreateControl : UserControl
    {
        private BackgroundWorker _overviewCreateWorker;

        private OverviewCreateOptionControl _overviewCreateOptionControl;
        private OverviewCreatePathSettingControl _overviewCreatePathSettingControl;
        private OverviewCreateInfo _overviewCreateInfo;
        private ProcessResultInfo _overviewCreateResultInfo;

        private Timer _progressTimer;
        private System.Diagnostics.Stopwatch _progressStopWatch;

        public delegate void OverviewCreateStartedEvent(object sender);
        public delegate void OverviewCreateStopedEvent(object sender);

        public event OverviewCreateStartedEvent CreateStarted;
        public event OverviewCreateStopedEvent CreateStoped;

        public OverviewCreateControl()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            InitOverviewCreateInfo();
            InitOverviewCreateResultInfo();
            InitControls();
            InitMapConvertWorker();
            InitTimer();
            InitStopWatch();
        }

        private void InitOverviewCreateInfo()
        {
            _overviewCreateInfo = new OverviewCreateInfo();
        }

        private void InitOverviewCreateResultInfo()
        {
            _overviewCreateResultInfo = new ProcessResultInfo("오버뷰 생성");
        }

        private void InitMapConvertWorker()
        {
            _overviewCreateWorker = new BackgroundWorker();
            _overviewCreateWorker.WorkerReportsProgress = true;
            _overviewCreateWorker.WorkerSupportsCancellation = true;

            _overviewCreateWorker.DoWork += OverviewCreateWorker_DoWork;
            _overviewCreateWorker.RunWorkerCompleted += OverviewCreateWorker_RunWorkerCompleted;
        }

        private void InitControls()
        {
            InitOverviewCreatePathSettingControl();
            InitOverviewCreateOptionControl();
            SetControlEnabled(false);
        }

        private void InitOverviewCreatePathSettingControl()
        {
            _overviewCreatePathSettingControl = new OverviewCreatePathSettingControl();
            groupBox1.Controls.Add(_overviewCreatePathSettingControl);
            _overviewCreatePathSettingControl.Dock = DockStyle.Fill;
        }

        private void InitOverviewCreateOptionControl()
        {
            _overviewCreateOptionControl = new OverviewCreateOptionControl();
            groupBox2.Controls.Add(_overviewCreateOptionControl);
            _overviewCreateOptionControl.Dock = DockStyle.Fill;
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

        private long CreateOverviews(BackgroundWorker worker, DoWorkEventArgs e)
        {
            long result = 0;

            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return result;
            }

            var pathInfo = _overviewCreateInfo.OverviewCreatePathInfo;
            var paths = pathInfo.InputPathList;
            int count = 0;
            int listCount = paths.Count;

            _overviewCreateResultInfo.InputFileCount = listCount;
            _overviewCreateResultInfo.OutputFileCount = listCount;

            LoggerManager.WriteInfoLog("오버뷰 생성 작업을 시작합니다.");
            LoggerManager.WriteDebugLog(LoggerManager.SubSeparatorString);

            CommonUtil.SetLabelText(this, label4, count + "/" + listCount);

            foreach (string inputFilePath in paths)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                count++;

                DateTime startTime = DateTime.Now;
                
                LoggerManager.WriteDebugLog(string.Format(" [{0}/{1}] 생성 시작", count, listCount));
                LoggerManager.WriteFileInfoLog(inputFilePath, "");
                
                bool isCreated = OverviewCreator.CreateOverviews(_overviewCreateInfo, inputFilePath, ProgressFunc);

                WriteResultLog(isCreated, count, startTime);

                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                CommonUtil.SetLabelText(this, label4, string.Format("{0}/{1}", count, listCount));
                CommonUtil.SetProgressBarValue(progressBar1, count);
            }

            return result;
        }

        private void WriteResultLog(bool isCreated, int count, DateTime startTime)
        {
            string resultString = "생성 성공";

            if (isCreated)
            {
                _overviewCreateResultInfo.SuccessCount++;
            }
            else
            {
                resultString = "생성 실패";
                _overviewCreateResultInfo.FailCount++;
            }

            string logString = string.Format(" [{0}/{1}] {2} - 소요 시간 : {3}", count, _overviewCreateResultInfo.InputFileCount, resultString, (DateTime.Now - startTime).ToString(@"hh\:mm\:ss\.ff"));

            logString += Environment.NewLine;
            logString += LoggerManager.SubSeparatorString;

            LoggerManager.WriteDebugLog(logString);
        }

        private void StartCreateOverview()
        {
            if (!SetOverviewCreateInfo())
            {
                MessageBox.Show("오버뷰 생성 정보가 올바르지 않습니다.", "오버뷰 생성", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _overviewCreateResultInfo.Clear();

            SetProgressControls();

            _overviewCreateWorker.RunWorkerAsync();

            SetControlEnabled(true);

            CreateStarted?.Invoke(this);
        }

        private void SetProgressControls()
        {
            CommonUtil.SetProgressBar(progressBar1, 0, _overviewCreateInfo.OverviewCreatePathInfo.InputPathList.Count, 1, 0);
            
            _overviewCreateResultInfo.StartTime = DateTime.Now;
            _progressStopWatch.Reset();
            _progressStopWatch.Start();
            _progressTimer.Start();
        }

        private void SetControlEnabled(bool isStarted)
        {
            _createOverviewButton.Enabled = !isStarted;
            _cancelCreateOverviewButton.Enabled = isStarted;
        }

        private DialogResult CancelCreateOverview()
        {
            DialogResult result = MessageBox.Show("오버뷰 생성작업이 진행중입니다. 취소하시겠습니까?"
                + Environment.NewLine + "**취소한 작업은 되돌릴 수 없습니다.**", "오버뷰 생성 취소",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return result;
            }

            if (_overviewCreateWorker.WorkerSupportsCancellation == true)
            {
                _overviewCreateWorker.CancelAsync();
            }

            return result;
        }

        private bool SetOverviewCreateInfo()
        {
            _overviewCreateInfo = new OverviewCreateInfo();

            _overviewCreateInfo = _overviewCreateOptionControl.GetOverviewCreateOptions();

            _overviewCreateInfo.OverviewCreatePathInfo = _overviewCreatePathSettingControl.GetOverviewCreatePathInfo();
            if (_overviewCreateInfo.OverviewCreatePathInfo.InputPathList.Count < 1)
            {
                return false;
            }
            
            if(!_overviewCreateInfo.IsNeedCalcLevel && _overviewCreateInfo.LevelList.Count < 1)
            {
                return false;
            }

            _overviewCreateOptionControl.SetOverviewProfileSetting();

            LoggerManager.WriteOverviewCreateInfoLog(_overviewCreateInfo);

            return true;
        }

        public int ProgressFunc(double Complete, IntPtr Message, IntPtr Data)
        {
            if (_overviewCreateWorker != null && _overviewCreateWorker.CancellationPending)
            {
                return 0;
            }

            int completedValue = Convert.ToInt32(Complete * 100);
            CommonUtil.SetLabelText(this, _progressStateLabel, string.Format("{0}% 완료", completedValue));
            CommonUtil.SetProgressBarValue(_progressBar, completedValue);

            return 1;
        }

        public DialogResult CancelCreateOverviewWorker()
        {
            return CancelCreateOverview();
        }

        public bool IsCreateOverviewWorkerBusy()
        {
            return _overviewCreateWorker.IsBusy;
        }

        private void _progressTimer_Tick(object sender, EventArgs e)
        {
            _timerLabel.Text = _progressStopWatch.Elapsed.ToString(@"hh\:mm\:ss\.ff");
        }

        private void OverviewCreateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _overviewCreateResultInfo.EndTime = DateTime.Now;

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

            LoggerManager.WriteProcessResultInfoLog(_overviewCreateResultInfo);

            CreateStoped?.Invoke(this);
        }

        private void OverviewCreateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            e.Result = CreateOverviews(worker, e);
        }

        private void _createOverviewButton_Click(object sender, EventArgs e)
        {
            if (_overviewCreateWorker.IsBusy == true)
            {
                return;
            }

            StartCreateOverview();
        }

        private void _cancelCreateOverviewButton_Click(object sender, EventArgs e)
        {
            CancelCreateOverview();
        }

    }
}
