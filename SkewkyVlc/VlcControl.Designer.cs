namespace Com.Skewky.Vlc
{
    partial class VlcControl
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
            this.components = new System.ComponentModel.Container();
            this.panelPlay = new System.Windows.Forms.Panel();
            this.picEnv = new System.Windows.Forms.PictureBox();
            this.panelCtrl = new System.Windows.Forms.Panel();
            this.lbVideoTime = new System.Windows.Forms.Label();
            this.lbSpeed = new System.Windows.Forms.Label();
            this.lbSound = new System.Windows.Forms.Label();
            this.tbProcess = new System.Windows.Forms.TrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelPlay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEnv)).BeginInit();
            this.panelCtrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbProcess)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPlay
            // 
            this.panelPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPlay.Controls.Add(this.picEnv);
            this.panelPlay.Location = new System.Drawing.Point(0, 0);
            this.panelPlay.Name = "panelPlay";
            this.panelPlay.Size = new System.Drawing.Size(580, 366);
            this.panelPlay.TabIndex = 0;
            // 
            // picEnv
            // 
            this.picEnv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picEnv.BackColor = System.Drawing.Color.Black;
            this.picEnv.Location = new System.Drawing.Point(0, 0);
            this.picEnv.Name = "picEnv";
            this.picEnv.Size = new System.Drawing.Size(580, 366);
            this.picEnv.TabIndex = 0;
            this.picEnv.TabStop = false;
            this.picEnv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picEnv_MouseClick);
            this.picEnv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.picEnv_MouseDoubleClick);
            this.picEnv.MouseEnter += new System.EventHandler(this.picEnv_MouseEnter);
            this.picEnv.MouseHover += new System.EventHandler(this.picEnv_MouseHover);
            this.picEnv.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picEnv_MouseMove);
            this.picEnv.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.picEnv_MouseWheel);
            // 
            // panelCtrl
            // 
            this.panelCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCtrl.Controls.Add(this.lbVideoTime);
            this.panelCtrl.Controls.Add(this.lbSpeed);
            this.panelCtrl.Controls.Add(this.lbSound);
            this.panelCtrl.Controls.Add(this.tbProcess);
            this.panelCtrl.Location = new System.Drawing.Point(0, 373);
            this.panelCtrl.Name = "panelCtrl";
            this.panelCtrl.Size = new System.Drawing.Size(580, 21);
            this.panelCtrl.TabIndex = 1;
            // 
            // lbVideoTime
            // 
            this.lbVideoTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbVideoTime.AutoSize = true;
            this.lbVideoTime.Location = new System.Drawing.Point(433, 3);
            this.lbVideoTime.Name = "lbVideoTime";
            this.lbVideoTime.Size = new System.Drawing.Size(96, 13);
            this.lbVideoTime.TabIndex = 10;
            this.lbVideoTime.Text = "00:00:00/00:00:00";
            // 
            // lbSpeed
            // 
            this.lbSpeed.AutoSize = true;
            this.lbSpeed.Location = new System.Drawing.Point(1, 2);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.Size = new System.Drawing.Size(27, 13);
            this.lbSpeed.TabIndex = 9;
            this.lbSpeed.Text = "0.5x";
            this.lbSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSound
            // 
            this.lbSound.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbSound.AutoSize = true;
            this.lbSound.Location = new System.Drawing.Point(549, 3);
            this.lbSound.Name = "lbSound";
            this.lbSound.Size = new System.Drawing.Size(25, 13);
            this.lbSound.TabIndex = 9;
            this.lbSound.Text = "100";
            this.lbSound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbProcess
            // 
            this.tbProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProcess.AutoSize = false;
            this.tbProcess.Location = new System.Drawing.Point(36, 1);
            this.tbProcess.Maximum = 100;
            this.tbProcess.Name = "tbProcess";
            this.tbProcess.Size = new System.Drawing.Size(390, 20);
            this.tbProcess.TabIndex = 0;
            this.tbProcess.TabStop = false;
            this.tbProcess.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // VlcControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCtrl);
            this.Controls.Add(this.panelPlay);
            this.Name = "VlcControl";
            this.Size = new System.Drawing.Size(580, 393);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.VlcControl_KeyUp);
            this.panelPlay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picEnv)).EndInit();
            this.panelCtrl.ResumeLayout(false);
            this.panelCtrl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbProcess)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPlay;
        private System.Windows.Forms.Panel panelCtrl;
        private System.Windows.Forms.TrackBar tbProcess;
        private System.Windows.Forms.Label lbSpeed;
        private System.Windows.Forms.Label lbSound;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox picEnv;
        private System.Windows.Forms.Label lbVideoTime;
    }
}
