namespace JIMapTrans.DataUpdate
{
    partial class DataUpdateControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.UploadButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.InputPathTextBox = new System.Windows.Forms.TextBox();
            this.InputPathButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.MapDataGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MapTypeComboBox2 = new System.Windows.Forms.ComboBox();
            this.MapTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ModelGroupBox = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ModelTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CRSComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LocationComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.updateTotalProgressLabel = new System.Windows.Forms.Label();
            this.updateProgressLabel = new System.Windows.Forms.Label();
            this.totalProgressBar = new System.Windows.Forms.ProgressBar();
            this.updateInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.ipAddressControl = new IPAddressControlLib.IPAddressControl();
            this.label14 = new System.Windows.Forms.Label();
            this.SftpConnectionButton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.SftpPathTextBox = new System.Windows.Forms.TextBox();
            this.SftpPortTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.compressSizecUpDown = new System.Windows.Forms.NumericUpDown();
            this.SftpPwTextBox = new System.Windows.Forms.TextBox();
            this.SftpUserTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.AgentUploadRadioButton = new System.Windows.Forms.RadioButton();
            this.SftpUploadRadioButton = new System.Windows.Forms.RadioButton();
            this.outputButton = new System.Windows.Forms.Button();
            this.AgentPathTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SftpHostTextBox = new System.Windows.Forms.TextBox();
            this.ModelRadioButton = new System.Windows.Forms.RadioButton();
            this.MapDataRadioButton = new System.Windows.Forms.RadioButton();
            this.MapDataGroupBox.SuspendLayout();
            this.ModelGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.updateInfoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compressSizecUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // UploadButton
            // 
            this.UploadButton.Location = new System.Drawing.Point(392, 478);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(75, 23);
            this.UploadButton.TabIndex = 0;
            this.UploadButton.Text = "확인";
            this.UploadButton.UseVisualStyleBackColor = true;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "데이터 경로";
            // 
            // InputPathTextBox
            // 
            this.InputPathTextBox.Location = new System.Drawing.Point(111, 53);
            this.InputPathTextBox.Name = "InputPathTextBox";
            this.InputPathTextBox.Size = new System.Drawing.Size(344, 21);
            this.InputPathTextBox.TabIndex = 0;
            // 
            // InputPathButton
            // 
            this.InputPathButton.Location = new System.Drawing.Point(463, 51);
            this.InputPathButton.Name = "InputPathButton";
            this.InputPathButton.Size = new System.Drawing.Size(28, 23);
            this.InputPathButton.TabIndex = 8;
            this.InputPathButton.Text = "...";
            this.InputPathButton.UseVisualStyleBackColor = true;
            this.InputPathButton.Click += new System.EventHandler(this.InputPathButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(13, 381);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(506, 23);
            this.progressBar.TabIndex = 4;
            // 
            // MapDataGroupBox
            // 
            this.MapDataGroupBox.Controls.Add(this.label3);
            this.MapDataGroupBox.Controls.Add(this.label2);
            this.MapDataGroupBox.Controls.Add(this.MapTypeComboBox2);
            this.MapDataGroupBox.Controls.Add(this.MapTypeComboBox);
            this.MapDataGroupBox.Location = new System.Drawing.Point(14, 15);
            this.MapDataGroupBox.Name = "MapDataGroupBox";
            this.MapDataGroupBox.Size = new System.Drawing.Size(506, 68);
            this.MapDataGroupBox.TabIndex = 5;
            this.MapDataGroupBox.TabStop = false;
            this.MapDataGroupBox.Text = "지도 데이터";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "지도 종류";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "벡터/래스터";
            // 
            // MapTypeComboBox2
            // 
            this.MapTypeComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MapTypeComboBox2.FormattingEnabled = true;
            this.MapTypeComboBox2.Items.AddRange(new object[] {
            "G25K",
            "A250K",
            "KR1",
            "KR2",
            "KR3",
            "KR4",
            "KR5"});
            this.MapTypeComboBox2.Location = new System.Drawing.Point(322, 30);
            this.MapTypeComboBox2.Name = "MapTypeComboBox2";
            this.MapTypeComboBox2.Size = new System.Drawing.Size(121, 20);
            this.MapTypeComboBox2.TabIndex = 1;
            // 
            // MapTypeComboBox
            // 
            this.MapTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MapTypeComboBox.FormattingEnabled = true;
            this.MapTypeComboBox.Items.AddRange(new object[] {
            "vector",
            "raster"});
            this.MapTypeComboBox.Location = new System.Drawing.Point(110, 30);
            this.MapTypeComboBox.Name = "MapTypeComboBox";
            this.MapTypeComboBox.Size = new System.Drawing.Size(121, 20);
            this.MapTypeComboBox.TabIndex = 0;
            this.MapTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.MapTypeComboBox_SelectedIndexChanged);
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Location = new System.Drawing.Point(12, 355);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(53, 12);
            this.ProgressLabel.TabIndex = 6;
            this.ProgressLabel.Text = "진행상태";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(473, 478);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "취소";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ModelGroupBox
            // 
            this.ModelGroupBox.Controls.Add(this.label6);
            this.ModelGroupBox.Controls.Add(this.ModelTypeComboBox);
            this.ModelGroupBox.Controls.Add(this.label5);
            this.ModelGroupBox.Controls.Add(this.CRSComboBox);
            this.ModelGroupBox.Controls.Add(this.label4);
            this.ModelGroupBox.Controls.Add(this.LocationComboBox);
            this.ModelGroupBox.Location = new System.Drawing.Point(19, 479);
            this.ModelGroupBox.Name = "ModelGroupBox";
            this.ModelGroupBox.Size = new System.Drawing.Size(64, 22);
            this.ModelGroupBox.TabIndex = 8;
            this.ModelGroupBox.TabStop = false;
            this.ModelGroupBox.Text = "3D 모델";
            this.ModelGroupBox.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(272, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "구분";
            // 
            // ModelTypeComboBox
            // 
            this.ModelTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModelTypeComboBox.FormattingEnabled = true;
            this.ModelTypeComboBox.Location = new System.Drawing.Point(307, 31);
            this.ModelTypeComboBox.Name = "ModelTypeComboBox";
            this.ModelTypeComboBox.Size = new System.Drawing.Size(121, 20);
            this.ModelTypeComboBox.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "좌표계";
            // 
            // CRSComboBox
            // 
            this.CRSComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CRSComboBox.FormattingEnabled = true;
            this.CRSComboBox.Location = new System.Drawing.Point(110, 63);
            this.CRSComboBox.Name = "CRSComboBox";
            this.CRSComboBox.Size = new System.Drawing.Size(121, 20);
            this.CRSComboBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "지역";
            // 
            // LocationComboBox
            // 
            this.LocationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LocationComboBox.FormattingEnabled = true;
            this.LocationComboBox.Location = new System.Drawing.Point(110, 31);
            this.LocationComboBox.Name = "LocationComboBox";
            this.LocationComboBox.Size = new System.Drawing.Size(121, 20);
            this.LocationComboBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.updateTotalProgressLabel);
            this.groupBox3.Controls.Add(this.updateProgressLabel);
            this.groupBox3.Controls.Add(this.totalProgressBar);
            this.groupBox3.Controls.Add(this.updateInfoGroupBox);
            this.groupBox3.Controls.Add(this.ProgressLabel);
            this.groupBox3.Controls.Add(this.progressBar);
            this.groupBox3.Controls.Add(this.MapDataGroupBox);
            this.groupBox3.Location = new System.Drawing.Point(19, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(529, 457);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // updateTotalProgressLabel
            // 
            this.updateTotalProgressLabel.AutoSize = true;
            this.updateTotalProgressLabel.Location = new System.Drawing.Point(19, 426);
            this.updateTotalProgressLabel.Name = "updateTotalProgressLabel";
            this.updateTotalProgressLabel.Size = new System.Drawing.Size(21, 12);
            this.updateTotalProgressLabel.TabIndex = 14;
            this.updateTotalProgressLabel.Text = "0%";
            // 
            // updateProgressLabel
            // 
            this.updateProgressLabel.AutoSize = true;
            this.updateProgressLabel.Location = new System.Drawing.Point(19, 387);
            this.updateProgressLabel.Name = "updateProgressLabel";
            this.updateProgressLabel.Size = new System.Drawing.Size(21, 12);
            this.updateProgressLabel.TabIndex = 13;
            this.updateProgressLabel.Text = "0%";
            // 
            // totalProgressBar
            // 
            this.totalProgressBar.Location = new System.Drawing.Point(13, 421);
            this.totalProgressBar.Name = "totalProgressBar";
            this.totalProgressBar.Size = new System.Drawing.Size(506, 23);
            this.totalProgressBar.TabIndex = 12;
            // 
            // updateInfoGroupBox
            // 
            this.updateInfoGroupBox.Controls.Add(this.ipAddressControl);
            this.updateInfoGroupBox.Controls.Add(this.label14);
            this.updateInfoGroupBox.Controls.Add(this.SftpConnectionButton);
            this.updateInfoGroupBox.Controls.Add(this.label13);
            this.updateInfoGroupBox.Controls.Add(this.SftpPathTextBox);
            this.updateInfoGroupBox.Controls.Add(this.SftpPortTextBox);
            this.updateInfoGroupBox.Controls.Add(this.label12);
            this.updateInfoGroupBox.Controls.Add(this.compressSizecUpDown);
            this.updateInfoGroupBox.Controls.Add(this.SftpPwTextBox);
            this.updateInfoGroupBox.Controls.Add(this.SftpUserTextBox);
            this.updateInfoGroupBox.Controls.Add(this.label11);
            this.updateInfoGroupBox.Controls.Add(this.label10);
            this.updateInfoGroupBox.Controls.Add(this.label9);
            this.updateInfoGroupBox.Controls.Add(this.label8);
            this.updateInfoGroupBox.Controls.Add(this.AgentUploadRadioButton);
            this.updateInfoGroupBox.Controls.Add(this.SftpUploadRadioButton);
            this.updateInfoGroupBox.Controls.Add(this.outputButton);
            this.updateInfoGroupBox.Controls.Add(this.AgentPathTextBox);
            this.updateInfoGroupBox.Controls.Add(this.label7);
            this.updateInfoGroupBox.Controls.Add(this.label1);
            this.updateInfoGroupBox.Controls.Add(this.InputPathTextBox);
            this.updateInfoGroupBox.Controls.Add(this.InputPathButton);
            this.updateInfoGroupBox.Location = new System.Drawing.Point(13, 94);
            this.updateInfoGroupBox.Name = "updateInfoGroupBox";
            this.updateInfoGroupBox.Size = new System.Drawing.Size(506, 254);
            this.updateInfoGroupBox.TabIndex = 11;
            this.updateInfoGroupBox.TabStop = false;
            this.updateInfoGroupBox.Text = "업로드 설정";
            // 
            // ipAddressControl
            // 
            this.ipAddressControl.AllowInternalTab = false;
            this.ipAddressControl.AutoHeight = true;
            this.ipAddressControl.BackColor = System.Drawing.SystemColors.Window;
            this.ipAddressControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ipAddressControl.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipAddressControl.Enabled = false;
            this.ipAddressControl.Location = new System.Drawing.Point(111, 121);
            this.ipAddressControl.MinimumSize = new System.Drawing.Size(90, 21);
            this.ipAddressControl.Name = "ipAddressControl";
            this.ipAddressControl.ReadOnly = false;
            this.ipAddressControl.Size = new System.Drawing.Size(222, 21);
            this.ipAddressControl.TabIndex = 2;
            this.ipAddressControl.Text = "...";
            this.ipAddressControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ipAddressControl_KeyDown);
            this.ipAddressControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ipAddressControl_KeyPress);
            this.ipAddressControl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ipAddressControl_KeyUp);
            this.ipAddressControl.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ipAddressControl_PreviewKeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(236, 228);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 12);
            this.label14.TabIndex = 22;
            this.label14.Text = "MB(10~1000)";
            // 
            // SftpConnectionButton
            // 
            this.SftpConnectionButton.Enabled = false;
            this.SftpConnectionButton.Location = new System.Drawing.Point(337, 220);
            this.SftpConnectionButton.Name = "SftpConnectionButton";
            this.SftpConnectionButton.Size = new System.Drawing.Size(121, 23);
            this.SftpConnectionButton.TabIndex = 21;
            this.SftpConnectionButton.Text = "SFTP 연결 테스트";
            this.SftpConnectionButton.UseVisualStyleBackColor = true;
            this.SftpConnectionButton.Click += new System.EventHandler(this.SftpConnectionButton_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 192);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 12);
            this.label13.TabIndex = 20;
            this.label13.Text = "SFTP 경로";
            // 
            // SftpPathTextBox
            // 
            this.SftpPathTextBox.Enabled = false;
            this.SftpPathTextBox.Location = new System.Drawing.Point(111, 187);
            this.SftpPathTextBox.Name = "SftpPathTextBox";
            this.SftpPathTextBox.Size = new System.Drawing.Size(346, 21);
            this.SftpPathTextBox.TabIndex = 6;
            // 
            // SftpPortTextBox
            // 
            this.SftpPortTextBox.Enabled = false;
            this.SftpPortTextBox.Location = new System.Drawing.Point(382, 121);
            this.SftpPortTextBox.Name = "SftpPortTextBox";
            this.SftpPortTextBox.Size = new System.Drawing.Size(75, 21);
            this.SftpPortTextBox.TabIndex = 3;
            this.SftpPortTextBox.Text = "22";
            this.SftpPortTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SftpPortTextBox_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(349, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 12);
            this.label12.TabIndex = 17;
            this.label12.Text = "Port";
            // 
            // compressSizecUpDown
            // 
            this.compressSizecUpDown.Location = new System.Drawing.Point(111, 223);
            this.compressSizecUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.compressSizecUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.compressSizecUpDown.Name = "compressSizecUpDown";
            this.compressSizecUpDown.Size = new System.Drawing.Size(120, 21);
            this.compressSizecUpDown.TabIndex = 7;
            this.compressSizecUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // SftpPwTextBox
            // 
            this.SftpPwTextBox.Enabled = false;
            this.SftpPwTextBox.Location = new System.Drawing.Point(337, 154);
            this.SftpPwTextBox.Name = "SftpPwTextBox";
            this.SftpPwTextBox.PasswordChar = '*';
            this.SftpPwTextBox.Size = new System.Drawing.Size(120, 21);
            this.SftpPwTextBox.TabIndex = 5;
            // 
            // SftpUserTextBox
            // 
            this.SftpUserTextBox.Enabled = false;
            this.SftpUserTextBox.Location = new System.Drawing.Point(111, 154);
            this.SftpUserTextBox.Name = "SftpUserTextBox";
            this.SftpUserTextBox.Size = new System.Drawing.Size(120, 21);
            this.SftpUserTextBox.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 227);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 12);
            this.label11.TabIndex = 12;
            this.label11.Text = "분할  압축";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(245, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 12);
            this.label10.TabIndex = 11;
            this.label10.Text = "SFTP 비밀번호";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 12);
            this.label9.TabIndex = 10;
            this.label9.Text = "SFTP 계정";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "SFTP Host";
            // 
            // AgentUploadRadioButton
            // 
            this.AgentUploadRadioButton.AutoSize = true;
            this.AgentUploadRadioButton.Checked = true;
            this.AgentUploadRadioButton.Location = new System.Drawing.Point(21, 22);
            this.AgentUploadRadioButton.Name = "AgentUploadRadioButton";
            this.AgentUploadRadioButton.Size = new System.Drawing.Size(95, 16);
            this.AgentUploadRadioButton.TabIndex = 8;
            this.AgentUploadRadioButton.TabStop = true;
            this.AgentUploadRadioButton.Text = "Agent 동기화";
            this.AgentUploadRadioButton.UseVisualStyleBackColor = true;
            // 
            // SftpUploadRadioButton
            // 
            this.SftpUploadRadioButton.AutoSize = true;
            this.SftpUploadRadioButton.Location = new System.Drawing.Point(129, 22);
            this.SftpUploadRadioButton.Name = "SftpUploadRadioButton";
            this.SftpUploadRadioButton.Size = new System.Drawing.Size(94, 16);
            this.SftpUploadRadioButton.TabIndex = 8;
            this.SftpUploadRadioButton.Text = "SFTP 업로드";
            this.SftpUploadRadioButton.UseVisualStyleBackColor = true;
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(463, 84);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(28, 23);
            this.outputButton.TabIndex = 9;
            this.outputButton.Text = "...";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // AgentPathTextBox
            // 
            this.AgentPathTextBox.Location = new System.Drawing.Point(111, 86);
            this.AgentPathTextBox.Name = "AgentPathTextBox";
            this.AgentPathTextBox.Size = new System.Drawing.Size(346, 21);
            this.AgentPathTextBox.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "동기화 경로";
            // 
            // SftpHostTextBox
            // 
            this.SftpHostTextBox.Enabled = false;
            this.SftpHostTextBox.Location = new System.Drawing.Point(290, 487);
            this.SftpHostTextBox.Name = "SftpHostTextBox";
            this.SftpHostTextBox.Size = new System.Drawing.Size(30, 21);
            this.SftpHostTextBox.TabIndex = 2;
            this.SftpHostTextBox.Visible = false;
            // 
            // ModelRadioButton
            // 
            this.ModelRadioButton.AutoSize = true;
            this.ModelRadioButton.Location = new System.Drawing.Point(199, 488);
            this.ModelRadioButton.Name = "ModelRadioButton";
            this.ModelRadioButton.Size = new System.Drawing.Size(65, 16);
            this.ModelRadioButton.TabIndex = 10;
            this.ModelRadioButton.Text = "3D 모델";
            this.ModelRadioButton.UseVisualStyleBackColor = true;
            this.ModelRadioButton.Visible = false;
            // 
            // MapDataRadioButton
            // 
            this.MapDataRadioButton.AutoSize = true;
            this.MapDataRadioButton.Checked = true;
            this.MapDataRadioButton.Location = new System.Drawing.Point(89, 488);
            this.MapDataRadioButton.Name = "MapDataRadioButton";
            this.MapDataRadioButton.Size = new System.Drawing.Size(83, 16);
            this.MapDataRadioButton.TabIndex = 9;
            this.MapDataRadioButton.TabStop = true;
            this.MapDataRadioButton.Text = "지도데이터";
            this.MapDataRadioButton.UseVisualStyleBackColor = true;
            this.MapDataRadioButton.Visible = false;
            // 
            // DataUpdateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.UploadButton);
            this.Controls.Add(this.ModelGroupBox);
            this.Controls.Add(this.ModelRadioButton);
            this.Controls.Add(this.MapDataRadioButton);
            this.Controls.Add(this.SftpHostTextBox);
            this.Name = "DataUpdateControl";
            this.Size = new System.Drawing.Size(563, 519);
            this.MapDataGroupBox.ResumeLayout(false);
            this.MapDataGroupBox.PerformLayout();
            this.ModelGroupBox.ResumeLayout(false);
            this.ModelGroupBox.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.updateInfoGroupBox.ResumeLayout(false);
            this.updateInfoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compressSizecUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputPathTextBox;
        private System.Windows.Forms.Button InputPathButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.GroupBox MapDataGroupBox;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.GroupBox ModelGroupBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton ModelRadioButton;
        private System.Windows.Forms.RadioButton MapDataRadioButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox MapTypeComboBox2;
        private System.Windows.Forms.ComboBox MapTypeComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox LocationComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CRSComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ModelTypeComboBox;
        private System.Windows.Forms.GroupBox updateInfoGroupBox;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.TextBox AgentPathTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton AgentUploadRadioButton;
        private System.Windows.Forms.RadioButton SftpUploadRadioButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox SftpPwTextBox;
        private System.Windows.Forms.TextBox SftpUserTextBox;
        private System.Windows.Forms.TextBox SftpHostTextBox;
        private System.Windows.Forms.NumericUpDown compressSizecUpDown;
        private System.Windows.Forms.ProgressBar totalProgressBar;
        private System.Windows.Forms.Label updateProgressLabel;
        private System.Windows.Forms.Label updateTotalProgressLabel;
        private System.Windows.Forms.TextBox SftpPortTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox SftpPathTextBox;
        private System.Windows.Forms.Button SftpConnectionButton;
        private System.Windows.Forms.Label label14;
        private IPAddressControlLib.IPAddressControl ipAddressControl;
    }
}
