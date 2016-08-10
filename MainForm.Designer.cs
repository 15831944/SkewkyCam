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
            this.panel2 = new System.Windows.Forms.Panel();
            this.txSound = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.tbVideoTime = new System.Windows.Forms.TextBox();
            this.pBmin = new System.Windows.Forms.PictureBox();
            this.pBhour = new System.Windows.Forms.PictureBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txSpeed = new System.Windows.Forms.Label();
            this.pBplayEnv = new System.Windows.Forms.PictureBox();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar3 = new System.Windows.Forms.MonthCalendar();
            this.lbSecond = new System.Windows.Forms.Label();
            this.lbMinute = new System.Windows.Forms.Label();
            this.lbHour = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBhour)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBplayEnv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lbHour);
            this.panel2.Controls.Add(this.lbMinute);
            this.panel2.Controls.Add(this.lbSecond);
            this.panel2.Controls.Add(this.txSound);
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Controls.Add(this.tbVideoTime);
            this.panel2.Controls.Add(this.pBmin);
            this.panel2.Controls.Add(this.pBhour);
            this.panel2.Location = new System.Drawing.Point(250, 583);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(722, 56);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // txSound
            // 
            this.txSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txSound.AutoSize = true;
            this.txSound.Location = new System.Drawing.Point(677, 4);
            this.txSound.Name = "txSound";
            this.txSound.Size = new System.Drawing.Size(35, 12);
            this.txSound.TabIndex = 7;
            this.txSound.Text = "Sound";
            this.txSound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(24, 2);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(519, 18);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // tbVideoTime
            // 
            this.tbVideoTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVideoTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbVideoTime.Location = new System.Drawing.Point(549, 4);
            this.tbVideoTime.Name = "tbVideoTime";
            this.tbVideoTime.ReadOnly = true;
            this.tbVideoTime.Size = new System.Drawing.Size(109, 14);
            this.tbVideoTime.TabIndex = 6;
            this.tbVideoTime.Text = "00:00:00/00:00:00";
            this.tbVideoTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pBmin
            // 
            this.pBmin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pBmin.BackColor = System.Drawing.SystemColors.Control;
            this.pBmin.Location = new System.Drawing.Point(24, 20);
            this.pBmin.Name = "pBmin";
            this.pBmin.Size = new System.Drawing.Size(698, 13);
            this.pBmin.TabIndex = 8;
            this.pBmin.TabStop = false;
            this.pBmin.Click += new System.EventHandler(this.pBmin_Click);
            this.pBmin.Paint += new System.Windows.Forms.PaintEventHandler(this.pBmin_Paint);
            this.pBmin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pBmin_MouseClick);
            this.pBmin.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pBmin_MouseDoubleClick);
            this.pBmin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pBmin_MouseMove);
            // 
            // pBhour
            // 
            this.pBhour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pBhour.BackColor = System.Drawing.SystemColors.Control;
            this.pBhour.Location = new System.Drawing.Point(24, 39);
            this.pBhour.Name = "pBhour";
            this.pBhour.Size = new System.Drawing.Size(698, 17);
            this.pBhour.TabIndex = 8;
            this.pBhour.TabStop = false;
            this.pBhour.Click += new System.EventHandler(this.pBhour_Click);
            this.pBhour.Paint += new System.Windows.Forms.PaintEventHandler(this.pBhour_Paint);
            this.pBhour.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pBhour_MouseDoubleClick);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(352, 1);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "浏览";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(250, 1);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
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
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 639);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Enabled = false;
            this.monthCalendar1.Location = new System.Drawing.Point(18, 18);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ShowToday = false;
            this.monthCalendar1.ShowTodayCircle = false;
            this.monthCalendar1.TabIndex = 5;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.txSpeed);
            this.panel1.Controls.Add(this.pBplayEnv);
            this.panel1.Location = new System.Drawing.Point(250, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(722, 553);
            this.panel1.TabIndex = 0;
            // 
            // txSpeed
            // 
            this.txSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txSpeed.AutoSize = true;
            this.txSpeed.BackColor = System.Drawing.Color.Crimson;
            this.txSpeed.Location = new System.Drawing.Point(8, 541);
            this.txSpeed.Name = "txSpeed";
            this.txSpeed.Size = new System.Drawing.Size(89, 12);
            this.txSpeed.TabIndex = 1;
            this.txSpeed.Text = "播放速度：8.0x";
            this.txSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txSpeed.Visible = false;
            // 
            // pBplayEnv
            // 
            this.pBplayEnv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pBplayEnv.BackColor = System.Drawing.Color.Transparent;
            this.pBplayEnv.Location = new System.Drawing.Point(2, -2);
            this.pBplayEnv.Name = "pBplayEnv";
            this.pBplayEnv.Size = new System.Drawing.Size(722, 556);
            this.pBplayEnv.TabIndex = 0;
            this.pBplayEnv.TabStop = false;
            this.pBplayEnv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pBplayEnv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pBplayEnv.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pBplayEnv.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            this.pBplayEnv.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseWheel);
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Location = new System.Drawing.Point(18, 189);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 5;
            this.monthCalendar2.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateChanged);
            // 
            // monthCalendar3
            // 
            this.monthCalendar3.Enabled = false;
            this.monthCalendar3.Location = new System.Drawing.Point(18, 363);
            this.monthCalendar3.Name = "monthCalendar3";
            this.monthCalendar3.ShowToday = false;
            this.monthCalendar3.ShowTodayCircle = false;
            this.monthCalendar3.TabIndex = 5;
            // 
            // lbSecond
            // 
            this.lbSecond.AutoSize = true;
            this.lbSecond.Location = new System.Drawing.Point(4, 4);
            this.lbSecond.Name = "lbSecond";
            this.lbSecond.Size = new System.Drawing.Size(17, 12);
            this.lbSecond.TabIndex = 9;
            this.lbSecond.Text = "秒";
            // 
            // lbMinute
            // 
            this.lbMinute.AutoSize = true;
            this.lbMinute.Location = new System.Drawing.Point(3, 21);
            this.lbMinute.Name = "lbMinute";
            this.lbMinute.Size = new System.Drawing.Size(17, 12);
            this.lbMinute.TabIndex = 9;
            this.lbMinute.Text = "分";
            // 
            // lbHour
            // 
            this.lbHour.AutoSize = true;
            this.lbHour.Location = new System.Drawing.Point(3, 39);
            this.lbHour.Name = "lbHour";
            this.lbHour.Size = new System.Drawing.Size(17, 12);
            this.lbHour.TabIndex = 9;
            this.lbHour.Text = "时";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.monthCalendar2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.monthCalendar3);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "MainForm";
            this.Text = "SkewkyCam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBhour)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBplayEnv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbVideoTime;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label txSound;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txSpeed;
        private System.Windows.Forms.PictureBox pBplayEnv;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
        private System.Windows.Forms.MonthCalendar monthCalendar3;
        private System.Windows.Forms.PictureBox pBmin;
        private System.Windows.Forms.PictureBox pBhour;
        private System.Windows.Forms.Label lbHour;
        private System.Windows.Forms.Label lbMinute;
        private System.Windows.Forms.Label lbSecond;
    }
}

