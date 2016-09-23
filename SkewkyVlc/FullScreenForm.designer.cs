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
            this.panelPlay = new System.Windows.Forms.Panel();
            this.picEnv = new System.Windows.Forms.PictureBox();
            this.panelPlay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEnv)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPlay
            // 
            this.panelPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPlay.BackColor = System.Drawing.SystemColors.Control;
            this.panelPlay.Controls.Add(this.picEnv);
            this.panelPlay.Location = new System.Drawing.Point(0, 0);
            this.panelPlay.Name = "panelPlay";
            this.panelPlay.Size = new System.Drawing.Size(702, 462);
            this.panelPlay.TabIndex = 2;
            // 
            // picEnv
            // 
            this.picEnv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picEnv.BackColor = System.Drawing.Color.Black;
            this.picEnv.Location = new System.Drawing.Point(0, 3);
            this.picEnv.Name = "picEnv";
            this.picEnv.Size = new System.Drawing.Size(698, 455);
            this.picEnv.TabIndex = 0;
            this.picEnv.TabStop = false;
            this.picEnv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FullScreen_MouseDoubleClick);
            // 
            // FullScreenPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 462);
            this.ControlBox = false;
            this.Controls.Add(this.panelPlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FullScreenPlayer";
            this.Text = "FullScreenPlayer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FullScreenPlayer_FormClosed);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FullScreenPlayer_KeyUp);
            this.panelPlay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picEnv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPlay;
        private System.Windows.Forms.PictureBox picEnv;
    }
}