using JIMapTrans.Common;
using JIMapTrans.GdalConfig;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace JIMapTrans.Vrt
{
    public partial class VrtCreateOptionControl : UserControl
    {
        public VrtCreateOptionControl()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            InitControls();
        }

        private void InitControls()
        {
            InitComboBoxControls();
        }

        private void InitComboBoxControls()
        {
            _resolutionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CommonUtil.LoadComboBoxItems(_resolutionComboBox, typeof(GdalEnum.ResolutionType));

            _resamplingAlgComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CommonUtil.LoadComboBoxItems(_resamplingAlgComboBox, typeof(GdalEnum.ResamplingType));

        }
        
        public List<string> GetVrtCreateOptions()
        {
            List<string> options = new List<string>();

            if (_resolutionComboBox.SelectedIndex > -1)
            {
                options.Add("-resolution");
                options.Add(((GdalEnum.ResolutionType)_resolutionComboBox.SelectedValue).ToString());
            }

            if (_separateCheckBox.Checked)
            {
                options.Add("-separate");
            }

            if(_allowPrjDiffCheckBox.Checked)
            {
                options.Add("-allow_projection_difference");
            }

            if(_addAlphaCheckBox.Checked)
            {
                options.Add("-addalpha");                
            }

            if (_resamplingAlgComboBox.SelectedIndex > -1)
            {
                options.Add("-r");
                options.Add(((GdalEnum.ResamplingType)_resamplingAlgComboBox.SelectedValue).ToString());
            }

            if(_nodataValTextBox.Text.Length > 0)
            {
                options.Add("-srcnodata");
                options.Add(string.Format("{0}", _nodataValTextBox.Text));
            }

            string additionalOptionsString = GetAdditionalOptionsText();
            var additionalOptions = GdalConfigManager.GdalCommandLineParsing(additionalOptionsString);
            
            if (additionalOptions.Length > 0)
            {
                options.AddRange(additionalOptions.ToList());
            }

            return options;
        }

        private string GetAdditionalOptionsText()
        {
            if (_additionalOptionsTextBox.Text.Length < 1)
            {
                return "";
            }

            return _additionalOptionsTextBox.Text;
        }
    }
}
