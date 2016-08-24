namespace Com.Skewky.Cam
{
    partial class FileMgrForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileMgrForm));
            this.listFiles = new System.Windows.Forms.ListView();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btSelAll = new System.Windows.Forms.Button();
            this.btSelRev = new System.Windows.Forms.Button();
            this.btExport = new System.Windows.Forms.Button();
            this.btMove = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.tsddFilter = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiLove = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPriv = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsslFilter = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listFiles
            // 
            this.listFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listFiles.CheckBoxes = true;
            this.listFiles.Location = new System.Drawing.Point(12, 12);
            this.listFiles.MultiSelect = false;
            this.listFiles.Name = "listFiles";
            this.listFiles.ShowItemToolTips = true;
            this.listFiles.Size = new System.Drawing.Size(293, 665);
            this.listFiles.TabIndex = 0;
            this.listFiles.UseCompatibleStateImageBehavior = false;
            this.listFiles.View = System.Windows.Forms.View.List;
            // 
            // dtEnd
            // 
            this.dtEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dtEnd.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd.Location = new System.Drawing.Point(690, 727);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(121, 20);
            this.dtEnd.TabIndex = 1;
            this.dtEnd.ValueChanged += new System.EventHandler(this.dtEnd_ValueChanged);
            // 
            // dtStart
            // 
            this.dtStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dtStart.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.Location = new System.Drawing.Point(527, 727);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(121, 20);
            this.dtStart.TabIndex = 1;
            this.dtStart.ValueChanged += new System.EventHandler(this.dtStart_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(311, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(813, 700);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(903, 727);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(211, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(849, 730);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "关键字";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(664, 727);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "-";
            // 
            // btSelAll
            // 
            this.btSelAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSelAll.Location = new System.Drawing.Point(12, 689);
            this.btSelAll.Name = "btSelAll";
            this.btSelAll.Size = new System.Drawing.Size(41, 23);
            this.btSelAll.TabIndex = 4;
            this.btSelAll.Text = "全选";
            this.btSelAll.UseVisualStyleBackColor = true;
            // 
            // btSelRev
            // 
            this.btSelRev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSelRev.Location = new System.Drawing.Point(59, 689);
            this.btSelRev.Name = "btSelRev";
            this.btSelRev.Size = new System.Drawing.Size(41, 23);
            this.btSelRev.TabIndex = 4;
            this.btSelRev.Text = "反选";
            this.btSelRev.UseVisualStyleBackColor = true;
            // 
            // btExport
            // 
            this.btExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btExport.Location = new System.Drawing.Point(134, 689);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(41, 23);
            this.btExport.TabIndex = 4;
            this.btExport.Text = "导出";
            this.btExport.UseVisualStyleBackColor = true;
            // 
            // btMove
            // 
            this.btMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btMove.Location = new System.Drawing.Point(181, 689);
            this.btMove.Name = "btMove";
            this.btMove.Size = new System.Drawing.Size(41, 23);
            this.btMove.TabIndex = 4;
            this.btMove.Text = "移到";
            this.btMove.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDelete.Location = new System.Drawing.Point(264, 689);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(41, 23);
            this.btDelete.TabIndex = 4;
            this.btDelete.Text = "删除";
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabel,
            this.toolStripProgressBar1,
            this.tsddFilter,
            this.tsslFilter});
            this.statusStrip1.Location = new System.Drawing.Point(0, 725);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1136, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssLabel
            // 
            this.tssLabel.Name = "tssLabel";
            this.tssLabel.Size = new System.Drawing.Size(118, 17);
            this.tssLabel.Text = "toolStripStatusLabel1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // tsddFilter
            // 
            this.tsddFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLove,
            this.tsmiDel,
            this.tsmiPriv,
            this.toolStripSeparator1,
            this.tsmiAll});
            this.tsddFilter.Image = ((System.Drawing.Image)(resources.GetObject("tsddFilter.Image")));
            this.tsddFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddFilter.Name = "tsddFilter";
            this.tsddFilter.Size = new System.Drawing.Size(86, 20);
            this.tsddFilter.Text = "显示隐藏";
            // 
            // tsmiLove
            // 
            this.tsmiLove.Checked = true;
            this.tsmiLove.CheckOnClick = true;
            this.tsmiLove.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiLove.Name = "tsmiLove";
            this.tsmiLove.Size = new System.Drawing.Size(152, 22);
            this.tsmiLove.Text = "喜爱";
            this.tsmiLove.CheckedChanged += new System.EventHandler(this.tsmiAll_CheckedChanged);
            // 
            // tsmiDel
            // 
            this.tsmiDel.Checked = true;
            this.tsmiDel.CheckOnClick = true;
            this.tsmiDel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiDel.Name = "tsmiDel";
            this.tsmiDel.Size = new System.Drawing.Size(152, 22);
            this.tsmiDel.Text = "删除";
            this.tsmiDel.CheckedChanged += new System.EventHandler(this.tsmiAll_CheckedChanged);
            // 
            // tsmiPriv
            // 
            this.tsmiPriv.Checked = true;
            this.tsmiPriv.CheckOnClick = true;
            this.tsmiPriv.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiPriv.Name = "tsmiPriv";
            this.tsmiPriv.Size = new System.Drawing.Size(152, 22);
            this.tsmiPriv.Text = "隐私";
            this.tsmiPriv.CheckedChanged += new System.EventHandler(this.tsmiAll_CheckedChanged);
            // 
            // tsmiAll
            // 
            this.tsmiAll.Checked = true;
            this.tsmiAll.CheckOnClick = true;
            this.tsmiAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiAll.Name = "tsmiAll";
            this.tsmiAll.Size = new System.Drawing.Size(152, 22);
            this.tsmiAll.Text = "无标注";
            this.tsmiAll.CheckedChanged += new System.EventHandler(this.tsmiAll_CheckedChanged);
            this.tsmiAll.Click += new System.EventHandler(this.tsmiAll_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // tsslFilter
            // 
            this.tsslFilter.Name = "tsslFilter";
            this.tsslFilter.Size = new System.Drawing.Size(118, 17);
            this.tsslFilter.Text = "toolStripStatusLabel1";
            // 
            // FileMgrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 747);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btMove);
            this.Controls.Add(this.btExport);
            this.Controls.Add(this.btSelRev);
            this.Controls.Add(this.btSelAll);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listFiles);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FileMgrForm";
            this.Text = "FileMgrForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listFiles;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btSelAll;
        private System.Windows.Forms.Button btSelRev;
        private System.Windows.Forms.Button btExport;
        private System.Windows.Forms.Button btMove;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripDropDownButton tsddFilter;
        private System.Windows.Forms.ToolStripMenuItem tsmiPriv;
        private System.Windows.Forms.ToolStripMenuItem tsmiDel;
        private System.Windows.Forms.ToolStripMenuItem tsmiLove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAll;
        private System.Windows.Forms.ToolStripStatusLabel tsslFilter;
    }
}