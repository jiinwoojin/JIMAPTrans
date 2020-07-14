namespace JIMapTrans.MapConvert
{
    partial class MapConvertOptionControl
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
            this._mapConvertProfileComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this._descriptionTextBox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this._additionalOptionsTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._outputDataTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this._xSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._ySizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._outsizeByPercentageCheckBox = new System.Windows.Forms.CheckBox();
            this._xSizeLabel = new System.Windows.Forms.Label();
            this._ySizeLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._xSizeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ySizeNumericUpDown)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mapConvertProfileComboBox
            // 
            this._mapConvertProfileComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._mapConvertProfileComboBox.FormattingEnabled = true;
            this._mapConvertProfileComboBox.Location = new System.Drawing.Point(50, 14);
            this._mapConvertProfileComboBox.Name = "_mapConvertProfileComboBox";
            this._mapConvertProfileComboBox.Size = new System.Drawing.Size(439, 20);
            this._mapConvertProfileComboBox.TabIndex = 1;
            this._mapConvertProfileComboBox.SelectedIndexChanged += new System.EventHandler(this._mapConvertProfileComboBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._descriptionTextBox);
            this.groupBox1.Controls.Add(this._mapConvertProfileComboBox);
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 406);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "프로필";
            // 
            // _descriptionTextBox
            // 
            this._descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._descriptionTextBox.Location = new System.Drawing.Point(3, 326);
            this._descriptionTextBox.Multiline = true;
            this._descriptionTextBox.Name = "_descriptionTextBox";
            this._descriptionTextBox.ReadOnly = true;
            this._descriptionTextBox.Size = new System.Drawing.Size(483, 74);
            this._descriptionTextBox.TabIndex = 7;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 40);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(486, 280);
            this.splitContainer1.SplitterDistance = 229;
            this.splitContainer1.TabIndex = 21;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(229, 280);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkedListBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 280);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "옵션 선택";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(3, 17);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(247, 260);
            this.checkedListBox1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this._ySizeLabel);
            this.groupBox3.Controls.Add(this._outputDataTypeComboBox);
            this.groupBox3.Controls.Add(this._ySizeNumericUpDown);
            this.groupBox3.Controls.Add(this._xSizeLabel);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this._outsizeByPercentageCheckBox);
            this.groupBox3.Controls.Add(this._xSizeNumericUpDown);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(3, 410);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(492, 95);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "추가 옵션 입력";
            // 
            // _additionalOptionsTextBox
            // 
            this._additionalOptionsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._additionalOptionsTextBox.Location = new System.Drawing.Point(99, 16);
            this._additionalOptionsTextBox.Name = "_additionalOptionsTextBox";
            this._additionalOptionsTextBox.Size = new System.Drawing.Size(390, 21);
            this._additionalOptionsTextBox.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "출력 데이터형";
            // 
            // _outputDataTypeComboBox
            // 
            this._outputDataTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._outputDataTypeComboBox.FormattingEnabled = true;
            this._outputDataTypeComboBox.Location = new System.Drawing.Point(99, 17);
            this._outputDataTypeComboBox.Name = "_outputDataTypeComboBox";
            this._outputDataTypeComboBox.Size = new System.Drawing.Size(387, 20);
            this._outputDataTypeComboBox.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "변환 파일 크기";
            // 
            // _xSizeNumericUpDown
            // 
            this._xSizeNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._xSizeNumericUpDown.Location = new System.Drawing.Point(114, 42);
            this._xSizeNumericUpDown.Name = "_xSizeNumericUpDown";
            this._xSizeNumericUpDown.Size = new System.Drawing.Size(261, 21);
            this._xSizeNumericUpDown.TabIndex = 28;
            // 
            // _ySizeNumericUpDown
            // 
            this._ySizeNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._ySizeNumericUpDown.Location = new System.Drawing.Point(114, 65);
            this._ySizeNumericUpDown.Name = "_ySizeNumericUpDown";
            this._ySizeNumericUpDown.Size = new System.Drawing.Size(261, 21);
            this._ySizeNumericUpDown.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 12);
            this.label5.TabIndex = 30;
            this.label5.Text = "X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(97, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 12);
            this.label6.TabIndex = 31;
            this.label6.Text = "Y";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this._additionalOptionsTextBox);
            this.groupBox4.Location = new System.Drawing.Point(3, 507);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(492, 46);
            this.groupBox4.TabIndex = 32;
            this.groupBox4.TabStop = false;
            // 
            // _outsizeByPercentageCheckBox
            // 
            this._outsizeByPercentageCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._outsizeByPercentageCheckBox.AutoSize = true;
            this._outsizeByPercentageCheckBox.Location = new System.Drawing.Point(398, 45);
            this._outsizeByPercentageCheckBox.Name = "_outsizeByPercentageCheckBox";
            this._outsizeByPercentageCheckBox.Size = new System.Drawing.Size(88, 16);
            this._outsizeByPercentageCheckBox.TabIndex = 32;
            this._outsizeByPercentageCheckBox.Text = "비율로 조정";
            this._outsizeByPercentageCheckBox.UseVisualStyleBackColor = true;
            this._outsizeByPercentageCheckBox.CheckedChanged += new System.EventHandler(this._outsizeByPercentageCheckBox_CheckedChanged);
            // 
            // _xSizeLabel
            // 
            this._xSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._xSizeLabel.AutoSize = true;
            this._xSizeLabel.Location = new System.Drawing.Point(377, 46);
            this._xSizeLabel.Name = "_xSizeLabel";
            this._xSizeLabel.Size = new System.Drawing.Size(0, 12);
            this._xSizeLabel.TabIndex = 33;
            // 
            // _ySizeLabel
            // 
            this._ySizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._ySizeLabel.AutoSize = true;
            this._ySizeLabel.Location = new System.Drawing.Point(377, 69);
            this._ySizeLabel.Name = "_ySizeLabel";
            this._ySizeLabel.Size = new System.Drawing.Size(0, 12);
            this._ySizeLabel.TabIndex = 34;
            // 
            // MapConvertOptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "MapConvertOptionControl";
            this.Size = new System.Drawing.Size(498, 556);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._xSizeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ySizeNumericUpDown)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox _mapConvertProfileComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TextBox _descriptionTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _outputDataTypeComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _additionalOptionsTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown _ySizeNumericUpDown;
        private System.Windows.Forms.NumericUpDown _xSizeNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox _outsizeByPercentageCheckBox;
        private System.Windows.Forms.Label _ySizeLabel;
        private System.Windows.Forms.Label _xSizeLabel;
    }
}
