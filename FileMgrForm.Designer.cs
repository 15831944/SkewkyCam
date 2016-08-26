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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "1",
            "状态",
            "描述"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileMgrForm));
            this.listFiles = new System.Windows.Forms.ListView();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
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
            this.lbCurOpr = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssProcess = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslFilter = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerInitFiles = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.miLove = new System.Windows.Forms.ToolStripMenuItem();
            this.miDel = new System.Windows.Forms.ToolStripMenuItem();
            this.miPriv = new System.Windows.Forms.ToolStripMenuItem();
            this.miNote = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miReloadFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.btSearch = new System.Windows.Forms.Button();
            this.lbSearchPrview = new System.Windows.Forms.Label();
            this.timerOprFiles = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listFiles
            // 
            this.listFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listFiles.CheckBoxes = true;
            this.listFiles.GridLines = true;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            this.listFiles.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            listViewItem1.StateImageIndex = 0;
            this.listFiles.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listFiles.Location = new System.Drawing.Point(12, 0);
            this.listFiles.MultiSelect = false;
            this.listFiles.Name = "listFiles";
            this.listFiles.ShowItemToolTips = true;
            this.listFiles.Size = new System.Drawing.Size(307, 463);
            this.listFiles.TabIndex = 0;
            this.listFiles.UseCompatibleStateImageBehavior = false;
            this.listFiles.View = System.Windows.Forms.View.Details;
            // 
            // dtEnd
            // 
            this.dtEnd.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd.Location = new System.Drawing.Point(251, 4);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(134, 20);
            this.dtEnd.TabIndex = 1;
            this.dtEnd.ValueChanged += new System.EventHandler(this.dtEnd_ValueChanged);
            // 
            // dtStart
            // 
            this.dtStart.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.Location = new System.Drawing.Point(97, 4);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(134, 20);
            this.dtStart.TabIndex = 1;
            this.dtStart.ValueChanged += new System.EventHandler(this.dtStart_ValueChanged);
            // 
            // tbKeyword
            // 
            this.tbKeyword.Location = new System.Drawing.Point(445, 4);
            this.tbKeyword.Name = "tbKeyword";
            this.tbKeyword.Size = new System.Drawing.Size(121, 20);
            this.tbKeyword.TabIndex = 2;
            this.tbKeyword.TextChanged += new System.EventHandler(this.tbKeyword_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(398, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "关键字";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "-";
            // 
            // btSelAll
            // 
            this.btSelAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSelAll.Location = new System.Drawing.Point(12, 474);
            this.btSelAll.Name = "btSelAll";
            this.btSelAll.Size = new System.Drawing.Size(41, 23);
            this.btSelAll.TabIndex = 4;
            this.btSelAll.Text = "全选";
            this.btSelAll.UseVisualStyleBackColor = true;
            this.btSelAll.Click += new System.EventHandler(this.btSelAll_Click);
            // 
            // btSelRev
            // 
            this.btSelRev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSelRev.Location = new System.Drawing.Point(59, 474);
            this.btSelRev.Name = "btSelRev";
            this.btSelRev.Size = new System.Drawing.Size(41, 23);
            this.btSelRev.TabIndex = 4;
            this.btSelRev.Text = "反选";
            this.btSelRev.UseVisualStyleBackColor = true;
            this.btSelRev.Click += new System.EventHandler(this.btSelRev_Click);
            // 
            // btExport
            // 
            this.btExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btExport.Location = new System.Drawing.Point(117, 474);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(41, 23);
            this.btExport.TabIndex = 4;
            this.btExport.Text = "导出";
            this.btExport.UseVisualStyleBackColor = true;
            this.btExport.Click += new System.EventHandler(this.btExport_Click);
            // 
            // btMove
            // 
            this.btMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btMove.Location = new System.Drawing.Point(164, 474);
            this.btMove.Name = "btMove";
            this.btMove.Size = new System.Drawing.Size(41, 23);
            this.btMove.TabIndex = 4;
            this.btMove.Text = "移到";
            this.btMove.UseVisualStyleBackColor = true;
            this.btMove.Click += new System.EventHandler(this.btMove_Click);
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDelete.Location = new System.Drawing.Point(211, 474);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(41, 23);
            this.btDelete.TabIndex = 4;
            this.btDelete.Text = "删除";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabel,
            this.lbCurOpr,
            this.tssProcess,
            this.tsslFilter});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssLabel
            // 
            this.tssLabel.Name = "tssLabel";
            this.tssLabel.Size = new System.Drawing.Size(56, 17);
            this.tssLabel.Text = "正在加载";
            // 
            // lbCurOpr
            // 
            this.lbCurOpr.Name = "lbCurOpr";
            this.lbCurOpr.Size = new System.Drawing.Size(59, 17);
            this.lbCurOpr.Text = "后台删除:";
            // 
            // tssProcess
            // 
            this.tssProcess.Name = "tssProcess";
            this.tssProcess.Size = new System.Drawing.Size(100, 18);
            this.tssProcess.Visible = false;
            // 
            // tsslFilter
            // 
            this.tsslFilter.Name = "tsslFilter";
            this.tsslFilter.Size = new System.Drawing.Size(57, 17);
            this.tsslFilter.Text = "显示隐藏";
            // 
            // timerInitFiles
            // 
            this.timerInitFiles.Tick += new System.EventHandler(this.timerInitFiles_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.listFiles);
            this.splitContainer1.Panel1.Controls.Add(this.btDelete);
            this.splitContainer1.Panel1.Controls.Add(this.btExport);
            this.splitContainer1.Panel1.Controls.Add(this.btSelAll);
            this.splitContainer1.Panel1.Controls.Add(this.btSelRev);
            this.splitContainer1.Panel1.Controls.Add(this.btMove);
            this.splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.splitter1);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(984, 507);
            this.splitContainer1.SplitterDistance = 321;
            this.splitContainer1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(268, 473);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "停止>";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 507);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(647, 507);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 27);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miLove,
            this.miDel,
            this.miPriv,
            this.miNote,
            this.toolStripSeparator2,
            this.miAll,
            this.toolStripSeparator1,
            this.miReloadFiles});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(86, 20);
            this.toolStripDropDownButton1.Text = "显示隐藏";
            // 
            // miLove
            // 
            this.miLove.Checked = true;
            this.miLove.CheckOnClick = true;
            this.miLove.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miLove.Name = "miLove";
            this.miLove.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.miLove.Size = new System.Drawing.Size(193, 22);
            this.miLove.Text = "喜爱";
            this.miLove.CheckedChanged += new System.EventHandler(this.miLove_CheckedChanged);
            // 
            // miDel
            // 
            this.miDel.Checked = true;
            this.miDel.CheckOnClick = true;
            this.miDel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miDel.Name = "miDel";
            this.miDel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.miDel.Size = new System.Drawing.Size(193, 22);
            this.miDel.Text = "待删";
            this.miDel.CheckedChanged += new System.EventHandler(this.miLove_CheckedChanged);
            // 
            // miPriv
            // 
            this.miPriv.Checked = true;
            this.miPriv.CheckOnClick = true;
            this.miPriv.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miPriv.Name = "miPriv";
            this.miPriv.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.miPriv.Size = new System.Drawing.Size(193, 22);
            this.miPriv.Text = "隐私";
            this.miPriv.CheckedChanged += new System.EventHandler(this.miLove_CheckedChanged);
            // 
            // miNote
            // 
            this.miNote.Checked = true;
            this.miNote.CheckOnClick = true;
            this.miNote.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miNote.Name = "miNote";
            this.miNote.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.miNote.Size = new System.Drawing.Size(193, 22);
            this.miNote.Text = "备注";
            this.miNote.CheckedChanged += new System.EventHandler(this.miLove_CheckedChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(190, 6);
            // 
            // miAll
            // 
            this.miAll.Checked = true;
            this.miAll.CheckOnClick = true;
            this.miAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miAll.Name = "miAll";
            this.miAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
            this.miAll.Size = new System.Drawing.Size(193, 22);
            this.miAll.Text = "无标记";
            this.miAll.CheckedChanged += new System.EventHandler(this.miLove_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // miReloadFiles
            // 
            this.miReloadFiles.Name = "miReloadFiles";
            this.miReloadFiles.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
            this.miReloadFiles.Size = new System.Drawing.Size(193, 22);
            this.miReloadFiles.Text = "重新扫描文件";
            this.miReloadFiles.Click += new System.EventHandler(this.miReloadFiles_Click);
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(573, 4);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(67, 20);
            this.btSearch.TabIndex = 8;
            this.btSearch.Text = "搜索";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // lbSearchPrview
            // 
            this.lbSearchPrview.AutoSize = true;
            this.lbSearchPrview.Location = new System.Drawing.Point(647, 10);
            this.lbSearchPrview.Name = "lbSearchPrview";
            this.lbSearchPrview.Size = new System.Drawing.Size(55, 13);
            this.lbSearchPrview.TabIndex = 9;
            this.lbSearchPrview.Text = "显示全部";
            // 
            // timerOprFiles
            // 
            this.timerOprFiles.Tick += new System.EventHandler(this.timerOprFiles_Tick);
            // 
            // FileMgrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.lbSearchPrview);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbKeyword);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "FileMgrForm";
            this.Text = "FileMgrForm";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FileMgrForm_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripProgressBar tssProcess;
        private System.Windows.Forms.ToolStripStatusLabel tsslFilter;
        private System.Windows.Forms.Timer timerInitFiles;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem miLove;
        private System.Windows.Forms.ToolStripMenuItem miDel;
        private System.Windows.Forms.ToolStripMenuItem miPriv;
        private System.Windows.Forms.ToolStripMenuItem miNote;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem miAll;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Label lbSearchPrview;
        private System.Windows.Forms.ToolStripMenuItem miReloadFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripStatusLabel lbCurOpr;
        private System.Windows.Forms.Timer timerOprFiles;
    }
}