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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "1",
            "状态",
            "描述"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileMgrForm));
            this.listFiles = new System.Windows.Forms.ListView();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbKeyword = new System.Windows.Forms.TextBox();
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
            this.tsmiNote = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsslFilter = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listFiles
            // 
            this.listFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listFiles.CheckBoxes = true;
            this.listFiles.GridLines = true;
            listViewGroup2.Header = "ListViewGroup";
            listViewGroup2.Name = "listViewGroup1";
            this.listFiles.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup2});
            listViewItem2.StateImageIndex = 0;
            this.listFiles.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.listFiles.Location = new System.Drawing.Point(12, 11);
            this.listFiles.MultiSelect = false;
            this.listFiles.Name = "listFiles";
            this.listFiles.ShowItemToolTips = true;
            this.listFiles.Size = new System.Drawing.Size(293, 442);
            this.listFiles.TabIndex = 0;
            this.listFiles.UseCompatibleStateImageBehavior = false;
            this.listFiles.View = System.Windows.Forms.View.List;
            // 
            // dtEnd
            // 
            this.dtEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dtEnd.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd.Location = new System.Drawing.Point(673, 498);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(121, 21);
            this.dtEnd.TabIndex = 1;
            this.dtEnd.ValueChanged += new System.EventHandler(this.dtEnd_ValueChanged);
            // 
            // dtStart
            // 
            this.dtStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dtStart.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.Location = new System.Drawing.Point(534, 498);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(121, 21);
            this.dtStart.TabIndex = 1;
            this.dtStart.ValueChanged += new System.EventHandler(this.dtStart_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(311, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(661, 474);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // tbKeyword
            // 
            this.tbKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbKeyword.Location = new System.Drawing.Point(842, 498);
            this.tbKeyword.Name = "tbKeyword";
            this.tbKeyword.Size = new System.Drawing.Size(121, 21);
            this.tbKeyword.TabIndex = 2;
            this.tbKeyword.TextChanged += new System.EventHandler(this.tbKeyword_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(795, 501);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "关键字";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(659, 500);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "-";
            // 
            // btSelAll
            // 
            this.btSelAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSelAll.Location = new System.Drawing.Point(12, 464);
            this.btSelAll.Name = "btSelAll";
            this.btSelAll.Size = new System.Drawing.Size(41, 21);
            this.btSelAll.TabIndex = 4;
            this.btSelAll.Text = "全选";
            this.btSelAll.UseVisualStyleBackColor = true;
            this.btSelAll.Click += new System.EventHandler(this.btSelAll_Click);
            // 
            // btSelRev
            // 
            this.btSelRev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSelRev.Location = new System.Drawing.Point(59, 464);
            this.btSelRev.Name = "btSelRev";
            this.btSelRev.Size = new System.Drawing.Size(41, 21);
            this.btSelRev.TabIndex = 4;
            this.btSelRev.Text = "反选";
            this.btSelRev.UseVisualStyleBackColor = true;
            // 
            // btExport
            // 
            this.btExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btExport.Location = new System.Drawing.Point(134, 464);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(41, 21);
            this.btExport.TabIndex = 4;
            this.btExport.Text = "导出";
            this.btExport.UseVisualStyleBackColor = true;
            // 
            // btMove
            // 
            this.btMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btMove.Location = new System.Drawing.Point(181, 464);
            this.btMove.Name = "btMove";
            this.btMove.Size = new System.Drawing.Size(41, 21);
            this.btMove.TabIndex = 4;
            this.btMove.Text = "移到";
            this.btMove.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDelete.Location = new System.Drawing.Point(264, 464);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(41, 21);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 495);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 23);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssLabel
            // 
            this.tssLabel.Name = "tssLabel";
            this.tssLabel.Size = new System.Drawing.Size(56, 18);
            this.tssLabel.Text = "正在加载";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 17);
            // 
            // tsddFilter
            // 
            this.tsddFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLove,
            this.tsmiDel,
            this.tsmiPriv,
            this.tsmiNote,
            this.toolStripSeparator1,
            this.tsmiAll});
            this.tsddFilter.Image = ((System.Drawing.Image)(resources.GetObject("tsddFilter.Image")));
            this.tsddFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddFilter.Name = "tsddFilter";
            this.tsddFilter.Size = new System.Drawing.Size(85, 21);
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
            this.tsmiDel.Text = "待删";
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
            // tsmiNote
            // 
            this.tsmiNote.Checked = true;
            this.tsmiNote.CheckOnClick = true;
            this.tsmiNote.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiNote.Name = "tsmiNote";
            this.tsmiNote.Size = new System.Drawing.Size(152, 22);
            this.tsmiNote.Text = "备注";
            this.tsmiNote.CheckedChanged += new System.EventHandler(this.tsmiAll_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiAll
            // 
            this.tsmiAll.Checked = true;
            this.tsmiAll.CheckOnClick = true;
            this.tsmiAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiAll.Name = "tsmiAll";
            this.tsmiAll.Size = new System.Drawing.Size(152, 22);
            this.tsmiAll.Text = "无标记";
            this.tsmiAll.CheckedChanged += new System.EventHandler(this.tsmiAll_CheckedChanged);
            this.tsmiAll.Click += new System.EventHandler(this.tsmiAll_Click);
            // 
            // tsslFilter
            // 
            this.tsslFilter.Name = "tsslFilter";
            this.tsslFilter.Size = new System.Drawing.Size(56, 18);
            this.tsslFilter.Text = "显示隐藏";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FileMgrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 518);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbKeyword);
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
            this.MinimumSize = new System.Drawing.Size(1000, 557);
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
        private System.Windows.Forms.TextBox tbKeyword;
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
        private System.Windows.Forms.ToolStripMenuItem tsmiNote;
        private System.Windows.Forms.Timer timer1;
    }
}