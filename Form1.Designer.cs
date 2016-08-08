namespace Com.Skewky.Cam
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txSound = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.tbVideoTime = new System.Windows.Forms.TextBox();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.myMonthCalendar1 = new Escape.Controls.MyMonthCalendar();
            this.myMonthCalendar2 = new Escape.Controls.MyMonthCalendar();
            this.myMonthCalendar3 = new Escape.Controls.MyMonthCalendar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txSpeed = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.txSpeed);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 569);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(737, 569);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            this.pictureBox1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseWheel);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.ForeColor = System.Drawing.SystemColors.Window;
            this.panel3.Location = new System.Drawing.Point(11, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(736, 569);
            this.panel3.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.txSound);
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Controls.Add(this.tbVideoTime);
            this.panel2.Location = new System.Drawing.Point(12, 598);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(736, 61);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // txSound
            // 
            this.txSound.AutoSize = true;
            this.txSound.Location = new System.Drawing.Point(2, 3);
            this.txSound.Name = "txSound";
            this.txSound.Size = new System.Drawing.Size(35, 13);
            this.txSound.TabIndex = 7;
            this.txSound.Text = "label1";
            this.txSound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(33, 1);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(602, 19);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // tbVideoTime
            // 
            this.tbVideoTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVideoTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbVideoTime.Location = new System.Drawing.Point(635, 3);
            this.tbVideoTime.Name = "tbVideoTime";
            this.tbVideoTime.ReadOnly = true;
            this.tbVideoTime.Size = new System.Drawing.Size(98, 13);
            this.tbVideoTime.TabIndex = 6;
            this.tbVideoTime.Text = "00:00:00/00:00:00";
            this.tbVideoTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // trackBar2
            // 
            this.trackBar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar2.AutoSize = false;
            this.trackBar2.Location = new System.Drawing.Point(257, 7);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(170, 10);
            this.trackBar2.TabIndex = 4;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(648, -1);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 25);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "关闭";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(567, -1);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 25);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1083, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 660);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1083, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // myMonthCalendar1
            // 
            this.myMonthCalendar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.myMonthCalendar1.BackColor = System.Drawing.Color.White;
            this.myMonthCalendar1.DayForeColor = System.Drawing.Color.Black;
            this.myMonthCalendar1.Location = new System.Drawing.Point(764, 27);
            this.myMonthCalendar1.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.myMonthCalendar1.MinDate = new System.DateTime(1901, 3, 1, 0, 0, 0, 0);
            this.myMonthCalendar1.Name = "myMonthCalendar1";
            this.myMonthCalendar1.SelectedSolarDate = new System.DateTime(2016, 8, 3, 0, 0, 0, 0);
            this.myMonthCalendar1.Size = new System.Drawing.Size(307, 170);
            this.myMonthCalendar1.SplitLinesColor = System.Drawing.Color.OliveDrab;
            this.myMonthCalendar1.SplitLinesStyle = Escape.Controls.MyMonthCalendar.SplitLStyle.None;
            this.myMonthCalendar1.TabIndex = 5;
            this.myMonthCalendar1.TitleColor = System.Drawing.Color.Black;
            this.myMonthCalendar1.TrailingForeColor = System.Drawing.Color.LightGray;
            this.myMonthCalendar1.WeekBackColor = System.Drawing.Color.OliveDrab;
            this.myMonthCalendar1.WeekForeColor = System.Drawing.Color.White;
            // 
            // myMonthCalendar2
            // 
            this.myMonthCalendar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.myMonthCalendar2.BackColor = System.Drawing.Color.White;
            this.myMonthCalendar2.DayForeColor = System.Drawing.Color.Black;
            this.myMonthCalendar2.Location = new System.Drawing.Point(764, 203);
            this.myMonthCalendar2.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.myMonthCalendar2.MinDate = new System.DateTime(1901, 3, 1, 0, 0, 0, 0);
            this.myMonthCalendar2.Name = "myMonthCalendar2";
            this.myMonthCalendar2.SelectedSolarDate = new System.DateTime(2016, 8, 3, 0, 0, 0, 0);
            this.myMonthCalendar2.Size = new System.Drawing.Size(307, 170);
            this.myMonthCalendar2.SplitLinesColor = System.Drawing.Color.OliveDrab;
            this.myMonthCalendar2.SplitLinesStyle = Escape.Controls.MyMonthCalendar.SplitLStyle.None;
            this.myMonthCalendar2.TabIndex = 5;
            this.myMonthCalendar2.TitleColor = System.Drawing.Color.Black;
            this.myMonthCalendar2.TrailingForeColor = System.Drawing.Color.LightGray;
            this.myMonthCalendar2.WeekBackColor = System.Drawing.Color.OliveDrab;
            this.myMonthCalendar2.WeekForeColor = System.Drawing.Color.White;
            // 
            // myMonthCalendar3
            // 
            this.myMonthCalendar3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.myMonthCalendar3.BackColor = System.Drawing.Color.White;
            this.myMonthCalendar3.DayForeColor = System.Drawing.Color.Black;
            this.myMonthCalendar3.Location = new System.Drawing.Point(764, 379);
            this.myMonthCalendar3.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.myMonthCalendar3.MinDate = new System.DateTime(1901, 3, 1, 0, 0, 0, 0);
            this.myMonthCalendar3.Name = "myMonthCalendar3";
            this.myMonthCalendar3.SelectedSolarDate = new System.DateTime(2016, 8, 3, 0, 0, 0, 0);
            this.myMonthCalendar3.Size = new System.Drawing.Size(307, 170);
            this.myMonthCalendar3.SplitLinesColor = System.Drawing.Color.OliveDrab;
            this.myMonthCalendar3.SplitLinesStyle = Escape.Controls.MyMonthCalendar.SplitLStyle.None;
            this.myMonthCalendar3.TabIndex = 5;
            this.myMonthCalendar3.TitleColor = System.Drawing.Color.Black;
            this.myMonthCalendar3.TrailingForeColor = System.Drawing.Color.LightGray;
            this.myMonthCalendar3.WeekBackColor = System.Drawing.Color.OliveDrab;
            this.myMonthCalendar3.WeekForeColor = System.Drawing.Color.White;
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // txSpeed
            // 
            this.txSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txSpeed.AutoSize = true;
            this.txSpeed.BackColor = System.Drawing.Color.Crimson;
            this.txSpeed.Location = new System.Drawing.Point(655, 556);
            this.txSpeed.Name = "txSpeed";
            this.txSpeed.Size = new System.Drawing.Size(81, 13);
            this.txSpeed.TabIndex = 1;
            this.txSpeed.Text = "播放速度：8.0x";
            this.txSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txSpeed.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1083, 682);
            this.Controls.Add(this.myMonthCalendar3);
            this.Controls.Add(this.myMonthCalendar2);
            this.Controls.Add(this.myMonthCalendar1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SkewkyCam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbVideoTime;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private Escape.Controls.MyMonthCalendar myMonthCalendar1;
        private Escape.Controls.MyMonthCalendar myMonthCalendar2;
        private Escape.Controls.MyMonthCalendar myMonthCalendar3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txSound;
        private System.Windows.Forms.Label txSpeed;
    }
}

