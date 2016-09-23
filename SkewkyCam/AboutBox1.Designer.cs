namespace Com.Skewky.Cam
{
    partial class AboutBox1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.okButton = new System.Windows.Forms.Button();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelProductName = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lbDescription = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(126, 275);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "&OK";
            this.okButton.Visible = false;
            this.okButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel_MouseDoubleClick);
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelCompanyName.Location = new System.Drawing.Point(210, 103);
            this.labelCompanyName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelCompanyName.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(297, 17);
            this.labelCompanyName.TabIndex = 22;
            this.labelCompanyName.Text = "Company Name";
            this.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelCompanyName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel_MouseDoubleClick);
            this.labelCompanyName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel_MouseDoubleClick);
            // 
            // labelCopyright
            // 
            this.labelCopyright.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelCopyright.Location = new System.Drawing.Point(210, 73);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelCopyright.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(297, 17);
            this.labelCopyright.TabIndex = 21;
            this.labelCopyright.Text = "Copyright";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelCopyright.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel_MouseDoubleClick);
            this.labelCopyright.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel_MouseDoubleClick);
            // 
            // labelVersion
            // 
            this.labelVersion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelVersion.Location = new System.Drawing.Point(210, 43);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelVersion.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(297, 17);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "Version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelVersion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel_MouseDoubleClick);
            this.labelVersion.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel_MouseDoubleClick);
            // 
            // labelProductName
            // 
            this.labelProductName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelProductName.Location = new System.Drawing.Point(210, 13);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelProductName.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(297, 17);
            this.labelProductName.TabIndex = 19;
            this.labelProductName.Text = "Product Name";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelProductName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel_MouseDoubleClick);
            this.labelProductName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel_MouseDoubleClick);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.labelProductName, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.labelVersion, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.labelCopyright, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.labelCompanyName, 2, 3);
            this.tableLayoutPanel.Controls.Add(this.lbDescription, 2, 4);
            this.tableLayoutPanel.Controls.Add(this.okButton, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.pictureBox1, 2, 5);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(518, 304);
            this.tableLayoutPanel.TabIndex = 0;
            this.tableLayoutPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel_MouseDoubleClick);
            this.tableLayoutPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel_MouseDoubleClick);
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDescription.Location = new System.Drawing.Point(207, 120);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(300, 150);
            this.lbDescription.TabIndex = 25;
            this.lbDescription.Text = "四年前，上帝把一个小宝贝送到了我们的身边。四年来我们一起走过太多的风雨";
            this.lbDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbDescription.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel_MouseDoubleClick);
            this.lbDescription.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel_MouseDoubleClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Com.Skewky.Cam.Properties.Resources.thankyou;
            this.pictureBox1.Location = new System.Drawing.Point(207, 273);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 25);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel_MouseDoubleClick);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel_MouseDoubleClick);
            // 
            // AboutBox1
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Com.Skewky.Cam.Properties.Resources.aboutBg_看图王;
            this.ClientSize = new System.Drawing.Size(536, 322);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox1";
            this.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AboutBox1";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}
