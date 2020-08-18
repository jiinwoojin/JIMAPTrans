namespace JIMapTrans.Overview
{
    partial class OverviewCreateOptionControl
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
            this._overviewFormatComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this._overviewResamplingComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._level2CheckBox = new System.Windows.Forms.CheckBox();
            this._level4CheckBox = new System.Windows.Forms.CheckBox();
            this._level16CeckBox = new System.Windows.Forms.CheckBox();
            this._level8CheckBox = new System.Windows.Forms.CheckBox();
            this._level64CheckBox = new System.Windows.Forms.CheckBox();
            this._level32CheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this._profilesComboBox = new System.Windows.Forms.ComboBox();
            this._creationOptionsTextBox = new System.Windows.Forms.TextBox();
            this._levelsPanel = new System.Windows.Forms.Panel();
            this._calcLevelsCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._levelsPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _overviewFormatComboBox
            // 
            this._overviewFormatComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._overviewFormatComboBox.FormattingEnabled = true;
            this._overviewFormatComboBox.Location = new System.Drawing.Point(84, 17);
            this._overviewFormatComboBox.Name = "_overviewFormatComboBox";
            this._overviewFormatComboBox.Size = new System.Drawing.Size(424, 20);
            this._overviewFormatComboBox.TabIndex = 7;
            this._overviewFormatComboBox.SelectedIndexChanged += new System.EventHandler(this._overviewFormatComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "오버뷰 포맷";
            // 
            // _overviewResamplingComboBox
            // 
            this._overviewResamplingComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._overviewResamplingComboBox.FormattingEnabled = true;
            this._overviewResamplingComboBox.Location = new System.Drawing.Point(84, 46);
            this._overviewResamplingComboBox.Name = "_overviewResamplingComboBox";
            this._overviewResamplingComboBox.Size = new System.Drawing.Size(424, 20);
            this._overviewResamplingComboBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Resampling";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "레벨";
            // 
            // _level2CheckBox
            // 
            this._level2CheckBox.AutoSize = true;
            this._level2CheckBox.Location = new System.Drawing.Point(3, 3);
            this._level2CheckBox.Name = "_level2CheckBox";
            this._level2CheckBox.Size = new System.Drawing.Size(30, 16);
            this._level2CheckBox.TabIndex = 9;
            this._level2CheckBox.Text = "2";
            this._level2CheckBox.UseVisualStyleBackColor = true;
            // 
            // _level4CheckBox
            // 
            this._level4CheckBox.AutoSize = true;
            this._level4CheckBox.Location = new System.Drawing.Point(39, 3);
            this._level4CheckBox.Name = "_level4CheckBox";
            this._level4CheckBox.Size = new System.Drawing.Size(30, 16);
            this._level4CheckBox.TabIndex = 10;
            this._level4CheckBox.Text = "4";
            this._level4CheckBox.UseVisualStyleBackColor = true;
            // 
            // _level16CeckBox
            // 
            this._level16CeckBox.AutoSize = true;
            this._level16CeckBox.Location = new System.Drawing.Point(111, 3);
            this._level16CeckBox.Name = "_level16CeckBox";
            this._level16CeckBox.Size = new System.Drawing.Size(36, 16);
            this._level16CeckBox.TabIndex = 12;
            this._level16CeckBox.Text = "16";
            this._level16CeckBox.UseVisualStyleBackColor = true;
            // 
            // _level8CheckBox
            // 
            this._level8CheckBox.AutoSize = true;
            this._level8CheckBox.Location = new System.Drawing.Point(75, 3);
            this._level8CheckBox.Name = "_level8CheckBox";
            this._level8CheckBox.Size = new System.Drawing.Size(30, 16);
            this._level8CheckBox.TabIndex = 11;
            this._level8CheckBox.Text = "8";
            this._level8CheckBox.UseVisualStyleBackColor = true;
            // 
            // _level64CheckBox
            // 
            this._level64CheckBox.AutoSize = true;
            this._level64CheckBox.Location = new System.Drawing.Point(195, 3);
            this._level64CheckBox.Name = "_level64CheckBox";
            this._level64CheckBox.Size = new System.Drawing.Size(36, 16);
            this._level64CheckBox.TabIndex = 14;
            this._level64CheckBox.Text = "64";
            this._level64CheckBox.UseVisualStyleBackColor = true;
            // 
            // _level32CheckBox
            // 
            this._level32CheckBox.AutoSize = true;
            this._level32CheckBox.Location = new System.Drawing.Point(153, 3);
            this._level32CheckBox.Name = "_level32CheckBox";
            this._level32CheckBox.Size = new System.Drawing.Size(36, 16);
            this._level32CheckBox.TabIndex = 13;
            this._level32CheckBox.Text = "32";
            this._level32CheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "프로필";
            // 
            // _profilesComboBox
            // 
            this._profilesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._profilesComboBox.FormattingEnabled = true;
            this._profilesComboBox.Location = new System.Drawing.Point(53, 18);
            this._profilesComboBox.Name = "_profilesComboBox";
            this._profilesComboBox.Size = new System.Drawing.Size(455, 20);
            this._profilesComboBox.TabIndex = 16;
            this._profilesComboBox.SelectedIndexChanged += new System.EventHandler(this._profilesComboBox_SelectedIndexChanged);
            // 
            // _creationOptionsTextBox
            // 
            this._creationOptionsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._creationOptionsTextBox.Location = new System.Drawing.Point(8, 44);
            this._creationOptionsTextBox.Name = "_creationOptionsTextBox";
            this._creationOptionsTextBox.Size = new System.Drawing.Size(500, 21);
            this._creationOptionsTextBox.TabIndex = 17;
            // 
            // _levelsPanel
            // 
            this._levelsPanel.Controls.Add(this._calcLevelsCheckBox);
            this._levelsPanel.Controls.Add(this._level2CheckBox);
            this._levelsPanel.Controls.Add(this._level4CheckBox);
            this._levelsPanel.Controls.Add(this._level8CheckBox);
            this._levelsPanel.Controls.Add(this._level16CeckBox);
            this._levelsPanel.Controls.Add(this._level64CheckBox);
            this._levelsPanel.Controls.Add(this._level32CheckBox);
            this._levelsPanel.Location = new System.Drawing.Point(84, 76);
            this._levelsPanel.Name = "_levelsPanel";
            this._levelsPanel.Size = new System.Drawing.Size(314, 26);
            this._levelsPanel.TabIndex = 18;
            // 
            // _calcLevelsCheckBox
            // 
            this._calcLevelsCheckBox.AutoSize = true;
            this._calcLevelsCheckBox.Location = new System.Drawing.Point(237, 3);
            this._calcLevelsCheckBox.Name = "_calcLevelsCheckBox";
            this._calcLevelsCheckBox.Size = new System.Drawing.Size(72, 16);
            this._calcLevelsCheckBox.TabIndex = 15;
            this._calcLevelsCheckBox.Text = "자동계산";
            this._calcLevelsCheckBox.UseVisualStyleBackColor = true;
            this._calcLevelsCheckBox.CheckedChanged += new System.EventHandler(this._calcLevelsCheckBox_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._levelsPanel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._overviewResamplingComboBox);
            this.groupBox1.Controls.Add(this._overviewFormatComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 114);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this._profilesComboBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this._creationOptionsTextBox);
            this.groupBox2.Location = new System.Drawing.Point(3, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(516, 77);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            // 
            // OverviewCreateOptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "OverviewCreateOptionControl";
            this.Size = new System.Drawing.Size(524, 265);
            this._levelsPanel.ResumeLayout(false);
            this._levelsPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox _overviewFormatComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox _overviewResamplingComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox _level2CheckBox;
        private System.Windows.Forms.CheckBox _level4CheckBox;
        private System.Windows.Forms.CheckBox _level16CeckBox;
        private System.Windows.Forms.CheckBox _level8CheckBox;
        private System.Windows.Forms.CheckBox _level64CheckBox;
        private System.Windows.Forms.CheckBox _level32CheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox _profilesComboBox;
        private System.Windows.Forms.TextBox _creationOptionsTextBox;
        private System.Windows.Forms.Panel _levelsPanel;
        private System.Windows.Forms.CheckBox _calcLevelsCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
