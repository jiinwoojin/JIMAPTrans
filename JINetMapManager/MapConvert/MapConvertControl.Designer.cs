namespace JIMapTrans.MapConvert
{
    partial class MapConvertControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._cancelConvertButton = new System.Windows.Forms.Button();
            this._convertButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this._timerLabel = new System.Windows.Forms.Label();
            this._progressStateLabel = new System.Windows.Forms.Label();
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cancelConvertButton
            // 
            this._cancelConvertButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelConvertButton.Location = new System.Drawing.Point(499, 493);
            this._cancelConvertButton.Name = "_cancelConvertButton";
            this._cancelConvertButton.Size = new System.Drawing.Size(75, 23);
            this._cancelConvertButton.TabIndex = 12;
            this._cancelConvertButton.Text = "취소";
            this._cancelConvertButton.UseVisualStyleBackColor = true;
            this._cancelConvertButton.Click += new System.EventHandler(this._cancelConvertButton_Click);
            // 
            // _convertButton
            // 
            this._convertButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._convertButton.Location = new System.Drawing.Point(418, 493);
            this._convertButton.Name = "_convertButton";
            this._convertButton.Size = new System.Drawing.Size(75, 23);
            this._convertButton.TabIndex = 7;
            this._convertButton.Text = "변환";
            this._convertButton.UseVisualStyleBackColor = true;
            this._convertButton.Click += new System.EventHandler(this._convertButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Controls.Add(this._timerLabel);
            this.groupBox3.Controls.Add(this._progressStateLabel);
            this.groupBox3.Controls.Add(this._progressBar);
            this.groupBox3.Location = new System.Drawing.Point(3, 370);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(571, 117);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "/";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(10, 61);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(550, 23);
            this.progressBar1.TabIndex = 14;
            // 
            // _timerLabel
            // 
            this._timerLabel.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._timerLabel.AutoSize = true;
            this._timerLabel.Location = new System.Drawing.Point(495, 91);
            this._timerLabel.Name = "_timerLabel";
            this._timerLabel.Size = new System.Drawing.Size(0, 12);
            this._timerLabel.TabIndex = 13;
            // 
            // _progressStateLabel
            // 
            this._progressStateLabel.AutoSize = true;
            this._progressStateLabel.Location = new System.Drawing.Point(9, 17);
            this._progressStateLabel.Name = "_progressStateLabel";
            this._progressStateLabel.Size = new System.Drawing.Size(21, 12);
            this._progressStateLabel.TabIndex = 11;
            this._progressStateLabel.Text = "0%";
            // 
            // _progressBar
            // 
            this._progressBar.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this._progressBar.Location = new System.Drawing.Point(10, 32);
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(550, 23);
            this._progressBar.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 100);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "경로 설정";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Location = new System.Drawing.Point(3, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(571, 264);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "변환 파일 옵션";
            // 
            // MapConvertControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this._cancelConvertButton);
            this.Controls.Add(this._convertButton);
            this.Name = "MapConvertControl";
            this.Size = new System.Drawing.Size(577, 519);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button _cancelConvertButton;
        private System.Windows.Forms.Button _convertButton;
        private System.Windows.Forms.ProgressBar _progressBar;
        private System.Windows.Forms.Label _progressStateLabel;
        private System.Windows.Forms.Label _timerLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar1;

        #endregion
    }
}
