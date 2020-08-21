using JIMapTrans.GdalManager;
using JIMapTrans.GdalManager.Models.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace JIMapTrans.MapConvert
{
    public partial class MapConvertOptionControl : UserControl
    {
        public MapConvertOptionControl()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            InitMapConvertProfile();
            InitUncheckedOptionItemList();
            InitControls();
        }

        private void InitControls()
        {
            InitGridView();
            InitCheckedBoxList();
            InitComboBoxControls();
            InitNumericUpDownControls();
            InitCheckBoxControl();            
        }

        private void InitCheckBoxControl()
        {
            _outsizeByPercentageCheckBox.Checked = true;
        }

        private void InitGridView()
        {
            dataGridView1.DataSource = MapConvertDataSource.CheckedOptionItemList;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.RowHeadersVisible = false;
            //dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;

        }

        private void InitCheckedBoxList()
        {
            checkedListBox1.Items.AddRange(MapConvertDataSource.GdalCreationOptionList.Option);
            checkedListBox1.DisplayMember = "name";

            checkedListBox1.ItemCheck += CheckedListBox1_ItemCheck;
            checkedListBox1.SelectedIndexChanged += CheckedListBox1_SelectedIndexChanged;
        }

        private void InitUncheckedOptionItemList()
        {
            foreach (var item in MapConvertDataSource.GdalCreationOptionList.Option)
            {
                MapConvertDataSource.UnchekedOptionItemList.Add(new OptionItem(item.name, item.@default));
            }
        }

        private void InitNumericUpDownControls()
        {
            _xSizeNumericUpDown.Minimum = 0;
            _xSizeNumericUpDown.Maximum = 100;
            _xSizeNumericUpDown.Value = 0;
                        
            _ySizeNumericUpDown.Minimum = 0;
            _ySizeNumericUpDown.Maximum = 100;
            _ySizeNumericUpDown.Value = 0;
        }

        private void InitMapConvertProfile()
        {
            MapConvertDataSource.MapConvertProfileList = new List<OptionProfile>();
            {
                List<OptionItem> items = new List<OptionItem>();
                MapConvertDataSource.MapConvertProfileList.Add(new OptionProfile("", items));
            }           
            {
                List<OptionItem> items = new List<OptionItem>();
                items.Add(new OptionItem("COMPRESS", "DEFLATE"));
                items.Add(new OptionItem("PREDICTOR", "2"));
                items.Add(new OptionItem("BIGTIFF", "YES"));
                items.Add(new OptionItem("NUM_THREADS", "ALL_CPUS"));

                MapConvertDataSource.MapConvertProfileList.Add(new OptionProfile("기본값", items));
            }
            {//COMPRESS_OVERVIEW=NONE BIGTIFF_OVERVIEW=IF_NEEDED
                List<OptionItem> items = new List<OptionItem>();
                items.Add(new OptionItem("COMPRESS", "NONE"));
                items.Add(new OptionItem("BIGTIFF", "IF_NEEDED"));

                MapConvertDataSource.MapConvertProfileList.Add(new OptionProfile("압축하지 않음", items));
            }
            {//COMPRESS_OVERVIEW=PACKBITS
                List<OptionItem> items = new List<OptionItem>();
                items.Add(new OptionItem("COMPRESS", "PACKBITS"));

                MapConvertDataSource.MapConvertProfileList.Add(new OptionProfile("약한 압축", items));
            }
            {//COMPRESS_OVERVIEW=DEFLATE PREDICTOR_OVERVIEW=2 ZLEVEL=9
                List<OptionItem> items = new List<OptionItem>();
                items.Add(new OptionItem("COMPRESS", "DEFLATE"));
                items.Add(new OptionItem("PREDICTOR", "2"));
                items.Add(new OptionItem("ZLEVEL", "9"));

                MapConvertDataSource.MapConvertProfileList.Add(new OptionProfile("강한 압축", items));
            }
            {//JPEG_QUALITY_OVERVIEW=75 COMPRESS_OVERVIEW=JPEG PHOTOMETRIC_OVERVIEW=YCBCR INTERLEAVE_OVERVIEW=PIXEL
                List<OptionItem> items = new List<OptionItem>();
                items.Add(new OptionItem("JPEG_QUALITY", "75"));
                items.Add(new OptionItem("COMPRESS", "JPEG"));

                MapConvertDataSource.MapConvertProfileList.Add(new OptionProfile("JPEG 압축", items));
            }
        }

        private void InitComboBoxControls()
        {
            _mapConvertProfileComboBox.DataSource = MapConvertDataSource.MapConvertProfileList;
            _mapConvertProfileComboBox.DisplayMember = "ProfileName";
            _mapConvertProfileComboBox.ValueMember = "OptionsString";
            _mapConvertProfileComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            _outputDataTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _outputDataTypeComboBox.Items.AddRange(new string[] { "입력 데이터의 데이터 형 사용", "Byte", "UInt16", "Int16", "UInt32",
     "Int32", "Float32", "Float64", "CInt16", "CInt32", "CFloat32", "CFloat64" });
            _outputDataTypeComboBox.SelectedIndex = 0;
        }

        private List<string> GetOutSizeOptions()
        {
            List<string> options = new List<string>();

            if (_xSizeNumericUpDown.Value != 0 && _ySizeNumericUpDown.Value != 0)
            {
                string xRasterSize = string.Format("{0}{1}", _xSizeNumericUpDown.Value.ToString(), _xSizeLabel.Text);
                string yRasterSize = string.Format("{0}{1}", _ySizeNumericUpDown.Value.ToString(), _ySizeLabel.Text);

                options.Add("-outsize");
                options.Add(xRasterSize);
                options.Add(yRasterSize);
            }

            return options;
        }

        public List<string> GetMapConvertOptions()
        {
            List<string> options = new List<string>();

            options.AddRange(MapConvertOptionManager.GetConfigOptionsString());

            string dataTypeString = GetOutputDataTypeOptionText();
            options.AddRange(MapConvertOptionManager.GetOutputDataTypeOptionString(dataTypeString));

            options.AddRange(GetOutSizeOptions());

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

        private string GetOutputDataTypeOptionText()
        {
            if (_outputDataTypeComboBox.SelectedIndex < 1)
            {
                return "";
            }

            return _outputDataTypeComboBox.SelectedText;
        }

        public void ResetCheckedList()
        {
            int count = checkedListBox1.Items.Count;

            for (int i = 0; i < count; i++)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        public void SetMapConvertOptions(OptionProfile profile)
        {
            if (profile == null)
            {
                return;
            }

            if (profile.Options == null)
            {
                return;
            }

            ResetCheckedList();

            foreach (var option in profile.Options)
            {
                int index = checkedListBox1.FindString(option.OptionName);

                if (index < 0)
                {
                    continue;
                }

                checkedListBox1.SetItemCheckState(index, CheckState.Checked);

                var item = MapConvertDataSource.CheckedOptionItemList.FirstOrDefault(x => x.OptionName == option.OptionName);

                if (item == null)
                {
                    continue;
                }

                item.OptionVaule = option.OptionVaule;
            }
        }

        private void SetComboBoxCellStyle(CreationOptionListOption item, int index)
        {
            if (index < 0)
            {
                return;
            }

            if (item == null)
            {
                return;
            }

            if (item.Value == null)
            {
                return;
            }

            DataGridViewComboBoxCell cCell = new DataGridViewComboBoxCell();
            cCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

            List<string> values = new List<string>();
            foreach (var val in item.Value)
            {
                values.Add(val.Value);
            }

            cCell.Items.AddRange(values.ToArray());

            dataGridView1.Rows[index].Cells[1] = cCell;

            if (MapConvertDataSource.CheckedOptionItemList[index].OptionVaule != null)
            {
                cCell.Value = MapConvertDataSource.CheckedOptionItemList[index].OptionVaule;
            }
        }

        private void SetOutsizeNumericUpDownControls(bool isByPercentage)
        {
            if (isByPercentage)
            {
                _xSizeLabel.Text = "%";
                _ySizeLabel.Text = "%";

                _xSizeNumericUpDown.Maximum = 100;
                _xSizeNumericUpDown.DecimalPlaces = 2;

                _ySizeNumericUpDown.Maximum = 100;
                _ySizeNumericUpDown.DecimalPlaces = 2;
            }
            else
            {
                _xSizeLabel.Text = "";
                _ySizeLabel.Text = "";

                _xSizeNumericUpDown.Maximum = 100;
                _xSizeNumericUpDown.DecimalPlaces = 0;

                _ySizeNumericUpDown.Maximum = Decimal.MaxValue;
                _ySizeNumericUpDown.DecimalPlaces = 0;
            }
        }

        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var box = sender as CheckedListBox;

            if (box == null)
            {
                return;
            }

            var item = box.SelectedItem as CreationOptionListOption;
            _descriptionTextBox.Text = MapConvertOptionManager.GetDescriptionString(item);
        }

        private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var item = checkedListBox1.Items[e.Index] as CreationOptionListOption;

            if (e.NewValue == CheckState.Checked)
            {
                int index = MapConvertOptionManager.CheckedOptionItem(item.name);
                SetComboBoxCellStyle(item, index);
            }
            if (e.NewValue == CheckState.Unchecked)
            {
                MapConvertOptionManager.UncheckedOptionItem(item.name);
            }
        }

        private void _mapConvertProfileComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;

            int index = comboBox.SelectedIndex;
            if (index < 0)
            {
                return;
            }

            if (comboBox.Items.Count < 1)
            {
                return;
            }

            var profile = comboBox.Items[index] as OptionProfile;

            if (profile == null)
            {
                return;
            }

            SetMapConvertOptions(profile);
        }

        private void _outsizeByPercentageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = sender as CheckBox;
            
            if(checkbox == null)
            {
                return;
            }

            SetOutsizeNumericUpDownControls(checkbox.Checked);
        }

    }
}
