using JIMapTrans.Common;
using JIMapTrans.GdalConfig;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace JIMapTrans.Overview
{
    public partial class OverviewCreatePathSettingControl : UserControl
    {
        public OverviewCreatePathSettingControl()
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
            InitRadioButtonControls();
            InitTextBox();
            InitInputFileFormatComboBox();
        }

        private void InitTextBox()
        {
            CommonUtil.SetTextboxPlaceHolder(_inputTextBox, "경로를 입력해주세요.");
        }

        private void InitRadioButtonControls()
        {
            _fileTypeRadioButton.CheckedChanged += RadioButton1_CheckedChanged;
            _directoryRadioButton.CheckedChanged += RadioButton2_CheckedChanged;
            _fileTypeRadioButton.Checked = true;
        }

        private void InitInputFileFormatComboBox()
        {
            _inputFileFormatComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _inputFileFormatComboBox.DropDownWidth = 400;
            List<GdalRasterFileFormat> fileFormats = GdalConfigManager.GetGdalRasterFileFormats();

            _inputFileFormatComboBox.DataSource = fileFormats;
            _inputFileFormatComboBox.DisplayMember = "LongName";
            _inputFileFormatComboBox.ValueMember = "Extensions";

            var result = fileFormats.Find(x => x.Extensions.Contains("tiff"));

            if (result == null)
            {
                return;
            }

            _inputFileFormatComboBox.SelectedItem = result;
        }

        public PathInfo GetOverviewCreatePathInfo()
        {
            PathInfo info = new PathInfo();

            info.SelectedPathType = _fileTypeRadioButton.Checked ? PathType.FilePathType : PathType.DirectoryPathType;
            info.InputExtensions = _inputFileFormatComboBox.SelectedValue.ToString();
            info.InputPathString = _inputTextBox.Text;
            info.InputPathList = GetInputPathList(info);

            return info;
        }

        private List<string> GetInputPathList(PathInfo pathInfo)
        {
            List<string> pathList = new List<string>();
            
            if (CheckPathInfo(pathInfo.SelectedPathType, pathInfo.InputPathString))
            {
                pathList.AddRange(CommonUtil.GetPathList(pathInfo.SelectedPathType, pathInfo.InputPathString, pathInfo.InputExtensions));

            }
            //if (CheckPathInfo(pathInfo.SelectedPathType, pathInfo.InputPathString))
            //{
            //    pathList = CommonUtil.GetPathList(pathInfo.SelectedPathType, pathInfo.InputPathString, "tif");
            //}

            return pathList;
        }

        private bool CheckPathInfo(PathType pathType, string inputPath)
        {
            bool result = true;

            if (pathType == PathType.FilePathType)
            {
                if (!File.Exists(inputPath))
                {
                    result = false;
                }
                //if (".tif" != Path.GetExtension(inputPath))
                //{
                //    result = false;
                //}
            }
            else
            {
                if (!Directory.Exists(inputPath))
                {
                    result = false;
                }
            }

            return result;
        }

        private void SetConfigByPathType()
        {
            PathType selectedPathType = _fileTypeRadioButton.Checked ? PathType.FilePathType : PathType.DirectoryPathType;

            if (selectedPathType == PathType.FilePathType)
            {
                label1.Text = "입력 파일 경로";

                label3.Visible = false;
                _inputFileFormatComboBox.Visible = false;
            }
            else
            {
                label1.Text = "입력 폴더 경로";

                label3.Visible = true;
                _inputFileFormatComboBox.Visible = true;
            }
        }

        private void OpenInputPathDialog()
        {
            string filterString = GdalConfig.GdalConfigManager.GetGdalRasterFormatFileFilterString();

            var selectedPathType = _fileTypeRadioButton.Checked ? PathType.FilePathType : PathType.DirectoryPathType;

            if (selectedPathType == PathType.FilePathType)
            {
                FileDialog openFileDlg = new OpenFileDialog();

                //openFileDlg.Filter = "ECW File(*.ecw)|*.ecw";
                openFileDlg.DefaultExt = "tif";
                openFileDlg.Filter = filterString;
                CommonUtil.UseDefaultExtAsFilterIndex(openFileDlg);

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

        //private void OpenInputPathDialog()
        //{
        //    PathType selectedPathType = _fileTypeRadioButton.Checked ? PathType.FilePathType : PathType.DirectoryPathType;

        //    if (selectedPathType == PathType.FilePathType)
        //    {
        //        FileDialog openFileDlg = new OpenFileDialog();
        //        openFileDlg.DefaultExt = "tif";
        //        openFileDlg.Filter = "TIFF File(*.tif)|*.tif";
        //        openFileDlg.ShowDialog();

        //        if (openFileDlg.FileName.Length > 0)
        //        {
        //            _inputTextBox.Text = openFileDlg.FileName;
        //        }
        //    }
        //    else
        //    {
        //        FolderBrowserDialog folderBrowserDlg = new FolderBrowserDialog();
        //        folderBrowserDlg.ShowDialog();

        //        if (folderBrowserDlg.SelectedPath.Length > 0)
        //        {
        //            _inputTextBox.Text = folderBrowserDlg.SelectedPath;
        //        }
        //    }
        //}

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SetConfigByPathType();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SetConfigByPathType();
        }

        private void _inputPathButton_Click(object sender, EventArgs e)
        {
            OpenInputPathDialog();
        }
    }
}
