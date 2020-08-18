using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JIMapTrans.Common;
using System.IO;
using Renci.SshNet;
using DotSpatial.Projections;
using Model3DConversion.Models.Converters;
using Newtonsoft.Json.Linq;
using YamlDotNet.RepresentationModel;
using System.Collections.Specialized;
using System.Collections;
using JIMapTrans.Logger;

namespace JIMapTrans.DataUpdate
{
    public partial class DataUpdateControl : UserControl
    {
        private BackgroundWorker _mapUpdateWorker;
        private BackgroundWorker _modelUpdateWorker;

        private MapUpdateInfo _mapUpdateInfo;
        private NModel3DConverterArgumentList _modelUpdateInfo;

        private long _UploadFileSize = 0;       //삭제예정
        private long _currentFileSize = 0;
        private long _totalFileSize = 0;
        private int _uploadCount = 0;

        private Dictionary<string, string> _crs_dic = new Dictionary<string, string>();
        private Dictionary<string, string> _dic_vector = new Dictionary<string, string>();
        private Dictionary<string, string> _dic_raster = new Dictionary<string, string>();
        private OrderedDictionary _dic_file = new OrderedDictionary();
        private SftpClient _sftp = null;

        public DataUpdateControl()
        {
            InitializeComponent();
            InitUIControl();
            InitializeEvent();
            InitializeWorker();
        }

        #region Initializ

        private void InitializeEvent()
        {
            MapDataRadioButton.CheckedChanged += new EventHandler(DataTyleRadioButtons_CheckedChanged);
            ModelRadioButton.CheckedChanged += new EventHandler(DataTyleRadioButtons_CheckedChanged);
            SftpUploadRadioButton.CheckedChanged += new EventHandler(UploadRadioButtons_CheckedChanged);
            AgentUploadRadioButton.CheckedChanged += new EventHandler(UploadRadioButtons_CheckedChanged);
        }

        private void InitializeWorker()
        {
            InitBackgroundWorker();
        }

        private void InitUIControl()
        {
            InitModelDataUI();
            //InitPrograssbar();
        }

        private void InitModelDataUI()
        {
            GetModelJSON();
            GetMapInfoJSON();
            MapTypeComboBox.SelectedIndex = 0;
            SetMapData();

            string file = Application.StartupPath + @"\CRS.json";

            string value = "";
            using (StreamReader reader = new StreamReader(file))
            {
                value = reader.ReadToEnd();
              //  var json = JObject.Parse(value);
                var array = JArray.Parse(value);

                foreach(JObject obj in array)
                {
                    string crs_key = obj["CRS"].ToString();
                    string crs_value = obj["value"].ToString();

                    CRSComboBox.Items.Add(crs_key);
                    _crs_dic.Add(crs_key, crs_value);
                }
             //   var JToken = json.SelectToken("");
            }
        }

        private void SetMapData()
        {
            MapTypeComboBox2.Items.Clear();

            if (MapTypeComboBox.Text.ToLower() == "vector")
            {
                foreach (var kvp in _dic_vector)
                {
                    InsertComboBox(MapTypeComboBox2, kvp.Key);
                }
            }
            else if (MapTypeComboBox.Text.ToLower() == "raster")
            {
                foreach (var kvp in _dic_raster)
                {
                    InsertComboBox(MapTypeComboBox2, kvp.Key);
                }
            }
            MapTypeComboBox2.SelectedIndex = 0;
        }

        private void InitPrograssbar()
        {
            CommonUtil.SetLabelText(this, ProgressLabel, "");
            CommonUtil.SetProgressBarValue(progressBar, 0);
        }

        private void InitBackgroundWorker()
        {
            _mapUpdateWorker = new BackgroundWorker();
            _mapUpdateWorker.WorkerReportsProgress = true;
            _mapUpdateWorker.WorkerSupportsCancellation = true;
            _mapUpdateWorker.DoWork += MapUpdateWorker_DoWork;
            _mapUpdateWorker.RunWorkerCompleted += MapUpdateWorker_RunWorkerCompleted;

            _modelUpdateWorker = new BackgroundWorker();
            _modelUpdateWorker.WorkerReportsProgress = true;
            _modelUpdateWorker.WorkerSupportsCancellation = true;
            _modelUpdateWorker.DoWork += ModelUpdateWorker_DoWork;
            _modelUpdateWorker.RunWorkerCompleted += ModelUpdateWorker_RunWorkerCompleted;
        }

