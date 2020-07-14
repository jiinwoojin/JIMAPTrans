namespace JIMapTrans.Overview
{
    partial class OverviewCreateControl
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._progressStateLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this._timerLabel = new System.Windows.Forms.Label();
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._cancelCreateOverviewButton = new System.Windows.Forms.Button();
            this._createOverviewButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 79);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "경로 설정";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this._progressStateLabel);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Controls.Add(this._timerLabel);
            this.groupBox3.Controls.Add(this._progressBar);
            this.groupBox3.Location = new System.Drawing.Point(3, 266);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(423, 117);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            // 
            // _progressStateLabel
            // 
            this._progressStateLabel.AutoSize = true;
            this._progressStateLabel.BackColor = System.Drawing.Color.Transparent;
            this._progressStateLabel.Location = new System.Drawing.Point(11, 17);
            this._progressStateLabel.Name = "_progressStateLabel";
            this._progressStateLabel.Size = new System.Drawing.Size(21, 12);
            this._progressStateLabel.TabIndex = 11;
            this._progressStateLabel.Text = "0%";
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
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(9, 61);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(404, 23);
            this.progressBar1.TabIndex = 14;
            // 
            // _timerLabel
            // 
            this._timerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._timerLabel.AutoSize = true;
            this._timerLabel.Location = new System.Drawing.Point(348, 91);
            this._timerLabel.Name = "_timerLabel";
            this._timerLabel.Size = new System.Drawing.Size(0, 12);
            this._timerLabel.TabIndex = 13;
            this._timerLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _progressBar
            // 
            this._progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._progressBar.Location = new System.Drawing.Point(9, 32);
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(404, 23);
            this._progressBar.TabIndex = 0;
            // 
            // _cancelCreateOverviewButton
            // 
            this._cancelCreateOverviewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelCreateOverviewButton.Location = new System.Drawing.Point(351, 389);
            this._cancelCreateOverviewButton.Name = "_cancelCreateOverviewButton";
            this._cancelCreateOverviewButton.Size = new System.Drawing.Size(75, 23);
            this._cancelCreateOverviewButton.TabIndex = 17;
            this._cancelCreateOverviewButton.Text = "취소";
            this._cancelCreateOverviewButton.UseVisualStyleBackColor = true;
            this._cancelCreateOverviewButton.Click += new System.EventHandler(this._cancelCreateOverviewButton_Click);
            // 
            // _createOverviewButton
            // 
            this._createOverviewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._createOverviewButton.Location = new System.Drawing.Point(270, 389);
            this._createOverviewButton.Name = "_createOverviewButton";
            this._createOverviewButton.Size = new System.Drawing.Size(75, 23);
            this._createOverviewButton.TabIndex = 16;
            this._createOverviewButton.Text = "오버뷰생성";
            this._createOverviewButton.UseVisualStyleBackColor = true;
            this._createOverviewButton.Click += new System.EventHandler(this._createOverviewButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Location = new System.Drawing.Point(3, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(423, 179);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "오버뷰 생성 옵션";
            // 
            // OverviewCreateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this._cancelCreateOverviewButton);
            this.Controls.Add(this._createOverviewButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "OverviewCreateControl";
            this.Size = new System.Drawing.Size(429, 415);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label _timerLabel;
        private System.Windows.Forms.Label _progressStateLabel;
        private System.Windows.Forms.ProgressBar _progressBar;
        private System.Windows.Forms.Button _cancelCreateOverviewButton;
        private System.Windows.Forms.Button _createOverviewButton;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
