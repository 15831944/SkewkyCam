namespace Com.Skewky.Vlc
{
    partial class FullScreenPlayer
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
            this.FullScreen = new System.Windows.Forms.PictureBox();
            this.panelPlay = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FullScreen)).BeginInit();
            this.panelPlay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // FullScreen
            // 
            this.FullScreen.BackColor = System.Drawing.Color.Transparent;
            this.FullScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FullScreen.Location = new System.Drawing.Point(0, 0);
            this.FullScreen.Name = "FullScreen";
            this.FullScreen.Size = new System.Drawing.Size(662, 462);
            this.FullScreen.TabIndex = 1;
            this.FullScreen.TabStop = false;
            this.FullScreen.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FullScreen_MouseDoubleClick);
            // 
            // panelPlay
            // 
            this.panelPlay.Controls.Add(this.pictureBox1);
            this.panelPlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPlay.Location = new System.Drawing.Point(0, 0);
            this.panelPlay.Name = "panelPlay";
            this.panelPlay.Size = new System.Drawing.Size(662, 462);
            this.panelPlay.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Com.Skewky.Vlc.Properties.Resources.dsf;
            this.pictureBox1.Location = new System.Drawing.Point(633, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "退出全屏";
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FullScreenPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 462);
            this.ControlBox = false;
            this.Controls.Add(this.panelPlay);
            this.Controls.Add(this.FullScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FullScreenPlayer";
            this.Text = "FullScreenPlayer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FullScreenPlayer_FormClosed);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FullScreenPlayer_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.FullScreen)).EndInit();
            this.panelPlay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox FullScreen;
        private System.Windows.Forms.Panel panelPlay;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}