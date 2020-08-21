using JIMapTrans.Common.Infos;
using JIMapTrans.Common.Utils;
using JIMapTrans.GdalManager;
using JIMapTrans.GdalManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace JIMapTrans.Vrt
{
    public partial class VrtCreatePathSettingControl : UserControl
    {
        private string _inputPlaceHolderString = "경로를 입력해주세요.";
        private string _outputPlaceHolderString = "임시 경로로 저장합니다.";

        public VrtCreatePathSettingControl()
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
            InitRadioButtons();
            InitInputFileFormatComboBox();
            InitTextBox();
        }

        private void InitTextBox()
        {
            ControlsUtil.SetTextboxPlaceHolder(_inputTextBox, _inputPlaceHolderString);
            ControlsUtil.SetTextboxPlaceHolder(_outputTextBox, _outputPlaceHolderString);
        }

        private void InitRadioButtons()
        {
            _fileTypeRadioButton.CheckedChanged += RadioButton1_CheckedChanged;
            _directoryTypeRadioButton.CheckedChanged += RadioButton2_CheckedChanged;
            _fileTypeRadioButton.Checked = true;
        }

        private void InitInputFileFormatComboBox()
        {
            _inputFileFormatComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _inputFileFormatComboBox.DropDownWidth = 400;
            List<GdalRasterFileFormat> fileFormats = GdalConfigManager.GetGdalRasterFileFormats();

            var fileFormat = new GdalRasterFileFormat("모든 파일", "*");

            fileFormats.Insert(0, fileFormat);

            _inputFileFormatComboBox.DataSource = fileFormats;
            _inputFileFormatComboBox.DisplayMember = "LongName";
            _inputFileFormatComboBox.ValueMember = "Extensions";

            //var result = fileFormats.Find(x => x.Extensions.Contains("tif"));

            //if (result == null)
            //{
            //    return;
            //}

            //_inputFileFormatComboBox.SelectedItem = result;
        }

        private void SetConfigByPathType(PathType selectedPathType)
        {
            if (selectedPathType == PathType.FilePathType)
            {
                label1.Text = "입력 TXT 경로";
                label2.Text = "출력 파일 경로";

                label3.Visible = false;
                _inputFileFormatComboBox.Visible = false;
            }
            else
            {
                label1.Text = "입력 폴더 경로";
                label2.Text = "출력 파일 경로";

                label3.Visible = true;
                _inputFileFormatComboBox.Visible = true;
            }
        }

        public PathInfo GetVrtCreatePathInfo()
        {
            PathInfo pathInfo = new PathInfo();

            pathInfo.SelectedPathType = _fileTypeRadioButton.Checked ? PathType.FilePathType : PathType.DirectoryPathType;
            pathInfo.InputExtensions = _inputFileFormatComboBox.SelectedValue.ToString();
            pathInfo.InputPathString = GetInputPath(_inputTextBox.Text);
            pathInfo.InputPathList = GetInputPathList(pathInfo);
            //pathInfo.OutputPathString = _outputTextBox.Text;

            if (_outputTextBox.Text.Length > 0 && _outputTextBox.Text != _outputPlaceHolderString)
            {
                string outputDirectory = Path.GetDirectoryName(_outputTextBox.Text);

                if (outputDirectory.Length < 1)
                {
                    _outputTextBox.Text = Path.Combine(Application.StartupPath, _outputTextBox.Text);
                }

                string ext = Path.GetExtension(_outputTextBox.Text);

                if (ext != "vrt")
                {
                    _outputTextBox.Text = Path.ChangeExtension(_outputTextBox.Text, "vrt");
                }
            }

            pathInfo.OutputPathString = GetOutputPath(pathInfo, _outputTextBox);

            return pathInfo;
        }


        private string GetInputPath(string inputString)
        {
            if (inputString == _inputPlaceHolderString)
            {
                return "";
            }

            return inputString;
        }

        private string GetOutputPath(PathInfo info, TextBox textBox)
        {
            string newPathString = "";

            if (info.InputPathString == "")
            {
                return newPathString;
            }

            if (textBox.Text != _outputPlaceHolderString)
            {
                return textBox.Text;
            }

            if (info.SelectedPathType == PathType.FilePathType)
            {
                string fileName = string.Format("{0}.vrt", Path.GetFileNameWithoutExtension(info.InputPathString));
                newPathString = Path.Combine(Path.GetTempPath(), "JImap-Trans", string.Format("result_{0}", Guid.NewGuid()), fileName);
            }
            else
            {
                newPathString = Path.Combine(Path.GetTempPath(), "JImap-Trans", string.Format("result_{0}", Guid.NewGuid()));
            }

            textBox.Text = newPathString;

            return newPathString;
        }

        public List<string> GetInputPathList(PathInfo pathInfo)
        {
            List<string> pathList = new List<string>();

            if (pathInfo.SelectedPathType == PathType.FilePathType)
            {
                pathList = FileSystemUtil.GetPathListFromTextFile(pathInfo.InputPathString);
            }
            else
            {
                if (CheckPathInfo(pathInfo))
                {
                    pathList.AddRange(FileSystemUtil.GetPathList(pathInfo.SelectedPathType, pathInfo.InputPathString, pathInfo.InputExtensions));
                }
            }

            return pathList;
        }

        

        public bool CheckPathInfo(PathInfo pathInfo)
        {
            bool result = true;

            if (pathInfo.SelectedPathType == PathType.FilePathType)
            {
                if (!File.Exists(pathInfo.InputPathString))
                {
                    result = false;
                }
            }
            else
            {
                if (!Directory.Exists(pathInfo.InputPathString))
                {
                    result = false;
                }
            }

            return result;
        }

        private void OpenInputPathDialog()
        {
            string filterString = GdalConfigManager.GetGdalRasterFormatFileFilterString();

            var selectedPathType = _fileTypeRadioButton.Checked ? PathType.FilePathType : PathType.DirectoryPathType;

            if (selectedPathType == PathType.FilePathType)
            {
                FileDialog openFileDlg = new OpenFileDialog();

                openFileDlg.Filter = "TXT File(*.txt)|*.txt";
                ControlsUtil.UseDefaultExtAsFilterIndex(openFileDlg);

                DialogResult reuslt = openFileDlg.ShowDialog();

                if (reuslt == DialogResult.Cancel)
                {
                    return;
                }

                if (openFileDlg.FileName.Length > 0)
                {
                    _inputTextBox.Text = openFileDlg.FileName;
                }
            }
            else
            {
                FolderBrowserDialog folderBrowserDlg = new FolderBrowserDialog();
                DialogResult reuslt = folderBrowserDlg.ShowDialog();

                if (reuslt == DialogResult.Cancel)
                {
                    return;
                }

                if (folderBrowserDlg.SelectedPath.Length > 0)
                {
                    _inputTextBox.Text = folderBrowserDlg.SelectedPath;
                }
            }
        }

        private void OpenOutputPathDialog()
        {
            FileDialog saveFileDlg = new SaveFileDialog();
            saveFileDlg.DefaultExt = "vrt";
            saveFileDlg.Filter = "VRT File(*.vrt)|*.vrt;";

            string inputFileName = "";

            if (Path.HasExtension(_inputTextBox.Text))
            {
                inputFileName = Path.GetFileNameWithoutExtension(_inputTextBox.Text);
            }

            if (inputFileName.Length > 0)
            {
                saveFileDlg.FileName = inputFileName + ".vrt";
            }

            DialogResult reuslt = saveFileDlg.ShowDialog();

            if (reuslt == DialogResult.Cancel)
            {
                return;
            }

            if (saveFileDlg.FileName.Length > 0)
            {
                _outputTextBox.Text = saveFileDlg.FileName;
            }
        }


        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SetConfigByPathType(PathType.FilePathType);
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SetConfigByPathType(PathType.DirectoryPathType);
        }

        private void _inputPathButton_Click(object sender, EventArgs e)
        {
            OpenInputPathDialog();
        }

        private void _outputPathButton_Click(object sender, EventArgs e)
        {
            OpenOutputPathDialog();
        }
    }
}
