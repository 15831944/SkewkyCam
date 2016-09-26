namespace Com.Skewky.Vlc
{
    partial class FullScreenForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelPlay = new System.Windows.Forms.Panel();
            this.panelCtrl = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lbSound = new System.Windows.Forms.Label();
            this.lbTimer = new System.Windows.Forms.Label();
            this.lbSpeed = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picEnv = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelPlay.SuspendLayout();
            this.panelCtrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEnv)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPlay
            // 
            this.panelPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPlay.BackColor = System.Drawing.SystemColors.Control;
            this.panelPlay.Controls.Add(this.panelCtrl);
            this.panelPlay.Controls.Add(this.picEnv);
            this.panelPlay.Location = new System.Drawing.Point(0, 0);
            this.panelPlay.Name = "panelPlay";
            this.panelPlay.Size = new System.Drawing.Size(702, 462);
            this.panelPlay.TabIndex = 2;
            // 
            // panelCtrl
            // 
            this.panelCtrl.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panelCtrl.Controls.Add(this.label5);
            this.panelCtrl.Controls.Add(this.lbSound);
            this.panelCtrl.Controls.Add(this.lbTimer);
            this.panelCtrl.Controls.Add(this.lbSpeed);
            this.panelCtrl.Controls.Add(this.label1);
            this.panelCtrl.Location = new System.Drawing.Point(204, 442);
            this.panelCtrl.Name = "panelCtrl";
            this.panelCtrl.Size = new System.Drawing.Size(306, 20);
            this.panelCtrl.TabIndex = 1;
            this.panelCtrl.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(233, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "音量：";
            // 
            // lbSound
            // 
            this.lbSound.AutoSize = true;
            this.lbSound.Location = new System.Drawing.Point(281, 4);
            this.lbSound.Name = "lbSound";
            this.lbSound.Size = new System.Drawing.Size(17, 12);
            this.lbSound.TabIndex = 1;
            this.lbSound.Text = "80";
            // 
            // lbTimer
            // 
            this.lbTimer.AutoSize = true;
            this.lbTimer.Location = new System.Drawing.Point(115, 4);
            this.lbTimer.Name = "lbTimer";
            this.lbTimer.Size = new System.Drawing.Size(107, 12);
            this.lbTimer.TabIndex = 1;
            this.lbTimer.Text = "00:00:00/00:00:00";
            // 
            // lbSpeed
            // 
            this.lbSpeed.AutoSize = true;
            this.lbSpeed.Location = new System.Drawing.Point(65, 4);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.Size = new System.Drawing.Size(29, 12);
            this.lbSpeed.TabIndex = 1;
            this.lbSpeed.Text = "0.5x";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "播放速度：";
            // 
            // picEnv
            // 
            this.picEnv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picEnv.BackColor = System.Drawing.Color.Black;
            this.picEnv.Location = new System.Drawing.Point(0, 0);
            this.picEnv.Name = "picEnv";
            this.picEnv.Size = new System.Drawing.Size(702, 462);
            this.picEnv.TabIndex = 0;
            this.picEnv.TabStop = false;
            this.picEnv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FullScreen_MouseDoubleClick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FullScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 462);
            this.ControlBox = false;
            this.Controls.Add(this.panelPlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FullScreenForm";
            this.Text = "FullScreenPlayer";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FullScreenPlayer_FormClosed);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FullScreenPlayer_KeyUp);
            this.panelPlay.ResumeLayout(false);
            this.panelCtrl.ResumeLayout(false);
            this.panelCtrl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEnv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPlay;
        private System.Windows.Forms.PictureBox picEnv;
        private System.Windows.Forms.Panel panelCtrl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbSound;
        private System.Windows.Forms.Label lbTimer;
        private System.Windows.Forms.Label lbSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}