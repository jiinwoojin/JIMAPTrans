using JIMapTrans.Common.Utils;
using JIMapTrans.GdalManager;
using JIMapTrans.GdalManager.Models;
using JIMapTrans.GdalManager.Models.Options;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JIMapTrans.Overview
{
    public partial class OverviewCreateOptionControl : UserControl
    {
        private string ProcessedProfileString = "";

        public OverviewCreateOptionControl()
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
            InitProfiles();
            InitComboBoxControls();
            InitCheckBoxControls();
        }

        private void InitCheckBoxControls()
        {
            foreach (var control in _levelsPanel.Controls)
            {
                var check = control as CheckBox;

                if (check == null)
                {
                    continue;
                }

                check.Checked = true;
            }
        }

        private void InitComboBoxControls()
        {
            ControlsUtil.LoadComboBoxItems(_overviewFormatComboBox, typeof(OverviewOptionEnum.OverviewForamt));
            ControlsUtil.LoadComboBoxItems(_overviewResamplingComboBox, typeof(GdalEnum.ResamplingType));

            _overviewFormatComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _overviewResamplingComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            _profilesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _profilesComboBox.DataSource = OverviewDataSource.OverviewCreationProfileList;
            _profilesComboBox.DisplayMember = "ProfileName";
            _profilesComboBox.ValueMember = "OptionsString";
        }

        private void InitProfiles()
        {
            OverviewDataSource.OverviewCreationProfileList = new List<OptionProfile>();
            {
                List<OptionItem> items = new List<OptionItem>();
                OverviewDataSource.OverviewCreationProfileList.Add(new OptionProfile("", items));
            }  
            {
                List<OptionItem> items = new List<OptionItem>();
                items.Add(new OptionItem("JPEG_QUALITY_OVERVIEW", "75"));
                items.Add(new OptionItem("COMPRESS_OVERVIEW", "JPEG"));
                items.Add(new OptionItem("BIGTIFF_OVERVIEW", "YES"));
                items.Add(new OptionItem("NUM_THREADS", "ALL_CPUS"));

                OverviewDataSource.OverviewCreationProfileList.Add(new OptionProfile("기본값", items));
            }
            {//COMPRESS_OVERVIEW=NONE BIGTIFF_OVERVIEW=IF_NEEDED
                List<OptionItem> items = new List<OptionItem>();
                items.Add(new OptionItem("COMPRESS_OVERVIEW", "NONE"));
                items.Add(new OptionItem("BIGTIFF_OVERVIEW", "IF_NEEDED"));

                OverviewDataSource.OverviewCreationProfileList.Add(new OptionProfile("압축하지 않음", items));
            }
            {//COMPRESS_OVERVIEW=PACKBITS
                List<OptionItem> items = new List<OptionItem>();
                items.Add(new OptionItem("COMPRESS_OVERVIEW", "PACKBITS"));

                OverviewDataSource.OverviewCreationProfileList.Add(new OptionProfile("약한 압축", items));
            }
            {//COMPRESS_OVERVIEW=DEFLATE PREDICTOR_OVERVIEW=2 ZLEVEL=9
                List<OptionItem> items = new List<OptionItem>();
                items.Add(new OptionItem("COMPRESS_OVERVIEW", "DEFLATE"));
                items.Add(new OptionItem("PREDICTOR_OVERVIEW", "2"));
                items.Add(new OptionItem("ZLEVEL", "9"));

                OverviewDataSource.OverviewCreationProfileList.Add(new OptionProfile("강한 압축", items));
            }
            {//JPEG_QUALITY_OVERVIEW=75 COMPRESS_OVERVIEW=JPEG PHOTOMETRIC_OVERVIEW=YCBCR INTERLEAVE_OVERVIEW=PIXEL
                List<OptionItem> items = new List<OptionItem>();
                items.Add(new OptionItem("JPEG_QUALITY_OVERVIEW", "75"));
                items.Add(new OptionItem("COMPRESS_OVERVIEW", "JPEG"));
                items.Add(new OptionItem("PHOTOMETRIC_OVERVIEW", "YCBCR"));
                items.Add(new OptionItem("INTERLEAVE_OVERVIEW", "PIXEL"));

                OverviewDataSource.OverviewCreationProfileList.Add(new OptionProfile("JPEG 압축", items));
            }     
        }

        private List<int> GetPyramidLevels()
        {
            List<int> levels = new List<int>();

            foreach(var control in _levelsPanel.Controls)
            {
                var check = control as CheckBox;

                if(check == null)
                {
                    continue;
                }
                
                if(check.Checked != true)
                {
                    continue;
                }

                levels.Add(Convert.ToInt32(check.Text));
            }

            return levels;
        }

        public OverviewCreateInfo GetOverviewCreateOptions()
        {
            OverviewCreateInfo overviewCreateInfo = new OverviewCreateInfo();

            overviewCreateInfo.OverviewFormat = (OverviewOptionEnum.OverviewForamt)_overviewFormatComboBox.SelectedIndex;
            overviewCreateInfo.OverviewResamplingOption = (GdalEnum.ResamplingType)_overviewResamplingComboBox.SelectedValue;
            overviewCreateInfo.IsNeedCalcLevel = _calcLevelsCheckBox.Checked;
            overviewCreateInfo.OverviewCreationOptionsString = _creationOptionsTextBox.Text;
            if (!overviewCreateInfo.IsNeedCalcLevel)
            {
                overviewCreateInfo.LevelList = GetPyramidLevels();
            }

            return overviewCreateInfo;
        }
        
        public void SetOverviewProfileSetting()
        {
            GdalConfigManager.SetProfileSettingDefault(ProcessedProfileString);

            string optionString = _creationOptionsTextBox.Text;            

            GdalConfigManager.SetProfileSetting(optionString);

            ProcessedProfileString = optionString;            
        }

        private void _overviewFormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = sender as ComboBox;

            if(combo == null)
            {
                return;
            }

            if(combo.SelectedIndex != 1)
            {
                return;
            }

            string msg = "내부 생성 작업은 원본 데이터 파일을 변경시킬 수도 있으며, 생성 후엔 제거할 수 없습니다. 계속하시겠습니까?";

             DialogResult reuslt = MessageBox.Show(msg, "오버뷰 포맷 설정", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(reuslt == DialogResult.Yes)
            {
                return;
            }

            combo.SelectedIndex = 0;
        }

        private void _profilesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = sender as ComboBox;

            if(combo == null)
            {
                return;
            }

            _creationOptionsTextBox.Text = combo.SelectedValue.ToString();
        }

        private void _calcLevelsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = sender as CheckBox;

            foreach (var control in _levelsPanel.Controls)
            {
                var check = control as CheckBox;

                if (check == null)
                {
                    continue;
                }

                if (checkBox.Equals(check))
                {
                    continue;
                }

                check.Enabled = !checkBox.Checked;
            }
        }
    }
}
