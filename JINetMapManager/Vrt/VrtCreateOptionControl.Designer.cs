namespace JIMapTrans.Vrt
{
    partial class VrtCreateOptionControl
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
            this.label1 = new System.Windows.Forms.Label();
            this._resolutionComboBox = new System.Windows.Forms.ComboBox();
            this._separateCheckBox = new System.Windows.Forms.CheckBox();
            this._allowPrjDiffCheckBox = new System.Windows.Forms.CheckBox();
            this._addAlphaCheckBox = new System.Windows.Forms.CheckBox();
            this._resamplingAlgComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._additionalOptionsTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._nodataValTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Resolution";
            // 
            // _resolutionComboBox
            // 
            this._resolutionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._resolutionComboBox.FormattingEnabled = true;
            this._resolutionComboBox.Location = new System.Drawing.Point(76, 20);
            this._resolutionComboBox.Name = "_resolutionComboBox";
            this._resolutionComboBox.Size = new System.Drawing.Size(426, 20);
            this._resolutionComboBox.TabIndex = 1;
            // 
            // _separateCheckBox
            // 
            this._separateCheckBox.AutoSize = true;
            this._separateCheckBox.Location = new System.Drawing.Point(8, 50);
            this._separateCheckBox.Name = "_separateCheckBox";
            this._separateCheckBox.Size = new System.Drawing.Size(276, 16);
            this._separateCheckBox.TabIndex = 2;
            this._separateCheckBox.Text = "각각의 입력 파일을 독립된 밴드로 분리합니다.";
            this._separateCheckBox.UseVisualStyleBackColor = true;
            // 
            // _allowPrjDiffCheckBox
            // 
            this._allowPrjDiffCheckBox.AutoSize = true;
            this._allowPrjDiffCheckBox.Location = new System.Drawing.Point(8, 72);
            this._allowPrjDiffCheckBox.Name = "_allowPrjDiffCheckBox";
            this._allowPrjDiffCheckBox.Size = new System.Drawing.Size(336, 16);
            this._allowPrjDiffCheckBox.TabIndex = 3;
            this._allowPrjDiffCheckBox.Text = "입력 데이터들의 프로젝션이 달라도 무시하고 진행합니다.";
            this._allowPrjDiffCheckBox.UseVisualStyleBackColor = true;
            // 
            // _addAlphaCheckBox
            // 
            this._addAlphaCheckBox.AutoSize = true;
            this._addAlphaCheckBox.Location = new System.Drawing.Point(8, 22);
            this._addAlphaCheckBox.Name = "_addAlphaCheckBox";
            this._addAlphaCheckBox.Size = new System.Drawing.Size(302, 16);
            this._addAlphaCheckBox.TabIndex = 4;
            this._addAlphaCheckBox.Text = "생성되는 VRT 에 alpha mask band 를 추가합니다.";
            this._addAlphaCheckBox.UseVisualStyleBackColor = true;
            // 
            // _resamplingAlgComboBox
            // 
            this._resamplingAlgComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._resamplingAlgComboBox.FormattingEnabled = true;
            this._resamplingAlgComboBox.Location = new System.Drawing.Point(84, 44);
            this._resamplingAlgComboBox.Name = "_resamplingAlgComboBox";
            this._resamplingAlgComboBox.Size = new System.Drawing.Size(418, 20);
            this._resamplingAlgComboBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Resampling";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nodata value for input band(s)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "추가 옵션 입력";
            // 
            // _additionalOptionsTextBox
            // 
            this._additionalOptionsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._additionalOptionsTextBox.Location = new System.Drawing.Point(97, 20);
            this._additionalOptionsTextBox.Name = "_additionalOptionsTextBox";
            this._additionalOptionsTextBox.Size = new System.Drawing.Size(405, 21);
            this._additionalOptionsTextBox.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this._resolutionComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._separateCheckBox);
            this.groupBox1.Controls.Add(this._allowPrjDiffCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 99);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this._nodataValTextBox);
            this.groupBox2.Controls.Add(this._resamplingAlgComboBox);
            this.groupBox2.Controls.Add(this._addAlphaCheckBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(3, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(508, 100);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this._additionalOptionsTextBox);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(3, 214);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(508, 57);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            // 
            // _nodataValTextBox
            // 
            this._nodataValTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._nodataValTextBox.Location = new System.Drawing.Point(189, 70);
            this._nodataValTextBox.Name = "_nodataValTextBox";
            this._nodataValTextBox.Size = new System.Drawing.Size(313, 21);
            this._nodataValTextBox.TabIndex = 29;
            // 
            // VrtCreateOptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "VrtCreateOptionControl";
            this.Size = new System.Drawing.Size(514, 453);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _resolutionComboBox;
        private System.Windows.Forms.CheckBox _separateCheckBox;
        private System.Windows.Forms.CheckBox _allowPrjDiffCheckBox;
        private System.Windows.Forms.CheckBox _addAlphaCheckBox;
        private System.Windows.Forms.ComboBox _resamplingAlgComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _additionalOptionsTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox _nodataValTextBox;
    }
}
