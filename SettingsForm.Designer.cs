namespace Com.Skewky.Cam
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btDel = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.listRootDirs = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pbDemo = new System.Windows.Forms.PictureBox();
            this.btBg = new System.Windows.Forms.Button();
            this.btNormal = new System.Windows.Forms.Button();
            this.btNote = new System.Windows.Forms.Button();
            this.btPriv = new System.Windows.Forms.Button();
            this.btToDel = new System.Windows.Forms.Button();
            this.btLove = new System.Windows.Forms.Button();
            this.lbSound50 = new System.Windows.Forms.Label();
            this.lbSoundMax = new System.Windows.Forms.Label();
            this.lbSound100 = new System.Windows.Forms.Label();
            this.lbSoundMin = new System.Windows.Forms.Label();
            this.lbSpeedMax = new System.Windows.Forms.Label();
            this.lbSpeed1 = new System.Windows.Forms.Label();
            this.lbSpeedMin = new System.Windows.Forms.Label();
            this.lbSound = new System.Windows.Forms.Label();
            this.lbSpeed = new System.Windows.Forms.Label();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.tbSound = new System.Windows.Forms.TrackBar();
            this.ckAutoplay = new System.Windows.Forms.CheckBox();
            this.cbRecType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSound)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btDel);
            this.groupBox1.Controls.Add(this.btAdd);
            this.groupBox1.Controls.Add(this.listRootDirs);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 306);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "视频根目录";
            // 
            // btDel
            // 
            this.btDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDel.Location = new System.Drawing.Point(117, 277);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(75, 23);
            this.btDel.TabIndex = 2;
            this.btDel.Text = "删除";
            this.btDel.UseVisualStyleBackColor = true;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Location = new System.Drawing.Point(26, 277);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(75, 23);
            this.btAdd.TabIndex = 1;
            this.btAdd.Text = "添加";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // listRootDirs
            // 
            this.listRootDirs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listRootDirs.Location = new System.Drawing.Point(7, 21);
            this.listRootDirs.Name = "listRootDirs";
            this.listRootDirs.Size = new System.Drawing.Size(206, 248);
            this.listRootDirs.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listRootDirs.TabIndex = 0;
            this.listRootDirs.UseCompatibleStateImageBehavior = false;
            this.listRootDirs.View = System.Windows.Forms.View.List;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.pbDemo);
            this.groupBox2.Controls.Add(this.btBg);
            this.groupBox2.Controls.Add(this.btNormal);
            this.groupBox2.Controls.Add(this.btNote);
            this.groupBox2.Controls.Add(this.btPriv);
            this.groupBox2.Controls.Add(this.btToDel);
            this.groupBox2.Controls.Add(this.btLove);
            this.groupBox2.Controls.Add(this.lbSound50);
            this.groupBox2.Controls.Add(this.lbSoundMax);
            this.groupBox2.Controls.Add(this.lbSound100);
            this.groupBox2.Controls.Add(this.lbSoundMin);
            this.groupBox2.Controls.Add(this.lbSpeedMax);
            this.groupBox2.Controls.Add(this.lbSpeed1);
            this.groupBox2.Controls.Add(this.lbSpeedMin);
            this.groupBox2.Controls.Add(this.lbSound);
            this.groupBox2.Controls.Add(this.lbSpeed);
            this.groupBox2.Controls.Add(this.tbSpeed);
            this.groupBox2.Controls.Add(this.tbSound);
            this.groupBox2.Controls.Add(this.ckAutoplay);
            this.groupBox2.Controls.Add(this.cbRecType);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(239, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 269);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "其它设置";
            // 
            // pbDemo
            // 
            this.pbDemo.Location = new System.Drawing.Point(18, 229);
            this.pbDemo.Name = "pbDemo";
            this.pbDemo.Size = new System.Drawing.Size(48, 22);
            this.pbDemo.TabIndex = 15;
            this.pbDemo.TabStop = false;
            this.pbDemo.Tag = "1";
            this.pbDemo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbDemo_MouseDoubleClick);
            // 
            // btBg
            // 
            this.btBg.Location = new System.Drawing.Point(181, 230);
            this.btBg.Name = "btBg";
            this.btBg.Size = new System.Drawing.Size(44, 21);
            this.btBg.TabIndex = 14;
            this.btBg.Text = "背景";
            this.btBg.UseVisualStyleBackColor = true;
            this.btBg.Click += new System.EventHandler(this.btBg_Click);
            // 
            // btNormal
            // 
            this.btNormal.Location = new System.Drawing.Point(181, 203);
            this.btNormal.Name = "btNormal";
            this.btNormal.Size = new System.Drawing.Size(44, 21);
            this.btNormal.TabIndex = 14;
            this.btNormal.Text = "普通";
            this.btNormal.UseVisualStyleBackColor = true;
            this.btNormal.Click += new System.EventHandler(this.btNormal_Click);
            // 
            // btNote
            // 
            this.btNote.Location = new System.Drawing.Point(132, 230);
            this.btNote.Name = "btNote";
            this.btNote.Size = new System.Drawing.Size(44, 21);
            this.btNote.TabIndex = 14;
            this.btNote.Text = "备注";
            this.btNote.UseVisualStyleBackColor = true;
            this.btNote.Click += new System.EventHandler(this.btNote_Click);
            // 
            // btPriv
            // 
            this.btPriv.Location = new System.Drawing.Point(82, 230);
            this.btPriv.Name = "btPriv";
            this.btPriv.Size = new System.Drawing.Size(44, 21);
            this.btPriv.TabIndex = 14;
            this.btPriv.Text = "隐私";
            this.btPriv.UseVisualStyleBackColor = true;
            this.btPriv.Click += new System.EventHandler(this.btPriv_Click);
            // 
            // btToDel
            // 
            this.btToDel.Location = new System.Drawing.Point(132, 203);
            this.btToDel.Name = "btToDel";
            this.btToDel.Size = new System.Drawing.Size(44, 21);
            this.btToDel.TabIndex = 14;
            this.btToDel.Text = "待删";
            this.btToDel.UseVisualStyleBackColor = true;
            this.btToDel.Click += new System.EventHandler(this.btToDel_Click);
            // 
            // btLove
            // 
            this.btLove.Location = new System.Drawing.Point(82, 203);
            this.btLove.Name = "btLove";
            this.btLove.Size = new System.Drawing.Size(44, 21);
            this.btLove.TabIndex = 14;
            this.btLove.Text = "喜爱";
            this.btLove.UseVisualStyleBackColor = true;
            this.btLove.Click += new System.EventHandler(this.btLove_Click);
            // 
            // lbSound50
            // 
            this.lbSound50.AutoSize = true;
            this.lbSound50.Location = new System.Drawing.Point(139, 98);
            this.lbSound50.Name = "lbSound50";
            this.lbSound50.Size = new System.Drawing.Size(17, 12);
            this.lbSound50.TabIndex = 13;
            this.lbSound50.Text = "50";
            this.lbSound50.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbSound50_MouseClick);
            // 
            // lbSoundMax
            // 
            this.lbSoundMax.AutoSize = true;
            this.lbSoundMax.Location = new System.Drawing.Point(226, 98);
            this.lbSoundMax.Name = "lbSoundMax";
            this.lbSoundMax.Size = new System.Drawing.Size(23, 12);
            this.lbSoundMax.TabIndex = 12;
            this.lbSoundMax.Text = "200";
            this.lbSoundMax.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbSoundMax_MouseClick);
            // 
            // lbSound100
            // 
            this.lbSound100.AutoSize = true;
            this.lbSound100.Location = new System.Drawing.Point(165, 98);
            this.lbSound100.Name = "lbSound100";
            this.lbSound100.Size = new System.Drawing.Size(23, 12);
            this.lbSound100.TabIndex = 12;
            this.lbSound100.Text = "100";
            this.lbSound100.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbSound100_MouseClick);
            // 
            // lbSoundMin
            // 
            this.lbSoundMin.AutoSize = true;
            this.lbSoundMin.Location = new System.Drawing.Point(113, 98);
            this.lbSoundMin.Name = "lbSoundMin";
            this.lbSoundMin.Size = new System.Drawing.Size(11, 12);
            this.lbSoundMin.TabIndex = 11;
            this.lbSoundMin.Text = "0";
            this.lbSoundMin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbSoundMin_MouseClick);
            // 
            // lbSpeedMax
            // 
            this.lbSpeedMax.AutoSize = true;
            this.lbSpeedMax.Location = new System.Drawing.Point(228, 145);
            this.lbSpeedMax.Name = "lbSpeedMax";
            this.lbSpeedMax.Size = new System.Drawing.Size(17, 12);
            this.lbSpeedMax.TabIndex = 10;
            this.lbSpeedMax.Text = "16";
            this.lbSpeedMax.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbSpeedMax_MouseClick);
            // 
            // lbSpeed1
            // 
            this.lbSpeed1.AutoSize = true;
            this.lbSpeed1.Location = new System.Drawing.Point(151, 145);
            this.lbSpeed1.Name = "lbSpeed1";
            this.lbSpeed1.Size = new System.Drawing.Size(11, 12);
            this.lbSpeed1.TabIndex = 10;
            this.lbSpeed1.Text = "1";
            this.lbSpeed1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbSpeed1_MouseClick);
            // 
            // lbSpeedMin
            // 
            this.lbSpeedMin.AutoSize = true;
            this.lbSpeedMin.Location = new System.Drawing.Point(107, 145);
            this.lbSpeedMin.Name = "lbSpeedMin";
            this.lbSpeedMin.Size = new System.Drawing.Size(23, 12);
            this.lbSpeedMin.TabIndex = 10;
            this.lbSpeedMin.Text = "0.1";
            this.lbSpeedMin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbSpeedMin_MouseClick);
            // 
            // lbSound
            // 
            this.lbSound.AutoSize = true;
            this.lbSound.Location = new System.Drawing.Point(82, 77);
            this.lbSound.Name = "lbSound";
            this.lbSound.Size = new System.Drawing.Size(23, 12);
            this.lbSound.TabIndex = 9;
            this.lbSound.Text = "200";
            // 
            // lbSpeed
            // 
            this.lbSpeed.AutoSize = true;
            this.lbSpeed.Location = new System.Drawing.Point(83, 123);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.Size = new System.Drawing.Size(17, 12);
            this.lbSpeed.TabIndex = 8;
            this.lbSpeed.Text = "16";
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(103, 113);
            this.tbSpeed.Maximum = 6;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(144, 45);
            this.tbSpeed.TabIndex = 7;
            this.tbSpeed.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbSpeed.Value = 2;
            this.tbSpeed.Scroll += new System.EventHandler(this.trackBarSpeed_Scroll);
            this.tbSpeed.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            // 
            // tbSound
            // 
            this.tbSound.Location = new System.Drawing.Point(104, 66);
            this.tbSound.Maximum = 200;
            this.tbSound.Name = "tbSound";
            this.tbSound.Size = new System.Drawing.Size(144, 45);
            this.tbSound.TabIndex = 7;
            this.tbSound.TickFrequency = 10;
            this.tbSound.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbSound.Value = 50;
            this.tbSound.Scroll += new System.EventHandler(this.tbSound_Scroll);
            this.tbSound.ValueChanged += new System.EventHandler(this.tbSound_ValueChanged);
            // 
            // ckAutoplay
            // 
            this.ckAutoplay.AutoSize = true;
            this.ckAutoplay.Location = new System.Drawing.Point(82, 169);
            this.ckAutoplay.Name = "ckAutoplay";
            this.ckAutoplay.Size = new System.Drawing.Size(168, 16);
            this.ckAutoplay.TabIndex = 6;
            this.ckAutoplay.Text = "当前播完后自动播放下一个";
            this.ckAutoplay.UseVisualStyleBackColor = true;
            // 
            // cbRecType
            // 
            this.cbRecType.AllowDrop = true;
            this.cbRecType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRecType.FormattingEnabled = true;
            this.cbRecType.Items.AddRange(new object[] {
            "小米摄像头",
            "太阳花"});
            this.cbRecType.Location = new System.Drawing.Point(80, 35);
            this.cbRecType.Name = "cbRecType";
            this.cbRecType.Size = new System.Drawing.Size(166, 20);
            this.cbRecType.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "视频类型：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "颜色设置：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "连续播放：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "播放速度：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "播放音量：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(277, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(389, 291);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "确定";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(504, 331);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(520, 370);
            this.Name = "SettingsForm";
            this.Text = "设置";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.Click += new System.EventHandler(this.SettingsForm_Click);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSound)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckAutoplay;
        private System.Windows.Forms.ComboBox cbRecType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.TrackBar tbSound;
        private System.Windows.Forms.Label lbSpeed;
        private System.Windows.Forms.Label lbSound;
        private System.Windows.Forms.Label lbSpeedMax;
        private System.Windows.Forms.Label lbSpeed1;
        private System.Windows.Forms.Label lbSpeedMin;
        private System.Windows.Forms.Label lbSoundMax;
        private System.Windows.Forms.Label lbSound100;
        private System.Windows.Forms.Label lbSoundMin;
        private System.Windows.Forms.Label lbSound50;
        private System.Windows.Forms.Button btDel;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.ListView listRootDirs;
        private System.Windows.Forms.Button btBg;
        private System.Windows.Forms.Button btNormal;
        private System.Windows.Forms.Button btNote;
        private System.Windows.Forms.Button btPriv;
        private System.Windows.Forms.Button btToDel;
        private System.Windows.Forms.Button btLove;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.PictureBox pbDemo;
        private System.Windows.Forms.Timer timer1;


    }
}