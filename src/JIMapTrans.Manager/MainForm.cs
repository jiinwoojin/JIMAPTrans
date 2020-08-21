using JIMapTrans.DataUploader;
using JIMapTrans.GdalManager;
using JIMapTrans.Logger;
using JIMapTrans.MapConvert;
using JIMapTrans.Overview;
using JIMapTrans.Vrt;
using System;
using System.Windows.Forms;

namespace JIMapTrans
{
    public partial class MainForm : Form
    {
        private MapConvertControl _mapConvertControl;
        private OverviewCreateControl _overviewCreateControl;
        private VrtCreateControl _vrtCreateControl;
        private LoggerControl _loggerControl;
        private DataUpdateControl _dataUpdateControl;


        public MainForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            InitGdalConfigs();
            InitControls();
        }
        private void InitGdalConfigs()
        {
            GdalConfigManager.Initialize();
        }

        private void InitControls()
        {
            InitMapConvertControl();
            InitOverviewCreateControl();
            InitVrtCreateControl();
            InitLoggerControl();
            InitMapUpdateControl();
        }

        private void InitMapConvertControl()
        {
            _mapConvertControl = new MapConvertControl();
            tabPage1.Controls.Add(_mapConvertControl);
            _mapConvertControl.Dock = DockStyle.Fill;

            _mapConvertControl.ConvertStarted += _mapConvertControl_ConvertStarted;
            _mapConvertControl.ConvertStoped += _mapConvertControl_ConvertStoped;
        }

        private void InitOverviewCreateControl()
        {
            _overviewCreateControl = new OverviewCreateControl();
            tabPage2.Controls.Add(_overviewCreateControl);
            _overviewCreateControl.Dock = DockStyle.Fill;

            _overviewCreateControl.CreateStarted += _overviewCreateControl_CreateStarted;
            _overviewCreateControl.CreateStoped += _overviewCreateControl_CreateStoped;
        }

        private void InitVrtCreateControl()
        {
            _vrtCreateControl = new VrtCreateControl();
            tabPage3.Controls.Add(_vrtCreateControl);
            _vrtCreateControl.Dock = DockStyle.Fill;

            _vrtCreateControl.CreateStarted += _vrtCreateControl_CreateStarted;
            _vrtCreateControl.CreateStoped += _vrtCreateControl_CreateStoped;
        }

        private void InitLoggerControl()
        {
            _loggerControl = new LoggerControl();
            splitContainer1.Panel2.Controls.Add(_loggerControl);
            _loggerControl.Dock = DockStyle.Fill;
        }

        private void InitMapUpdateControl()
        {
            _dataUpdateControl = new DataUpdateControl();
            tabPage4.Controls.Add(_dataUpdateControl);
            _dataUpdateControl.Dock = DockStyle.Fill;
        }

        private void _overviewCreateControl_CreateStarted(object sender)
        {
            _mapConvertControl.Enabled = false;
            _vrtCreateControl.Enabled = false;
        }

        private void _overviewCreateControl_CreateStoped(object sender)
        {
            _mapConvertControl.Enabled = true;
            _vrtCreateControl.Enabled = true;
        }

        private void _mapConvertControl_ConvertStarted(object sender)
        {
            _overviewCreateControl.Enabled = false;
            _vrtCreateControl.Enabled = false;
        }

        private void _mapConvertControl_ConvertStoped(object sender)
        {
            _overviewCreateControl.Enabled = true;
            _vrtCreateControl.Enabled = true;
        }

        private void _vrtCreateControl_CreateStoped(object sender)
        {
            _mapConvertControl.Enabled = true;
            _overviewCreateControl.Enabled = true;
        }

        private void _vrtCreateControl_CreateStarted(object sender)
        {
            _mapConvertControl.Enabled = false;
            _overviewCreateControl.Enabled = false;
        }

        private void _closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (_mapConvertControl.IsMapConvertWorkerBusy())
            //{
            //    DialogResult result = _mapConvertControl.CancelMapConvertWorker();

            //    if(result != DialogResult.Yes)
            //    {
            //        e.Cancel = true;
            //        return;
            //    }
            //}

            //if (_overviewCreateControl.IsCreateOverviewWorkerBusy())
            //{
            //    DialogResult result = _overviewCreateControl.CancelCreateOverviewWorker();

            //    if (result != DialogResult.Yes)
            //    {
            //        e.Cancel = true;
            //        return;
            //    }
            //}

            if (MessageBox.Show("종료하시겠습니까?", "프로그램 종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }

        }

    }
}
