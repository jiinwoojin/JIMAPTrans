namespace JIMapTrans.Logger
{
    partial class LoggerControl
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
            this._logViewRichTextBox = new System.Windows.Forms.RichTextBox();
            this._clearLogButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _logViewRichTextBox
            // 
            this._logViewRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._logViewRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._logViewRichTextBox.Location = new System.Drawing.Point(2, 8);
            this._logViewRichTextBox.Margin = new System.Windows.Forms.Padding(0);
            this._logViewRichTextBox.Name = "_logViewRichTextBox";
            this._logViewRichTextBox.Size = new System.Drawing.Size(588, 100);
            this._logViewRichTextBox.TabIndex = 0;
            this._logViewRichTextBox.Text = "";
            // 
            // _clearLogButton
            // 
            this._clearLogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._clearLogButton.Location = new System.Drawing.Point(485, 124);
            this._clearLogButton.Name = "_clearLogButton";
            this._clearLogButton.Size = new System.Drawing.Size(106, 23);
            this._clearLogButton.TabIndex = 1;
            this._clearLogButton.Text = "로그화면 초기화";
            this._clearLogButton.UseVisualStyleBackColor = true;
            this._clearLogButton.Click += new System.EventHandler(this._clearLogButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this._clearLogButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 150);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "로그";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this._logViewRichTextBox);
            this.groupBox2.Location = new System.Drawing.Point(3, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox2.Size = new System.Drawing.Size(591, 110);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // LoggerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "LoggerControl";
            this.Size = new System.Drawing.Size(597, 150);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox _logViewRichTextBox;
        private System.Windows.Forms.Button _clearLogButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