        private void InsertComboBox(ComboBox combobox, string value)
        {
            combobox.Items.Add(value);
        }

        private void InsertComboBox(ComboBox combobox, string[]list)
        {
            foreach(var value in list)
            {
                InsertComboBox(combobox, value.Trim());
            }
        }

        private void GetModelJSON()
        {
            string file = Application.StartupPath + @"\Model.json";

            string value = "";
            using (StreamReader reader = new StreamReader(file))
            {
                value = reader.ReadToEnd();
               // var json = JObject.Parse(value);
                var array = JArray.Parse(value);
                foreach (JObject obj in array)
                {
                    string [] location_list = obj["Location"].ToString().Split(',');
                    string [] modelType_list = obj["ModelType"].ToString().Split(',');
                    InsertComboBox(LocationComboBox, location_list);
                    InsertComboBox(ModelTypeComboBox, modelType_list);
                }
            }
        }

        private void GetMapInfoJSON()
        {
            string file = System.Windows.Forms.Application.StartupPath + @"\MapInfo.json";

            string value = "";
            using (StreamReader reader = new StreamReader(file))
            {
                value = reader.ReadToEnd();
                // var json = JObject.Parse(value);
                var array = JArray.Parse(value);

                foreach (JObject obj in array)
                {
                    string type = obj["type"].ToString();
                    string name = obj["name"].ToString();
                    string code = obj["code"].ToString();

                    if(type.Trim().ToLower() == "vector")
                    {
                        _dic_vector.Add(name, code);
                    }
                    else if (type.Trim().ToLower() == "raster")
                    {
                        _dic_raster.Add(name, code);
                    }
                }
            }
        }

        #endregion


        #region EventHandler

        private void InputPathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDlg = new FolderBrowserDialog();
            DialogResult reuslt = folderBrowserDlg.ShowDialog();

            if (reuslt == DialogResult.OK)
            {
                InputPathTextBox.Text = folderBrowserDlg.SelectedPath;
            }
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            if(_mapUpdateWorker.IsBusy)
            {
                MessageBox.Show("업데이트 작업이 진행중입니다.");
                return;
            }

            if(AgentUploadRadioButton.Checked)
            {
                string path = AgentPathTextBox.Text.Trim();

                if(path == "")
                {
                    MessageBox.Show("Agent 동기화 경로를 입력하세요");
                    return;
                }
                if(!Directory.Exists(path))
                {
                    MessageBox.Show("Agent 동기화 경로가 유효하지 않습니다.");
                    return;
                }
            }
            else
            {
                if(ipAddressControl.Text.Trim() == "")
                {
                    MessageBox.Show("SFTP Host 정보를 입력하세요");
                    return;
                }
                if (SftpUserTextBox.Text.Trim() == "")
                {
                    MessageBox.Show("SFTP 계정정보를 입력하세요");
                    return;
                }
                if (SftpPwTextBox.Text.Trim() == "")
                {
                    MessageBox.Show("SFTP 비밀번호를 입력하세요");
                    return;
                }
                if (SftpPortTextBox.Text.Trim() == "")
                {
                    MessageBox.Show("SFTP 포트를 입력하세요");
                    return;
                }
            }

            _currentFileSize = 0;
            _totalFileSize = 0;
            _dic_file.Clear();

            if (MapDataRadioButton.Checked)
            {
                if(MapTypeComboBox.Text.Trim() == "")
                {
                    MessageBox.Show("벡터/래스터를 선택하세요");
                    return;
                }

                if (MapTypeComboBox2.Text.Trim() == "")
                {
                    MessageBox.Show("지도종류를 선택하세요");
                    return;
                }
                MapDataGroupBox.Enabled = false;
                updateInfoGroupBox.Enabled = false;
                LoggerManager.WriteInfoLogDate("지도 데이터 파일 목록을 정리합니다.");
                GetFiles(InputPathTextBox.Text, _dic_file);
                SetMapUpdateInfo();
                StartMapUpdate();
            }
            else
            {
                MapDataGroupBox.Enabled = false;
                updateInfoGroupBox.Enabled = false;
                SetModelUpdateInfo();
                StartModelUpdate();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {

            if(!_mapUpdateWorker.IsBusy)
            {
                return;
            }

            DialogResult result = MessageBox.Show("데이터 업데이트 진행중입니다. 취소하시겠습니까?"
                + Environment.NewLine + "**취소한 작업은 되돌릴 수 없습니다.**", "업데이트 취소",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }


            if (MapDataRadioButton.Checked)
            {
                if (_mapUpdateWorker.WorkerSupportsCancellation == true)
                {
                    _mapUpdateWorker.CancelAsync();
                    CreateYaml("_cancel");
                }
            }
            else
            {
                if (_modelUpdateWorker.WorkerSupportsCancellation == true)
                {
                    _modelUpdateWorker.CancelAsync();
                }
            }
        }


        private void DataTyleRadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radiobutton = sender as RadioButton;

            if(MapDataRadioButton.Checked)
            {
                MapDataGroupBox.Enabled = true;
                ModelGroupBox.Enabled = false;
            }
            else if (ModelRadioButton.Checked)
            {
                MapDataGroupBox.Enabled = false;
                ModelGroupBox.Enabled = true;
            }
        }

