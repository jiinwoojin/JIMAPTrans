using System;
using System.Windows.Forms;

namespace JIMapTrans.Logger
{
    public partial class LoggerControl : UserControl
    {

        public LoggerControl()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {            
            InitControls();
            InitLoggerManager();
        }

        private void InitLoggerManager()
        {
            LoggerManager.Initialize(_logViewRichTextBox);
        }

        private void InitControls()
        {
            _logViewRichTextBox.BackColor = System.Drawing.Color.White;
        }

        private void _clearLogButton_Click(object sender, EventArgs e)
        {
            _logViewRichTextBox.Clear();
            LoggerManager.FlushLogger(3000);
        }
    }
}
