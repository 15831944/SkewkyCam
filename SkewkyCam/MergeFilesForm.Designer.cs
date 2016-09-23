namespace Com.Skewky.Cam
{
    partial class MergeFilesForm
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
            this.vlcCtrl = new Com.Skewky.Vlc.VlcControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SuspendLayout();
            // 
            // vlcCtrl
            // 
            this.vlcCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vlcCtrl.Location = new System.Drawing.Point(183, 12);
            this.vlcCtrl.Name = "vlcCtrl";
            this.vlcCtrl.Size = new System.Drawing.Size(524, 392);
            this.vlcCtrl.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 416);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(719, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MergeFilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 438);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.vlcCtrl);
            this.Name = "MergeFilesForm";
            this.Text = "MergeFilesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Vlc.VlcControl vlcCtrl;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}