        private void UploadRadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radiobutton = sender as RadioButton;

            if (AgentUploadRadioButton.Checked)
            {
                ipAddressControl.Enabled = false;
                SftpPortTextBox.Enabled = false;
                SftpUserTextBox.Enabled = false;
                SftpPwTextBox.Enabled = false;
                SftpPathTextBox.Enabled = false;
                SftpConnectionButton.Enabled = false;
                AgentPathTextBox.Enabled = true;
                outputButton.Enabled = true;
            }
            else if (SftpUploadRadioButton.Checked)
            {
                ipAddressControl.Enabled = true;
                SftpPortTextBox.Enabled = true;
                SftpUserTextBox.Enabled = true;
                SftpPwTextBox.Enabled = true;
                SftpPathTextBox.Enabled = true;
                SftpConnectionButton.Enabled = true;
                AgentPathTextBox.Enabled = false;
                outputButton.Enabled = false;
            }
        }

        private void MapTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetMapData();
        }

        private void outputButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDlg = new FolderBrowserDialog();
            DialogResult reuslt = folderBrowserDlg.ShowDialog();

            if (reuslt == DialogResult.OK)
            {
                AgentPathTextBox.Text = folderBrowserDlg.SelectedPath;
            }
        }

        private void SftpPortTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void SftpConnectionButton_Click(object sender, EventArgs e)
        {
            int Port = Convert.ToInt32(SftpPortTextBox.Text.Trim());
            string Host = ipAddressControl.Text.Trim();
            string Username = SftpUserTextBox.Text.Trim();
            string Password = SftpPwTextBox.Text.Trim();
            string path = SftpPathTextBox.Text.Trim();

            if (Host == "")
            {
                MessageBox.Show("SFTP Host 정보를 입력하세요");
                return;
            }
            if (Username == "")
            {
                MessageBox.Show("SFTP 계정정보를 입력하세요");
                return;
            }
            if (Password == "")
            {
                MessageBox.Show("SFTP 비밀번호를 입력하세요");
                return;
            }
            if (SftpPortTextBox.Text.Trim() == "")
            {
                MessageBox.Show("SFTP 포트를 입력하세요");
                return;
            }

            using (var client = new SftpClient(Host, Port, Username, Password))
            {
                try
                {
                    LoggerManager.WriteInfoLogDate("SFTP 연결 테스트");
                    client.ConnectionInfo.Timeout = TimeSpan.FromSeconds(10);
                    //client.OperationTimeout = TimeSpan.FromSeconds(10);
                    client.Connect();
                    LoggerManager.WriteInfoLogDate("SFTP 연결 성공");
                    client.Disconnect();
                }
                catch (Exception ex)
                {
                    LoggerManager.WriteErrorLogDate(ex.Message);
                }


            }
        }

        private void ipAddressControl_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("KeyDown: {0}", e.KeyValue);
        }

        private void ipAddressControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("KeyPress: {0}", Convert.ToInt32(e.KeyChar));
        }

        private void ipAddressControl_KeyUp(object sender, KeyEventArgs e)
        {
            Console.WriteLine("KeyUp: {0}", e.KeyValue);
        }

        private void ipAddressControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Console.WriteLine("PreviewKeyDown: {0}", e.KeyValue);
        }

        #endregion


        #region MapUpdate

        private void MapUpdateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            e.Result = UpdateMap(worker, e);
        }

        private void MapUpdateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CompleteUpdateMap(e);
        }


        private long UpdateMap(BackgroundWorker worker, DoWorkEventArgs e)
        {
            long result = 0;

            try
            {
                //업데이트 파일 압축
               // LoggerManager.WriteInfoLogDate("업데이트 파일을 압축합니다.");
                if (_mapUpdateWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return -1;
                }

                string sourcePath = InputPathTextBox.Text;
                string zipPath = Application.StartupPath + @"\temp";

                CompressZip();
                _currentFileSize = 0;
                _totalFileSize = 0;
                //업데이트 정보 파일 생성
                LoggerManager.WriteInfoLogDate("업데이트 정보 파일을 생성합니다.");

                if (!_mapUpdateWorker.CancellationPending)
                {
                    _dic_file.Clear();
                    LoggerManager.WriteInfoLogDate("압축 파일 목록을 정리합니다.");
                    GetFiles(Path.GetDirectoryName(_mapUpdateInfo.ZipPath), _dic_file);
                    CreateYaml("");
                }            

                if (!_mapUpdateWorker.CancellationPending)
                {
                    if (SftpUploadRadioButton.Checked)
                    {
                        LoggerManager.WriteInfoLogDate("파일을 업로드합니다..");
                        _uploadCount = 0;
                        SftpUpload(zipPath, "");
                    }
                    else
                    {
                        LoggerManager.WriteInfoLogDate("파일을 Agent 동기화 폴더로 복사합니다.");
                        FileCopy();
                    }
                }
        
                //temp 파일 삭제
                LoggerManager.WriteInfoLogDate("temp 폴더를 삭제합니다.");
                TempDelete();
                LoggerManager.WriteInfoLogDate("작업 종료");
            }
            catch (Exception ex)
            {
                LoggerManager.WriteErrorLogDate(ex.Message);
            }

            return result;
        }


        private void CompleteUpdateMap(RunWorkerCompletedEventArgs e)
        {
            MapDataGroupBox.Enabled = true;
            updateInfoGroupBox.Enabled = true;

            MessageBox.Show("작업 종료");  
        }

        private void StartMapUpdate()
        {
            if (_mapUpdateWorker.IsBusy)
            {
                return;
            }
            _mapUpdateWorker.RunWorkerAsync();
        }

        private void SetMapUpdateInfo()
        {
            _mapUpdateInfo = new MapUpdateInfo();

            string fileName = "";

            if (MapDataRadioButton.Checked)
            {
                string mapType = GetMapType();
                _mapUpdateInfo.Guid = Guid.NewGuid();
                fileName = mapType + "_" + _mapUpdateInfo.Guid.ToString();

                _mapUpdateInfo.FileName = fileName;
                _mapUpdateInfo.MapName = mapType;
                _mapUpdateInfo.FilePath = InputPathTextBox.Text;
                _mapUpdateInfo.ZipPath = Path.Combine(Application.StartupPath, "temp", fileName, fileName + ".zip");
                _mapUpdateInfo.AgentPath = AgentPathTextBox.Text;
            }
            else
            {
                fileName += "_model";
            }
        }

        private string GetMapType()
        {
            string type = "";

            if (MapTypeComboBox.Text.ToLower() == "vector")
            {
                type = _dic_vector[MapTypeComboBox2.Text];
            }
            else
            {
                type = _dic_raster[MapTypeComboBox2.Text];
            }

            return type;
        }

        private void TempDelete()
        {
            _dic_file.Clear();
            GetFiles(Path.GetDirectoryName(_mapUpdateInfo.ZipPath), _dic_file);
            int count = 1;
            foreach(DictionaryEntry dic in _dic_file)
            {
                string file_path = dic.Key.ToString();

                if(File.Exists(file_path))
                {
                    File.Delete(file_path);
                }
                string file_name = Path.Combine(dic.Key.ToString());
                LoggerManager.WriteInfoLogDate(count.ToString() + "/" + _dic_file.Count.ToString() + " temp 파일 삭제 완료 - " + file_name);
                count++;
            }

            string temp_path = Path.GetDirectoryName(_mapUpdateInfo.ZipPath);

            if(Directory.Exists(temp_path))
            {
                Directory.Delete(temp_path);
            }
        }

        #endregion


        #region ModelUpdate

        private void SetModelUpdateInfo()
        {
            string dateTime = "upload_model_" + LocationComboBox.Text + "_" + ModelTypeComboBox.Text + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");

            string input_path = InputPathTextBox.Text;
            string crs = CRSComboBox.Text;
            string proj = _crs_dic[crs];

            _modelUpdateInfo = new NModel3DConverterArgumentList();
            _modelUpdateInfo.InputFileExtension = "3ds";
            //_modelUpdateInfo.InputProj4String = "+proj=tmerc +lat_0=38 +lon_0=127 +k=1 +x_0=200000 +y_0=600000 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs";
            //_modelUpdateInfo.InputRootDirectoryPath = new DirectoryInfo(@"C:\work\dev\model_conversion\3d_models\input");
            _modelUpdateInfo.InputProj4String = proj;
            _modelUpdateInfo.InputRootDirectoryPath = new DirectoryInfo(input_path);
            _modelUpdateInfo.OutputFileExtension = "obj";
            _modelUpdateInfo.OutputFormatId = "obj";
            _modelUpdateInfo.OutputLevel = 16;
            _modelUpdateInfo.OutputRootDirectoryPath = new DirectoryInfo(@"C:\work\dev\model_conversion\3d_models\output\" + dateTime);
            _modelUpdateInfo.TemporaryRootDirectoryPath = new DirectoryInfo(@"C:\work\dev\model_conversion\3d_models\temp\" + dateTime);
            _modelUpdateInfo.ZipRootDirectoryPath = new DirectoryInfo(@"C:\work\dev\model_conversion\3d_models\zip");
            _modelUpdateInfo.TextureFileExtension = "jpg";
            _modelUpdateInfo.FileName = dateTime;
        }

        private void ModelUpdateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            e.Result = UpdateModel(worker, e);
        }

        private void ModelUpdateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CompleteUpdateModel(e);
        }

        private long UpdateModel(BackgroundWorker worker, DoWorkEventArgs e)
        {
            long result = 0;

          

            string sourcePath = InputPathTextBox.Text;
            string tempPath = System.Windows.Forms.Application.StartupPath + @"\temp";

            var source_projection = ProjectionInfo.FromProj4String(_modelUpdateInfo.InputProj4String);

            var converter = new NModel3DConverter(
                source_projection, _modelUpdateInfo.TextureFileExtension, _modelUpdateInfo.OutputLevel, _modelUpdateInfo.OutputFormatId, _modelUpdateInfo.OutputFileExtension);

            long convert_count = 0;
            long total_count = RetrieveObjFileCount(_modelUpdateInfo.InputRootDirectoryPath.FullName, _modelUpdateInfo.InputFileExtension);

            foreach (var input_file_path in Directory.GetFiles(_modelUpdateInfo.InputRootDirectoryPath.FullName, "*.*", SearchOption.AllDirectories)
                .Where(i => i.EndsWith(_modelUpdateInfo.InputFileExtension, StringComparison.OrdinalIgnoreCase)).ToList())
            {
                if (_modelUpdateWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return -1;
                }


                bool is_success = converter.ConvertRecursively(input_file_path, _modelUpdateInfo.OutputRootDirectoryPath.FullName, _modelUpdateInfo.TemporaryRootDirectoryPath.FullName);
                convert_count++;

                double progress_value = ((double)convert_count / (double)total_count) * 100;
                string value = string.Format("데이터 변환 중 {0}/{1}", convert_count, total_count);
                //UpdateProgresBar(value, progress_value);
            }

            //압축
            //CompressZip(_modelUpdateInfo.OutputRootDirectoryPath.FullName, _modelUpdateInfo.ZipRootDirectoryPath.FullName + @"\" + _modelUpdateInfo.FileName + ".zip");

            //업로드
            //SftpUpload(_modelUpdateInfo.ZipRootDirectoryPath.FullName, _modelUpdateInfo.FileName + ".zip");

            return result;
        }

        private void CompleteUpdateModel(RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("완료");
        }

        private void StartModelUpdate()
        {
            if (_mapUpdateWorker.IsBusy)
            {
                return;
            }

            _modelUpdateWorker.RunWorkerAsync();
        }

        private long RetrieveObjFileCount(string input_root_directory_path, string input_file_extension)
        {
            long result = 0;
            foreach (var input_file_path in Directory.GetFiles(input_root_directory_path, "*.*", SearchOption.AllDirectories)
                .Where(i => i.EndsWith(input_file_extension, StringComparison.OrdinalIgnoreCase)).ToList())
            {
                ++result;
            }

            return result;
        }

        #endregion

        #region  zip Compression
        private void CompressZip()
        {
            using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
            {
                if (!Directory.Exists(Path.GetDirectoryName(_mapUpdateInfo.ZipPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(_mapUpdateInfo.ZipPath));
                }

                long size = (1024 * 1024) * (int)compressSizecUpDown.Value;
                zip.CompressionMethod = Ionic.Zip.CompressionMethod.Deflate;
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                zip.ProvisionalAlternateEncoding = Encoding.UTF8;
                //zip.AlternateEncoding = Encoding.UTF8;
                zip.SaveProgress += zipProgress;
                LoggerManager.WriteInfoLogDate("업데이트 파일을 압축리스트에 추가합니다.");
                zip.AddDirectory(_mapUpdateInfo.FilePath, _mapUpdateInfo.FileName);
                zip.MaxOutputSegmentSize64 = size;
                LoggerManager.WriteInfoLogDate("업데이트 파일 압축을 시작합니다.");
                zip.Save(_mapUpdateInfo.ZipPath);
            }
        }

        private void zipProgress(object sender, Ionic.Zip.SaveProgressEventArgs e)
        {
            if (_mapUpdateWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            if (e.EventType == Ionic.Zip.ZipProgressEventType.Saving_EntryBytesRead)
            {
                int value = Convert.ToInt32(100 * e.BytesTransferred / e.TotalBytesToTransfer);
                int total_value = Convert.ToInt32(100 * (e.BytesTransferred + _currentFileSize) / _totalFileSize);

                CommonUtil.SetLabelText(this, updateProgressLabel, string.Format("{0}  %", (int)value));
                CommonUtil.SetProgressBarValue(progressBar, (int)value);

                CommonUtil.SetLabelText(this, updateTotalProgressLabel, string.Format("{0}  %", (int)total_value));
                CommonUtil.SetProgressBarValue(totalProgressBar, (int)total_value);

            }
            else if (e.EventType == Ionic.Zip.ZipProgressEventType.Saving_Completed)
            {

            }
            else if (e.EventType == Ionic.Zip.ZipProgressEventType.Saving_AfterWriteEntry)
            {
                _currentFileSize += e.CurrentEntry.UncompressedSize;
            }
        }

        #endregion


        #region  SFTP

        private bool SftpUpload(string path, string type)
        {
            bool bRecult = false;

            int Port = Convert.ToInt32(SftpPortTextBox.Text);
            string Host = ipAddressControl.Text;
            string Username = SftpUserTextBox.Text;
            string Password = SftpPwTextBox.Text;
            string RemotePath = SftpPathTextBox.Text;

           //using (var stream = new FileStream(path + @"\"+ fileName, FileMode.Open))
           //using (var client = new SftpClient(Host, Port, Username, Password))
            {
                _sftp = new SftpClient(Host, Port, Username, Password);

                _sftp.Connect();

                if(type.ToLower() == "cancel")
                {
                    using (var stream = new FileStream(path, FileMode.Open))
                    {
                        string file_name = Path.GetFileName(path);
                        _sftp.UploadFile(stream, RemotePath + "/" + file_name);
                        LoggerManager.WriteInfoLogDate(" SFTP 업로드 완료 - " + file_name);
                    }
                }
                else
                {
                    int count = 1;

                    foreach (DictionaryEntry dic in _dic_file)
                    {
                        if (_mapUpdateWorker.CancellationPending)
                            break;

                        string file_path = dic.Key.ToString();
                        string file_name = Path.GetFileName(file_path);
                        long file_size = Convert.ToInt64(dic.Value);

                        try
                        {
                            using (var stream = new FileStream(file_path, FileMode.Open))
                            {
                                //_UploadFileSize = stream.Length;
                                _UploadFileSize = file_size;
                                //FileStream stream = new FileStream(SourcePath + FileName, FileMode.Open)
                                progressBar.Invoke((MethodInvoker)delegate { progressBar.Maximum = 100; });
                                _sftp.UploadFile(stream, RemotePath + "/" + file_name, UpdateProgresBar);
                            }
                            _uploadCount++;
                            _currentFileSize += file_size;

                            if (!_mapUpdateWorker.CancellationPending)
                            {
                                LoggerManager.WriteInfoLogDate(count.ToString() + "/" + _dic_file.Count.ToString() + " SFTP 업로드 완료 - " + file_name);
                            }
                            count++;
                        }
                        catch(ArgumentNullException ex)
                        {
                            LoggerManager.WriteErrorLogDate(ex.Message);
                        }
                        catch (ArgumentException ex)
                        {
                            LoggerManager.WriteErrorLogDate(ex.Message);
                        }
                        catch (ObjectDisposedException  ex)
                        {
                            LoggerManager.WriteErrorLogDate(ex.Message);
                        }
                        catch (Renci.SshNet.Common.SshConnectionException ex)
                        {
                            LoggerManager.WriteErrorLogDate(ex.Message);
                        }
                        catch (Renci.SshNet.Common.SftpPermissionDeniedException ex)
                        {
                            LoggerManager.WriteErrorLogDate(ex.Message);
                        }
                        catch (Renci.SshNet.Common.SshException ex)
                        {
                            LoggerManager.WriteErrorLogDate(ex.Message);
                        }
                        catch (InvalidOperationException ex)
                        {
                            LoggerManager.WriteErrorLogDate(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            if(_mapUpdateWorker.CancellationPending)
                            {
                                if (ex.HResult == -2147467261 || ex.HResult == -2146233088)
                                {
                                    if (_uploadCount > 0)
                                    {
                                        string zip_path = Path.GetDirectoryName(_mapUpdateInfo.ZipPath);
                                        string yaml_name = _mapUpdateInfo.FileName + "_cancel.yaml";
                                        string yaml_path = Path.Combine(zip_path, yaml_name);
                                        SftpUpload(yaml_path, "cancel");
                                    }
                                }
                            }
                            else
                            {
                                LoggerManager.WriteErrorLogDate(ex.Message);
                            }


                            //if (ex.HResult == -2147467261 || ex.HResult == -2146233088)
                            //{
                            //    if (_mapUpdateWorker.CancellationPending && _uploadCount > 0)
                            //    {
                            //        string zip_path = Path.GetDirectoryName(_mapUpdateInfo.zipPath);
                            //        string yaml_name = _mapUpdateInfo.fileName  + "_cancel.yaml";
                            //        string yaml_path = Path.Combine(zip_path, yaml_name);
                            //        SftpUpload(yaml_path, "cancel");
                            //    }
                            //}
                            //else
                            //{
                            //    LoggerManager.WriteErrorLogDate(ex.Message);
                            //}
                        }
                    }
                }

                _sftp.Disconnect();
            }
            return bRecult;
        }

        private void UpdateProgresBar(ulong uploaded)
        {
            if(_mapUpdateWorker.CancellationPending)
            {
                if(_sftp.IsConnected)
                {               
                    _sftp.Disconnect();
                }             
                return;
            }

            double progress_value = ((double)uploaded / (double)_UploadFileSize) * 100;
            int total_persentage = Convert.ToInt32(100 * ((double)uploaded + (double)_currentFileSize) / _totalFileSize);

            CommonUtil.SetLabelText(this, updateProgressLabel, string.Format("{0}  %", (int)progress_value));
            CommonUtil.SetProgressBarValue(progressBar, (int)progress_value);
            CommonUtil.SetLabelText(this, updateTotalProgressLabel, string.Format("{0}  %", (int)total_persentage));
            CommonUtil.SetProgressBarValue(totalProgressBar, (int)total_persentage);

        }

        #endregion

        public void FileCopy()
        {
            string input_path = Path.GetDirectoryName(_mapUpdateInfo.ZipPath);
            string output_path = _mapUpdateInfo.AgentPath;

            byte[] buffer = new byte[1024 * 1024]; // 1MB buffer
                                                   
            int count = 1;

            foreach (DictionaryEntry dic in _dic_file)
            {
                try
                {
                    if (_mapUpdateWorker.CancellationPending)
                    {
                        FileCopyCancel();
                        return;
                    }

                    string SourceFilePath = dic.Key.ToString();
                    using (FileStream source = new FileStream(SourceFilePath, FileMode.Open, FileAccess.Read))
                    {
                        // string source_path = Path.GetDirectoryName(SourceFilePath);
                        string source_child_path = SourceFilePath.Replace(input_path + @"\", "");
                        string file_name = Path.GetFileName(SourceFilePath);
                        string DestFilePath = Path.Combine(output_path, source_child_path);

                        string copy_path = Path.GetDirectoryName(DestFilePath);

                        if (!Directory.Exists(copy_path))
                        {
                            Directory.CreateDirectory(copy_path);
                        }

                        long fileLength = source.Length;
                        using (FileStream dest = new FileStream(DestFilePath, FileMode.Create, FileAccess.Write))
                        {
                            long totalBytes = 0;
                            int currentBlockSize = 0;

                            while ((currentBlockSize = source.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                if (_mapUpdateWorker.CancellationPending)
                                {
                                    FileCopyCancel();
                                    return;
                                }

                                totalBytes += currentBlockSize;
                                double persentage = (double)totalBytes * 100.0 / fileLength;

                                int total_persentage = Convert.ToInt32(100 * (totalBytes + _currentFileSize) / _totalFileSize);

                                CommonUtil.SetLabelText(this, updateProgressLabel, string.Format("{0}  %", (int)persentage));
                                CommonUtil.SetProgressBarValue(progressBar, (int)persentage);

                                CommonUtil.SetLabelText(this, updateTotalProgressLabel, string.Format("{0}  %", (int)total_persentage));
                                CommonUtil.SetProgressBarValue(totalProgressBar, (int)total_persentage);

                                dest.Write(buffer, 0, currentBlockSize);
                            }
                        }
                    }

                    string dic_value = _dic_file[SourceFilePath].ToString();
                    _currentFileSize += Convert.ToInt64(dic_value);

                    if (!_mapUpdateWorker.CancellationPending)
                    {
                        LoggerManager.WriteInfoLogDate(count.ToString() + "/" + _dic_file.Count.ToString() + " 복사 완료 - " + Path.Combine(dic.Key.ToString()));
                    }                    
                    count++;
                }
                catch(Exception ex)
                {
                    LoggerManager.WriteErrorLogDate(ex.Message);
                }
         
            }
        }

        private void FileCopyCancel()
        {
            string zipPath = Path.GetDirectoryName(_mapUpdateInfo.ZipPath);
            string yamlName = _mapUpdateInfo.FileName  + "_cancel.yaml";
            string yamlPath = Path.Combine(zipPath, yamlName);
            string copyPath = Path.Combine(_mapUpdateInfo.AgentPath, yamlPath);
            File.Copy(yamlPath, copyPath);
        }

        private void CreateYaml(string type)
        {
            string str = _mapUpdateInfo.Guid.ToString();
            string initialContent = "\nkey: " + str + "\n";

            var sr = new StringReader(initialContent);
            var stream = new YamlStream();
            stream.Load(sr);

            var rootMappingNode = (YamlMappingNode)stream.Documents[0].RootNode;

            rootMappingNode.Add("map_name", _mapUpdateInfo.MapName);

            if(type.ToLower() != "_cancel")
            {
                string dataKind = _mapUpdateInfo.MapName.Substring(0, 1);
                
                rootMappingNode.Add("data_kind", dataKind);
                rootMappingNode.Add("file_count", _dic_file.Count.ToString());

                var seq = new YamlSequenceNode();

                foreach (DictionaryEntry dic in _dic_file)
                {
                    var props = new YamlMappingNode();
                    string name = Path.GetFileName(dic.Key.ToString());
                    props.Add("name", name);
                    props.Add("size", dic.Value.ToString());
                    seq.Add(props);
                }
                rootMappingNode.Add("files", seq);
            }

            string zipPath = Path.GetDirectoryName(_mapUpdateInfo.ZipPath);
            string yamlName = _mapUpdateInfo.FileName  + type +".yaml";
            string yamlPath = Path.Combine(zipPath, yamlName);

            try
            {
                using (TextWriter writer = File.CreateText(yamlPath))
                {
                    stream.Save(writer, false);
                }

                if (type.ToLower() != "_cancel")
                {
                    FileInfo file = new FileInfo(yamlPath);
                    _dic_file.Insert(0, yamlPath, file.Length);
                    //_dic_file.Add(yaml_path, file.Length);
                }
            }
            catch(Exception ex)
            {

            }              
        }


        private void GetFiles(string path, OrderedDictionary dic)
        {    
            DirectoryInfo di = new DirectoryInfo(path);

            foreach (FileInfo file in di.GetFiles())
            {
                _dic_file.Add(file.FullName, file.Length);
                _totalFileSize += file.Length;
            }

            foreach (DirectoryInfo info in di.GetDirectories())
            {
                GetFiles(info.FullName, dic);
            }
        }


        #region 삭제예정

        private List<String> GetFileList(String rootPath, List<String> fileList)
        {// test
            if (fileList == null)
            {
                return null;
            }
            var attr = File.GetAttributes(rootPath);

            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                var dirInfo = new DirectoryInfo(rootPath);

                foreach (var dir in dirInfo.GetDirectories())
                {
                    GetFileList(dir.FullName, fileList);
                }
                foreach (var file in dirInfo.GetFiles())
                {
                    GetFileList(file.FullName, fileList);
                }
            }
            else
            {
                var fileInfo = new FileInfo(rootPath);
                fileList.Add(fileInfo.FullName);
            }
            return fileList;
        }



        #endregion
    }
}
