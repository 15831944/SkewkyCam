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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbSound = new System.Windows.Forms.Label();
            this.lbSpeed = new System.Windows.Forms.Label();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.tbSound = new System.Windows.Forms.TrackBar();
            this.ckAutoplay = new System.Windows.Forms.CheckBox();
            this.cbRecType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lbSpeedMin = new System.Windows.Forms.Label();
            this.lbSpeed1 = new System.Windows.Forms.Label();
            this.lbSpeedMax = new System.Windows.Forms.Label();
            this.lbSoundMin = new System.Windows.Forms.Label();
            this.lbSound100 = new System.Windows.Forms.Label();
            this.lbSoundMax = new System.Windows.Forms.Label();
            this.lbSound50 = new System.Windows.Forms.Label();
            this.listRootDirs = new System.Windows.Forms.ListView();
            this.btAdd = new System.Windows.Forms.Button();
            this.btDel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            // lbSound
            // 
            this.lbSound.AutoSize = true;
            this.lbSound.Location = new System.Drawing.Point(82, 91);
            this.lbSound.Name = "lbSound";
            this.lbSound.Size = new System.Drawing.Size(23, 12);
            this.lbSound.TabIndex = 9;
            this.lbSound.Text = "200";
            // 
            // lbSpeed
            // 
            this.lbSpeed.AutoSize = true;
            this.lbSpeed.Location = new System.Drawing.Point(83, 152);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.Size = new System.Drawing.Size(17, 12);
            this.lbSpeed.TabIndex = 8;
            this.lbSpeed.Text = "16";
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(103, 142);
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
            this.tbSound.Location = new System.Drawing.Point(104, 81);
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
            this.ckAutoplay.Location = new System.Drawing.Point(82, 212);
            this.ckAutoplay.Name = "ckAutoplay";
            this.ckAutoplay.Size = new System.Drawing.Size(15, 14);
            this.ckAutoplay.TabIndex = 6;
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
            this.cbRecType.Text = "小米摄像头";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "连续播放：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "播放速度：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 92);
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
            // lbSpeedMin
            // 
            this.lbSpeedMin.AutoSize = true;
            this.lbSpeedMin.Location = new System.Drawing.Point(107, 174);
            this.lbSpeedMin.Name = "lbSpeedMin";
            this.lbSpeedMin.Size = new System.Drawing.Size(23, 12);
            this.lbSpeedMin.TabIndex = 10;
            this.lbSpeedMin.Text = "0.1";
            this.lbSpeedMin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbSpeedMin_MouseClick);
            // 
            // lbSpeed1
            // 
            this.lbSpeed1.AutoSize = true;
            this.lbSpeed1.Location = new System.Drawing.Point(151, 174);
            this.lbSpeed1.Name = "lbSpeed1";
            this.lbSpeed1.Size = new System.Drawing.Size(11, 12);
            this.lbSpeed1.TabIndex = 10;
            this.lbSpeed1.Text = "1";
            this.lbSpeed1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbSpeed1_MouseClick);
            // 
            // lbSpeedMax
            // 
            this.lbSpeedMax.AutoSize = true;
            this.lbSpeedMax.Location = new System.Drawing.Point(228, 174);
            this.lbSpeedMax.Name = "lbSpeedMax";
            this.lbSpeedMax.Size = new System.Drawing.Size(17, 12);
            this.lbSpeedMax.TabIndex = 10;
            this.lbSpeedMax.Text = "16";
            this.lbSpeedMax.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbSpeedMax_MouseClick);
            // 
            // lbSoundMin
            // 
            this.lbSoundMin.AutoSize = true;
            this.lbSoundMin.Location = new System.Drawing.Point(113, 113);
            this.lbSoundMin.Name = "lbSoundMin";
            this.lbSoundMin.Size = new System.Drawing.Size(11, 12);
            this.lbSoundMin.TabIndex = 11;
            this.lbSoundMin.Text = "0";
            this.lbSoundMin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbSoundMin_MouseClick);
            // 
            // lbSound100
            // 
            this.lbSound100.AutoSize = true;
            this.lbSound100.Location = new System.Drawing.Point(165, 113);
            this.lbSound100.Name = "lbSound100";
            this.lbSound100.Size = new System.Drawing.Size(23, 12);
            this.lbSound100.TabIndex = 12;
            this.lbSound100.Text = "100";
            this.lbSound100.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbSound100_MouseClick);
            // 
            // lbSoundMax
            // 
            this.lbSoundMax.AutoSize = true;
            this.lbSoundMax.Location = new System.Drawing.Point(226, 113);
            this.lbSoundMax.Name = "lbSoundMax";
            this.lbSoundMax.Size = new System.Drawing.Size(23, 12);
            this.lbSoundMax.TabIndex = 12;
            this.lbSoundMax.Text = "200";
            this.lbSoundMax.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbSoundMax_MouseClick);
            // 
            // lbSound50
            // 
            this.lbSound50.AutoSize = true;
            this.lbSound50.Location = new System.Drawing.Point(139, 113);
            this.lbSound50.Name = "lbSound50";
            this.lbSound50.Size = new System.Drawing.Size(17, 12);
            this.lbSound50.TabIndex = 13;
            this.lbSound50.Text = "50";
            this.lbSound50.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbSound50_MouseClick);
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
            this.Text = "SettingsForm";
            this.Click += new System.EventHandler(this.SettingsForm_Click);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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


    }
}