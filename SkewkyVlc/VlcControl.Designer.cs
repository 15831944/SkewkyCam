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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelCtrl = new System.Windows.Forms.Panel();
            this.lbVideoTime = new System.Windows.Forms.Label();
            this.lbSpeed = new System.Windows.Forms.Label();
            this.lbSound = new System.Windows.Forms.Label();
            this.tbProcess = new System.Windows.Forms.TrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelPlay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelCtrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbProcess)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPlay
            // 
            this.panelPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPlay.Controls.Add(this.pictureBox1);
            this.panelPlay.Location = new System.Drawing.Point(0, 0);
            this.panelPlay.Name = "panelPlay";
            this.panelPlay.Size = new System.Drawing.Size(580, 338);
            this.panelPlay.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(580, 338);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            // 
            // panelCtrl
            // 
            this.panelCtrl.Controls.Add(this.lbVideoTime);
            this.panelCtrl.Controls.Add(this.lbSpeed);
            this.panelCtrl.Controls.Add(this.lbSound);
            this.panelCtrl.Controls.Add(this.tbProcess);
            this.panelCtrl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCtrl.Location = new System.Drawing.Point(0, 344);
            this.panelCtrl.Name = "panelCtrl";
            this.panelCtrl.Size = new System.Drawing.Size(580, 19);
            this.panelCtrl.TabIndex = 1;
            // 
            // lbVideoTime
            // 
            this.lbVideoTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbVideoTime.AutoSize = true;
            this.lbVideoTime.Location = new System.Drawing.Point(433, 3);
            this.lbVideoTime.Name = "lbVideoTime";
            this.lbVideoTime.Size = new System.Drawing.Size(107, 12);
            this.lbVideoTime.TabIndex = 10;
            this.lbVideoTime.Text = "00:00:00/00:00:00";
            // 
            // lbSpeed
            // 
            this.lbSpeed.AutoSize = true;
            this.lbSpeed.Location = new System.Drawing.Point(1, 2);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.Size = new System.Drawing.Size(29, 12);
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
            this.lbSound.Size = new System.Drawing.Size(23, 12);
            this.lbSound.TabIndex = 9;
            this.lbSound.Text = "100";
            this.lbSound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbProcess
            // 
            this.tbProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProcess.AutoSize = false;
            this.tbProcess.Location = new System.Drawing.Point(36, 1);
            this.tbProcess.Name = "tbProcess";
            this.tbProcess.Size = new System.Drawing.Size(390, 18);
            this.tbProcess.TabIndex = 0;
            this.tbProcess.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // VlcControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCtrl);
            this.Controls.Add(this.panelPlay);
            this.Name = "VlcControl";
            this.Size = new System.Drawing.Size(580, 363);
            this.panelPlay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbVideoTime;
    }
}
