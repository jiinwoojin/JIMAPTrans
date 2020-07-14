namespace JIMapTrans.Vrt
{
    partial class VrtCreatePathSettingControl
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
            this.label3 = new System.Windows.Forms.Label();
            this._inputFileFormatComboBox = new System.Windows.Forms.ComboBox();
            this._outputPathButton = new System.Windows.Forms.Button();
            this._fileTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this._inputTextBox = new System.Windows.Forms.TextBox();
            this._directoryTypeRadioButton = new System.Windows.Forms.RadioButton();
            this._inputPathButton = new System.Windows.Forms.Button();
            this._outputTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(365, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 12);
            this.label3.TabIndex = 37;
            this.label3.Text = "입력 파일 형식";
            // 
            // _inputFileFormatComboBox
            // 
            this._inputFileFormatComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._inputFileFormatComboBox.DropDownWidth = 200;
            this._inputFileFormatComboBox.FormattingEnabled = true;
            this._inputFileFormatComboBox.Location = new System.Drawing.Point(456, 2);
            this._inputFileFormatComboBox.Name = "_inputFileFormatComboBox";
            this._inputFileFormatComboBox.Size = new System.Drawing.Size(125, 20);
            this._inputFileFormatComboBox.TabIndex = 36;
            // 
            // _outputPathButton
            // 
            this._outputPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._outputPathButton.Location = new System.Drawing.Point(587, 54);
            this._outputPathButton.Name = "_outputPathButton";
            this._outputPathButton.Size = new System.Drawing.Size(27, 23);
            this._outputPathButton.TabIndex = 33;
            this._outputPathButton.Text = "...";
            this._outputPathButton.UseVisualStyleBackColor = true;
            this._outputPathButton.Click += new System.EventHandler(this._outputPathButton_Click);
            // 
            // _fileTypeRadioButton
            // 
            this._fileTypeRadioButton.AutoSize = true;
            this._fileTypeRadioButton.Location = new System.Drawing.Point(95, 3);
            this._fileTypeRadioButton.Name = "_fileTypeRadioButton";
            this._fileTypeRadioButton.Size = new System.Drawing.Size(75, 16);
            this._fileTypeRadioButton.TabIndex = 34;
            this._fileTypeRadioButton.TabStop = true;
            this._fileTypeRadioButton.Text = "TXT 선택";
            this._fileTypeRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 12);
            this.label1.TabIndex = 29;
            this.label1.Text = "입력 TXT 경로";
            // 
            // _inputTextBox
            // 
            this._inputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._inputTextBox.Location = new System.Drawing.Point(95, 27);
            this._inputTextBox.Name = "_inputTextBox";
            this._inputTextBox.Size = new System.Drawing.Size(487, 21);
            this._inputTextBox.TabIndex = 28;
            // 
            // _directoryTypeRadioButton
            // 
            this._directoryTypeRadioButton.AutoSize = true;
            this._directoryTypeRadioButton.Location = new System.Drawing.Point(176, 3);
            this._directoryTypeRadioButton.Name = "_directoryTypeRadioButton";
            this._directoryTypeRadioButton.Size = new System.Drawing.Size(75, 16);
            this._directoryTypeRadioButton.TabIndex = 35;
            this._directoryTypeRadioButton.TabStop = true;
            this._directoryTypeRadioButton.Text = "폴더 선택";
            this._directoryTypeRadioButton.UseVisualStyleBackColor = true;
            // 
            // _inputPathButton
            // 
            this._inputPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._inputPathButton.Location = new System.Drawing.Point(587, 25);
            this._inputPathButton.Name = "_inputPathButton";
            this._inputPathButton.Size = new System.Drawing.Size(27, 23);
            this._inputPathButton.TabIndex = 32;
            this._inputPathButton.Text = "...";
            this._inputPathButton.UseVisualStyleBackColor = true;
            this._inputPathButton.Click += new System.EventHandler(this._inputPathButton_Click);
            // 
            // _outputTextBox
            // 
            this._outputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._outputTextBox.Location = new System.Drawing.Point(95, 54);
            this._outputTextBox.Name = "_outputTextBox";
            this._outputTextBox.Size = new System.Drawing.Size(487, 21);
            this._outputTextBox.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "출력 파일 경로";
            // 
            // VrtCreatePathSettingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this._inputFileFormatComboBox);
            this.Controls.Add(this._outputPathButton);
            this.Controls.Add(this._fileTypeRadioButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._inputTextBox);
            this.Controls.Add(this._directoryTypeRadioButton);
            this.Controls.Add(this._inputPathButton);
            this.Controls.Add(this._outputTextBox);
            this.Controls.Add(this.label2);
            this.Name = "VrtCreatePathSettingControl";
            this.Size = new System.Drawing.Size(617, 85);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox _inputFileFormatComboBox;
        private System.Windows.Forms.Button _outputPathButton;
        private System.Windows.Forms.RadioButton _fileTypeRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _inputTextBox;
        private System.Windows.Forms.RadioButton _directoryTypeRadioButton;
        private System.Windows.Forms.Button _inputPathButton;
        private System.Windows.Forms.TextBox _outputTextBox;
        private System.Windows.Forms.Label label2;
    }
}
