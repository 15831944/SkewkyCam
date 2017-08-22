namespace Com.Skewky.Cam
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelHandM = new System.Windows.Forms.Panel();
            this.lbHour = new System.Windows.Forms.Label();
            this.lbMinute = new System.Windows.Forms.Label();
            this.pBmin = new System.Windows.Forms.PictureBox();
            this.pBhour = new System.Windows.Forms.PictureBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.tssPlaySpeed = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssPause = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssNote = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainTip = new System.Windows.Forms.ToolTip(this.components);
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.File_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMgr_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Help_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReadMe_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.About_MenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picLove = new System.Windows.Forms.PictureBox();
            this.picNote = new System.Windows.Forms.PictureBox();
            this.picPriv = new System.Windows.Forms.PictureBox();
            this.picBin = new System.Windows.Forms.PictureBox();
            this.picLoveGray = new System.Windows.Forms.PictureBox();
            this.picNoteGray = new System.Windows.Forms.PictureBox();
            this.picPrivGray = new System.Windows.Forms.PictureBox();
            this.picBinGray = new System.Windows.Forms.PictureBox();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.ck_ContinuMark = new System.Windows.Forms.CheckBox();
            this.lbNowPlaying = new System.Windows.Forms.Label();
            this.vlcCtrl = new Com.Skewky.Vlc.VlcControl();
            this.panelHandM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBhour)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPriv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoveGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNoteGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPrivGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBinGray)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHandM
            // 
            this.panelHandM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHandM.Controls.Add(this.lbHour);
            this.panelHandM.Controls.Add(this.lbMinute);
            this.panelHandM.Controls.Add(this.pBmin);
            this.panelHandM.Controls.Add(this.pBhour);
            this.panelHandM.Location = new System.Drawing.Point(12, 495);
            this.panelHandM.Name = "panelHandM";
            this.panelHandM.Size = new System.Drawing.Size(755, 44);
            this.panelHandM.TabIndex = 1;
            this.panelHandM.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // lbHour
            // 
            this.lbHour.AutoSize = true;
            this.lbHour.Location = new System.Drawing.Point(3, 24);
            this.lbHour.Name = "lbHour";
            this.lbHour.Size = new System.Drawing.Size(23, 12);
            this.lbHour.TabIndex = 9;
            this.lbHour.Text = "时:";
            // 
            // lbMinute
            // 
            this.lbMinute.AutoSize = true;
            this.lbMinute.Location = new System.Drawing.Point(2, 5);
            this.lbMinute.Name = "lbMinute";
            this.lbMinute.Size = new System.Drawing.Size(23, 12);
            this.lbMinute.TabIndex = 9;
            this.lbMinute.Text = "分:";
            this.lbMinute.Click += new System.EventHandler(this.lbMinute_Click);
            // 
            // pBmin
            // 
            this.pBmin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pBmin.BackColor = System.Drawing.SystemColors.Control;
            this.pBmin.Location = new System.Drawing.Point(26, 4);
            this.pBmin.Name = "pBmin";
            this.pBmin.Size = new System.Drawing.Size(726, 14);
            this.pBmin.TabIndex = 8;
            this.pBmin.TabStop = false;
            this.pBmin.Click += new System.EventHandler(this.pBmin_Click);
            this.pBmin.Paint += new System.Windows.Forms.PaintEventHandler(this.pBmin_Paint);
            this.pBmin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pBmin_MouseClick);
            this.pBmin.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pBmin_MouseDoubleClick);
            this.pBmin.MouseLeave += new System.EventHandler(this.pBmin_MouseLeave);
            this.pBmin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pBmin_MouseMove);
            // 
            // pBhour
            // 
            this.pBhour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pBhour.BackColor = System.Drawing.SystemColors.Control;
            this.pBhour.Location = new System.Drawing.Point(26, 24);
            this.pBhour.Name = "pBhour";
            this.pBhour.Size = new System.Drawing.Size(726, 14);
            this.pBhour.TabIndex = 8;
            this.pBhour.TabStop = false;
            this.pBhour.Click += new System.EventHandler(this.pBhour_Click);
            this.pBhour.Paint += new System.Windows.Forms.PaintEventHandler(this.pBhour_Paint);
            this.pBhour.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pBhour_MouseDoubleClick);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(924, -1);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "浏览";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Visible = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(839, -1);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus,
            this.toolStripProgressBar1,
            this.tssPlaySpeed,
            this.tssPause,
            this.tssNote});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1011, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(56, 17);
            this.tsslStatus.Text = "正在加载";
            this.tsslStatus.Visible = false;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Visible = false;
            // 
            // tssPlaySpeed
            // 
            this.tssPlaySpeed.Name = "tssPlaySpeed";
            this.tssPlaySpeed.Size = new System.Drawing.Size(0, 17);
            // 
            // tssPause
            // 
            this.tssPause.Name = "tssPause";
            this.tssPause.Size = new System.Drawing.Size(0, 17);
            // 
            // tssNote
            // 
            this.tssNote.Name = "tssNote";
            this.tssNote.Size = new System.Drawing.Size(0, 17);
            // 
            // mainTip
            // 
            this.mainTip.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.monthCalendar2.Location = new System.Drawing.Point(772, 32);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 5;
            this.mainTip.SetToolTip(this.monthCalendar2, "按日期浏览视频");
            this.monthCalendar2.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_MenuItem,
            this.Help_MenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1011, 25);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // File_MenuItem
            // 
            this.File_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMgr_MenuItem,
            this.Settings_MenuItem});
            this.File_MenuItem.Name = "File_MenuItem";
            this.File_MenuItem.Size = new System.Drawing.Size(44, 21);
            this.File_MenuItem.Text = "文件";
            // 
            // FileMgr_MenuItem
            // 
            this.FileMgr_MenuItem.Name = "FileMgr_MenuItem";
            this.FileMgr_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.F)));
            this.FileMgr_MenuItem.Size = new System.Drawing.Size(201, 22);
            this.FileMgr_MenuItem.Text = "管理中心";
            this.FileMgr_MenuItem.Click += new System.EventHandler(this.FileMgr_MenuItem_Click);
            // 
            // Settings_MenuItem
            // 
            this.Settings_MenuItem.Name = "Settings_MenuItem";
            this.Settings_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.S)));
            this.Settings_MenuItem.Size = new System.Drawing.Size(201, 22);
            this.Settings_MenuItem.Text = "设置";
            this.Settings_MenuItem.Click += new System.EventHandler(this.Settings_MenuItem_Click);
            // 
            // Help_MenuItem
            // 
            this.Help_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReadMe_MenuItem,
            this.About_MenuItem1});
            this.Help_MenuItem.Name = "Help_MenuItem";
            this.Help_MenuItem.Size = new System.Drawing.Size(44, 21);
            this.Help_MenuItem.Text = "帮助";
            // 
            // ReadMe_MenuItem
            // 
            this.ReadMe_MenuItem.Name = "ReadMe_MenuItem";
            this.ReadMe_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.H)));
            this.ReadMe_MenuItem.Size = new System.Drawing.Size(204, 22);
            this.ReadMe_MenuItem.Text = "使用说明";
            this.ReadMe_MenuItem.Click += new System.EventHandler(this.ReadMe_MenuItem_Click);
            // 
            // About_MenuItem1
            // 
            this.About_MenuItem1.Name = "About_MenuItem1";
            this.About_MenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.A)));
            this.About_MenuItem1.Size = new System.Drawing.Size(204, 22);
            this.About_MenuItem1.Text = "关于";
            this.About_MenuItem1.Click += new System.EventHandler(this.About_MenuItem1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.picLove);
            this.groupBox1.Controls.Add(this.picNote);
            this.groupBox1.Controls.Add(this.picPriv);
            this.groupBox1.Controls.Add(this.picBin);
            this.groupBox1.Controls.Add(this.picLoveGray);
            this.groupBox1.Controls.Add(this.picNoteGray);
            this.groupBox1.Controls.Add(this.picPrivGray);
            this.groupBox1.Controls.Add(this.picBinGray);
            this.groupBox1.Controls.Add(this.tbNote);
            this.groupBox1.Controls.Add(this.ck_ContinuMark);
            this.groupBox1.Location = new System.Drawing.Point(773, 221);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 318);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "备注";
            // 
            // picLove
            // 
            this.picLove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picLove.BackColor = System.Drawing.Color.Transparent;
            this.picLove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picLove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLove.Image = global::Com.Skewky.Cam.Properties.Resources.love;
            this.picLove.Location = new System.Drawing.Point(15, 268);
            this.picLove.Name = "picLove";
            this.picLove.Size = new System.Drawing.Size(40, 40);
            this.picLove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLove.TabIndex = 10;
            this.picLove.TabStop = false;
            this.picLove.Visible = false;
            this.picLove.Paint += new System.Windows.Forms.PaintEventHandler(this.picMarks_Paint);
            this.picLove.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picLove_MouseClick);
            // 
            // picNote
            // 
            this.picNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picNote.BackColor = System.Drawing.Color.Transparent;
            this.picNote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picNote.Image = global::Com.Skewky.Cam.Properties.Resources.Note;
            this.picNote.Location = new System.Drawing.Point(165, 268);
            this.picNote.Name = "picNote";
            this.picNote.Size = new System.Drawing.Size(40, 40);
            this.picNote.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picNote.TabIndex = 12;
            this.picNote.TabStop = false;
            this.picNote.Visible = false;
            this.picNote.Paint += new System.Windows.Forms.PaintEventHandler(this.picMarks_Paint);
            this.picNote.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picNote_MouseClick);
            // 
            // picPriv
            // 
            this.picPriv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picPriv.BackColor = System.Drawing.Color.Transparent;
            this.picPriv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPriv.Image = global::Com.Skewky.Cam.Properties.Resources.ys;
            this.picPriv.Location = new System.Drawing.Point(115, 268);
            this.picPriv.Name = "picPriv";
            this.picPriv.Size = new System.Drawing.Size(40, 40);
            this.picPriv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPriv.TabIndex = 12;
            this.picPriv.TabStop = false;
            this.picPriv.Visible = false;
            this.picPriv.Paint += new System.Windows.Forms.PaintEventHandler(this.picMarks_Paint);
            this.picPriv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picPriv_MouseClick);
            // 
            // picBin
            // 
            this.picBin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picBin.BackColor = System.Drawing.Color.Transparent;
            this.picBin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBin.Image = global::Com.Skewky.Cam.Properties.Resources.bin;
            this.picBin.Location = new System.Drawing.Point(65, 268);
            this.picBin.Name = "picBin";
            this.picBin.Size = new System.Drawing.Size(40, 40);
            this.picBin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBin.TabIndex = 11;
            this.picBin.TabStop = false;
            this.picBin.Visible = false;
            this.picBin.Paint += new System.Windows.Forms.PaintEventHandler(this.picMarks_Paint);
            this.picBin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picBin_MouseClick);
            // 
            // picLoveGray
            // 
            this.picLoveGray.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picLoveGray.BackColor = System.Drawing.Color.Transparent;
            this.picLoveGray.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picLoveGray.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLoveGray.Image = global::Com.Skewky.Cam.Properties.Resources.love_Gray;
            this.picLoveGray.Location = new System.Drawing.Point(15, 268);
            this.picLoveGray.Name = "picLoveGray";
            this.picLoveGray.Size = new System.Drawing.Size(40, 40);
            this.picLoveGray.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLoveGray.TabIndex = 10;
            this.picLoveGray.TabStop = false;
            this.picLoveGray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picLoveGray_MouseClick);
            // 
            // picNoteGray
            // 
            this.picNoteGray.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picNoteGray.BackColor = System.Drawing.Color.Transparent;
            this.picNoteGray.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picNoteGray.Image = global::Com.Skewky.Cam.Properties.Resources.NoteGray;
            this.picNoteGray.Location = new System.Drawing.Point(165, 268);
            this.picNoteGray.Name = "picNoteGray";
            this.picNoteGray.Size = new System.Drawing.Size(40, 40);
            this.picNoteGray.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picNoteGray.TabIndex = 12;
            this.picNoteGray.TabStop = false;
            this.picNoteGray.Click += new System.EventHandler(this.picNoteGray_Click);
            // 
            // picPrivGray
            // 
            this.picPrivGray.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picPrivGray.BackColor = System.Drawing.Color.Transparent;
            this.picPrivGray.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPrivGray.Image = global::Com.Skewky.Cam.Properties.Resources.ys_Gray;
            this.picPrivGray.Location = new System.Drawing.Point(115, 268);
            this.picPrivGray.Name = "picPrivGray";
            this.picPrivGray.Size = new System.Drawing.Size(40, 40);
            this.picPrivGray.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPrivGray.TabIndex = 12;
            this.picPrivGray.TabStop = false;
            this.picPrivGray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picPrivGray_MouseClick);
            // 
            // picBinGray
            // 
            this.picBinGray.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picBinGray.BackColor = System.Drawing.Color.Transparent;
            this.picBinGray.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBinGray.Image = global::Com.Skewky.Cam.Properties.Resources.bin_Gray;
            this.picBinGray.Location = new System.Drawing.Point(65, 268);
            this.picBinGray.Name = "picBinGray";
            this.picBinGray.Size = new System.Drawing.Size(40, 40);
            this.picBinGray.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBinGray.TabIndex = 11;
            this.picBinGray.TabStop = false;
            this.picBinGray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picBinGray_MouseClick);
            // 
            // tbNote
            // 
            this.tbNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNote.Location = new System.Drawing.Point(6, 20);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(208, 293);
            this.tbNote.TabIndex = 9;
            this.tbNote.TextChanged += new System.EventHandler(this.tbNote_TextChanged);
            // 
            // ck_ContinuMark
            // 
            this.ck_ContinuMark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ck_ContinuMark.AutoSize = true;
            this.ck_ContinuMark.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ck_ContinuMark.Location = new System.Drawing.Point(142, -1);
            this.ck_ContinuMark.Name = "ck_ContinuMark";
            this.ck_ContinuMark.Size = new System.Drawing.Size(72, 16);
            this.ck_ContinuMark.TabIndex = 8;
            this.ck_ContinuMark.Text = "持续备注";
            this.ck_ContinuMark.UseVisualStyleBackColor = true;
            this.ck_ContinuMark.CheckedChanged += new System.EventHandler(this.ck_ContinuMark_CheckedChanged);
            this.ck_ContinuMark.MouseHover += new System.EventHandler(this.ck_ContinuMark_MouseHover);
            // 
            // lbNowPlaying
            // 
            this.lbNowPlaying.AutoSize = true;
            this.lbNowPlaying.BackColor = System.Drawing.Color.Transparent;
            this.lbNowPlaying.Location = new System.Drawing.Point(195, 6);
            this.lbNowPlaying.Name = "lbNowPlaying";
            this.lbNowPlaying.Size = new System.Drawing.Size(0, 12);
            this.lbNowPlaying.TabIndex = 8;
            this.lbNowPlaying.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbNowPlaying_MouseDoubleClick);
            // 
            // vlcCtrl
            // 
            this.vlcCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vlcCtrl.Location = new System.Drawing.Point(12, 28);
            this.vlcCtrl.Name = "vlcCtrl";
            this.vlcCtrl.Size = new System.Drawing.Size(755, 468);
            this.vlcCtrl.TabIndex = 10;
            this.vlcCtrl.MouseEnter += new System.EventHandler(this.vlcCtrl_MouseEnter);
            this.vlcCtrl.MouseHover += new System.EventHandler(this.vlcCtrl_MouseHover);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 561);
            this.Controls.Add(this.lbNowPlaying);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.monthCalendar2);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelHandM);
            this.Controls.Add(this.vlcCtrl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1027, 600);
            this.Name = "MainForm";
            this.Text = "SkewkyCam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panelHandM.ResumeLayout(false);
            this.panelHandM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBhour)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPriv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoveGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNoteGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPrivGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBinGray)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHandM;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolTip mainTip;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
        private System.Windows.Forms.PictureBox pBmin;
        private System.Windows.Forms.PictureBox pBhour;
        private System.Windows.Forms.Label lbHour;
        private System.Windows.Forms.Label lbMinute;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem File_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileMgr_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Settings_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Help_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReadMe_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem About_MenuItem1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.CheckBox ck_ContinuMark;
        private System.Windows.Forms.ToolStripStatusLabel tssPlaySpeed;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.PictureBox picPriv;
        private System.Windows.Forms.PictureBox picBin;
        private System.Windows.Forms.PictureBox picLove;
        private System.Windows.Forms.PictureBox picLoveGray;
        private System.Windows.Forms.PictureBox picPrivGray;
        private System.Windows.Forms.PictureBox picBinGray;
        private System.Windows.Forms.ToolStripStatusLabel tssPause;
        private System.Windows.Forms.ToolStripStatusLabel tssNote;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.Label lbNowPlaying;
        private System.Windows.Forms.PictureBox picNote;
        private System.Windows.Forms.PictureBox picNoteGray;
        private Skewky.Vlc.VlcControl vlcCtrl;
    }
}

