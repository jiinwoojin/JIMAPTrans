namespace JIMapTrans.Vrt
{
    partial class VrtCreateControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._timerLabel = new System.Windows.Forms.Label();
            this._progressStateLabel = new System.Windows.Forms.Label();
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._cancelConvertButton = new System.Windows.Forms.Button();
            this._createButton = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 100);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "경로 설정";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Location = new System.Drawing.Point(3, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(495, 273);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "VRT 생성 옵션";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this._timerLabel);
            this.groupBox3.Controls.Add(this._progressStateLabel);
            this.groupBox3.Controls.Add(this._progressBar);
            this.groupBox3.Location = new System.Drawing.Point(3, 381);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(495, 80);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            // 
            // _timerLabel
            // 
            this._timerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._timerLabel.AutoSize = true;
            this._timerLabel.Location = new System.Drawing.Point(419, 62);
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
            this._progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._progressBar.Location = new System.Drawing.Point(10, 32);
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(474, 23);
            this._progressBar.TabIndex = 0;
            // 
            // _cancelConvertButton
            // 
            this._cancelConvertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelConvertButton.Location = new System.Drawing.Point(423, 467);
            this._cancelConvertButton.Name = "_cancelConvertButton";
            this._cancelConvertButton.Size = new System.Drawing.Size(75, 23);
            this._cancelConvertButton.TabIndex = 23;
            this._cancelConvertButton.Text = "취소";
            this._cancelConvertButton.UseVisualStyleBackColor = true;
            this._cancelConvertButton.Click += new System.EventHandler(this._cancelConvertButton_Click);
            // 
            // _createButton
            // 
            this._createButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._createButton.Location = new System.Drawing.Point(342, 467);
            this._createButton.Name = "_createButton";
            this._createButton.Size = new System.Drawing.Size(75, 23);
            this._createButton.TabIndex = 22;
            this._createButton.Text = "생성";
            this._createButton.UseVisualStyleBackColor = true;
            this._createButton.Click += new System.EventHandler(this._createButton_Click);
            // 
            // VrtCreateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._cancelConvertButton);
            this.Controls.Add(this._createButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "VrtCreateControl";
            this.Size = new System.Drawing.Size(501, 493);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label _timerLabel;
        private System.Windows.Forms.Label _progressStateLabel;
        private System.Windows.Forms.ProgressBar _progressBar;
        private System.Windows.Forms.Button _cancelConvertButton;
        private System.Windows.Forms.Button _createButton;
    }
}
