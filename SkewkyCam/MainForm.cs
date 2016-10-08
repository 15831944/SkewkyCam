using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Com.Skewky.Cam
{
    public partial class MainForm : Form
    {
        private VlcPlayer vlc_player_;
        private VlcPlayer vlc_player_Next;
        private bool bFindNext;
        private bool is_playing_;
        private bool is_fullScreen_;
        private FileParseBase fileParseTool;
        private DateTime curDt;
        private ConfigSettings cfsettings;
        Thread trdFindNextFile = null;
        Thread trdFileMgr = null;

        public MainForm()
        {


            is_playing_ = false;
            is_fullScreen_ = false;
            bFindNext = false;
            cfsettings = new ConfigSettings();
            loadConfig();

            InitFileParseTool();

            InitializeComponent();

            this.KeyPreview = true;

            vlc_player_ = newVlcPlayer();
            vlc_player_Next = newVlcPlayer();
            txSound.Text = string.Format("{0}", cfsettings.iValume);
            tbVideoTime.Text = "00:00:00/00:00:00";
            resetTimerInterval();
            pBmin.BackColor = cfsettings.myColors.clrBg;
            pBhour.BackColor = cfsettings.myColors.clrBg;
        }
        private VlcPlayer newVlcPlayer()
        {
            string pluginPath = System.Environment.CurrentDirectory + "\\vlc\\plugins\\";
            VlcPlayer vlcPlayer = new VlcPlayer(pluginPath);
            IntPtr render_wnd = this.panel1.Handle;
            vlcPlayer.SetRenderWindow((int)render_wnd);
            return vlcPlayer;
        }
        private string configFile()
        {
            return System.Environment.CurrentDirectory + "\\config.ske";
        }
        public void saveConfig()
        {
            try
            {
                //cfsettings.iValume = 50;
                //cfsettings.iRecType = 15;
                string filePath = configFile();
                Stream s = File.Open(filePath, FileMode.Create, FileAccess.ReadWrite);
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(s, cfsettings);
                s.Close();
            }
            catch (Exception)
            {

            }

        }

        public void loadConfig()
        {
            cfsettings = new ConfigSettings();
            string filePath = configFile();
            try
            {
                if (File.Exists(filePath))
                {
                    Stream s = File.Open(filePath, FileMode.Open, FileAccess.Read);
                    BinaryFormatter c = new BinaryFormatter();
                    cfsettings = (ConfigSettings)c.Deserialize(s);
                    cfsettings.initLoadFaildValues();
                    cfsettings.myColors = new ThemeColors();
                    s.Close();
                }
            }
            catch (Exception)
            {
                File.Delete(filePath);
            }

        }
        private void InitFileParseTool()
        {
            switch (cfsettings.iRecType)
            {
                case 0: //XiaoMi
                    fileParseTool = new FileParseXiaoMi();
                    break;
                default:
                    fileParseTool = new FileParseXiaoMi();
                    break;
            }
            fileParseTool.setRootDir(cfsettings.rootDirArr);
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                cfsettings.rootDirArr[0] = fileParseTool.getRootDirByPath(ofd.FileName);
                InitFileParseTool();
                PlayRecord(ofd.FileName);
                UpdateCalender(true);
            }
        }
        private void PlayRecord(string path, bool AutoPlayNext = false)
        {
            curDt = fileParseTool.getDtMinByPath(path);
            //AutoPlayNext = false;
            if (bFindNext && AutoPlayNext)
            {
                vlc_player_.Copy(vlc_player_Next);
                vlc_player_.Pause();

                updatePlayStatus_Start();
                updateHourAndMinView();
                UpdateSpeed();
                threadFindNextFile();

            }
            if (System.IO.File.Exists(path))
            {
                vlc_player_.PlayFile(path);
                updatePlayStatus_Start();
                updateHourAndMinView();
                UpdateSpeed();
                threadFindNextFile();
            }
        }
        private void PlayRecord(DateTime dt, bool AutoPlayNext = false)
        {
            string path = fileParseTool.MinutePath(dt);
            PlayRecord(path, AutoPlayNext);
        }
        private void PrepearNextFile()
        {
            bFindNext = false;
            DateTime nextDt = curDt;
            if (fileParseTool.findNextDt(curDt, ref nextDt))
            {
                string nextfilePath = fileParseTool.MinutePath(nextDt);
                vlc_player_Next.PrepareFile(nextfilePath);
                bFindNext = true;
            }
        }

        private void threadFindNextFile()
        {
            vlc_player_Next = newVlcPlayer();
            trdFindNextFile = new Thread(this.PrepearNextFile);
            trdFindNextFile.Start();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = cfsettings.rootDirArr[0];
            folderBrowserDialog.ShowNewFolderButton = false;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (cfsettings.rootDirArr[0] != folderBrowserDialog.SelectedPath)
                {
                    cfsettings.rootDirArr[0] = folderBrowserDialog.SelectedPath;
                    InitFileParseTool();
                    UpdateCalender(true);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (is_playing_)
            {
                double playTime = vlc_player_.GetPlayTime();
                double duraTime = vlc_player_.Duration();
                bool bIsPlayEnded = vlc_player_.isPlayEnded();
                if (bIsPlayEnded)
                {
                    updatePlayStatus_Stop();
                    DateTime nextDt = curDt;
                    if (fileParseTool.findNextDt(curDt, ref nextDt))
                    {
                        PlayRecord(nextDt, true);
                    }
                    else
                    {
                        string msg = string.Format("没有找到下一个要播放文件");
                        toolTip1.Show(msg, pBmin, 15, 15, 3);
                    }
                }
                else
                {
                    int curVal = trackBar1.Value + (int)(1000 * cfsettings.getDoubleSpeed());
                    curVal = Math.Max(trackBar1.Minimum, curVal);
                    curVal = Math.Min(trackBar1.Maximum, curVal);
                    double curPlayTime = vlc_player_.GetPlayTime() * 1000;
                    curPlayTime = Math.Max(trackBar1.Minimum, curPlayTime);
                    curPlayTime = Math.Min(trackBar1.Maximum, curPlayTime);
                    trackBar1.Value = (int)curPlayTime;
                    tbVideoTime.Text = string.Format("{0}/{1}",
                        GetTimeString(trackBar1.Value / 1000),
                        GetTimeString(trackBar1.Maximum / 1000));
                }
            }
        }

        private string GetTimeString(int val)
        {
            int hour = val / 3600;
            val %= 3600;
            int minute = val / 60;
            int second = val % 60;
            return string.Format("{0:00}:{1:00}:{2:00}", hour, minute, second);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (is_playing_)
            {
                vlc_player_.SetPlayTime(trackBar1.Value/1000.0);
                trackBar1.Value = (int)vlc_player_.GetPlayTime();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            updateHourAndMinView_Force();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            vlc_player_.Stop();
            saveConfig();
            SaveMarkData();
            fileParseTool.saveMarkFiles();
            if (trdFindNextFile != null)
            {
                trdFindNextFile.Abort();
            }
        }

        #region PlayEnvMouseEnv
        private void pBplayEnv_MouseWheel(object sender, MouseEventArgs e)
        {
            updateVolume(e.Delta == 120);

        }
        private void pBplayEnv_MouseEnter(object sender, EventArgs e)
        {
            this.pBplayEnv.Focus();

        }

        private void pBplayEnv_MouseHover(object sender, EventArgs e)
        {
            this.pBplayEnv.Focus();

        }

        private void pBplayEnv_MouseClick(object sender, MouseEventArgs e)
        {
            MouseButtons clk = e.Button;
            if (clk == MouseButtons.Left)
            {
                // togglePlay();
            }
            if (clk == MouseButtons.Middle)
            {
                toggleFullScreen();
            }

        }

        private void pBplayEnv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                togglePlay();
        }
        private void pBplayEnv_Click(object sender, EventArgs e)
        {

        }
        #endregion



        private void toggleFullScreen()
        {
            is_fullScreen_ = !is_fullScreen_;
            vlc_player_.SetFullScreen(is_fullScreen_);
        }
        private void togglePlay()
        {
            if (is_playing_)
            {
                vlc_player_.Pause();
                timer1.Stop();
                tssPause.Text = "已暂停";
                is_playing_ = false;
            }
            else
            {
                vlc_player_.Play();
                timer1.Start();
                tssPause.Text = "";
                is_playing_ = true;
            }
        }


        #region Key Envents
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.Control && e.Shift)
            {
                //pressed all the control keys
                //Do some thing
            }
            else if (e.Alt && e.Control)
            {
            }
            else if (e.Alt && e.Shift)
            {
            }
            else if (e.Shift && e.Control)
            {    
                KeyEnv_FileForm(sender, e);
                KeyEnv_SettingsForm(sender, e);
                KeyEnv_AboutForm(sender, e);
                KeyEnv_HelpForm(sender, e);
           
            }
            else if (e.Alt)
            {
                KeyEnv_TogglePlay(sender, e);
               
            }
            else if (e.Control)
            {
                 KeyEnv_Speed(sender, e);
                 KeyEnv_Marks(sender,e);
            }
            else if (e.Shift)
            {
                if (e.KeyCode == Keys.S)
                {
                    MergeFilesForm mff = new MergeFilesForm();
                    mff.playTestFile();
                    mff.ShowDialog();
                 }
            }
            else //Normal key input
            {
                KeyEnv_Process(sender, e);
                KeyEnv_Sound(sender, e);
            }
        }
        private void KeyEnv_TogglePlay(object sender, KeyEventArgs e)
        {
            if (Keys.Space == e.KeyCode)
            {
                togglePlay();
            }
        }
        private void KeyEnv_Speed(object sender, KeyEventArgs e)
        {
            if (Keys.Up == e.KeyCode ||
                Keys.Down == e.KeyCode)
            {
                int curSpd = cfsettings.iPlaySpeed;
                //加速
                if (Keys.Up == e.KeyCode)
                {
                    curSpd += 1;
                }
                //减速
                if (Keys.Down == e.KeyCode)
                {
                    curSpd -= 1;
                }
                cfsettings.iPlaySpeed = Math.Max(curSpd, 0);
                cfsettings.iPlaySpeed = Math.Min(curSpd, 6);
                UpdateSpeed();
            }
        }
        private void KeyEnv_Sound(object sender, KeyEventArgs e)
        {
            if (Keys.Up == e.KeyCode ||
                Keys.Down == e.KeyCode)
            {
                //加速
                updateVolume(Keys.Up == e.KeyCode);
            }
        }
        private void KeyEnv_Process(object sender, KeyEventArgs e)
        {
            if (Keys.Left == e.KeyCode ||
                Keys.Right == e.KeyCode)
            {
                int iSpeedStep = 5000;      //5s per step
                int dureTime = (int)vlc_player_.Duration();
                //前进
                if (Keys.Left == e.KeyCode)
                {
                   iSpeedStep = -iSpeedStep;
                }
                //后退
                if (Keys.Right == e.KeyCode)
                {
                   
                }
                int newPlayTime = trackBar1.Value + iSpeedStep;
                double dNewPlayTime = newPlayTime / 1000.0;
                dNewPlayTime = Math.Max(0, dNewPlayTime);
                dNewPlayTime = Math.Min(dNewPlayTime, vlc_player_.Duration());
                vlc_player_.SetPlayTime(dNewPlayTime);
                vlc_player_.Play();
                //trackBar1.Value = (int)vlc_player_.GetPlayTime();
            }

        }
        private void KeyEnv_FileForm(object sender, KeyEventArgs e)
        {
            if (Keys.F == e.KeyCode)
            {
                ShowFileMgrForm();
            }
        }
        private void KeyEnv_SettingsForm(object sender, KeyEventArgs e)
        {
            if (Keys.S == e.KeyCode)
            {
                ShowSettingsForm();
            }
        }
        private void KeyEnv_AboutForm(object sender, KeyEventArgs e)
        {
            if (Keys.A == e.KeyCode)
            {
                ShowAboutForm();
            }
        }
        private void KeyEnv_HelpForm(object sender, KeyEventArgs e)
        {
            if (Keys.H == e.KeyCode)
            {
                ShowHelpForm();
            }
        }
        private void KeyEnv_Marks(object sender, KeyEventArgs e)
        {
            if (!nowValid())
                return;
            if (Keys.D1== e.KeyCode||
                Keys.NumPad1 == e.KeyCode)
            {
                picLove.Visible = !picLove.Visible;
            }
            else if (Keys.D2== e.KeyCode||
                Keys.NumPad2 == e.KeyCode)
            {
                picBin.Visible = !picBin.Visible;
            }
            else if (Keys.D3== e.KeyCode||
                Keys.NumPad3 == e.KeyCode)
            {
                picPriv.Visible = !picPriv.Visible;
            }
            SaveMarkData();
            UpdateMinute(true);
        }
        #endregion

        private void ShowFileMgrForm()
        {
            if (trdFileMgr == null)
            {
                trdFileMgr = new Thread(this.trdShowFileMgrForm);
            }
            if(trdFileMgr.ThreadState == ThreadState.Unstarted)
            {
                trdFileMgr.ApartmentState = ApartmentState.STA;
                trdFileMgr.Start();
            }
            else if (trdFileMgr.ThreadState == ThreadState.Stopped)
            {
                trdFileMgr.Abort();
                trdFileMgr = new Thread(this.trdShowFileMgrForm);
                trdFileMgr.ApartmentState = ApartmentState.STA;
                trdFileMgr.Start();
            }
        }
        private void trdShowFileMgrForm()
        {
            fileParseTool.saveMarkFiles();
            FileMgrForm fmf = new FileMgrForm(cfsettings);
            fmf.ShowDialog();
        }
        private void ShowSettingsForm()
        {
            SettingsForm sf = new SettingsForm();
            sf.initValues(cfsettings);
            if (sf.ShowDialog() == DialogResult.OK)
            {
                ConfigSettings cf = sf.getValues();
                if (cfsettings.iValume != cf.iValume)
                {
                    cfsettings.iValume = cf.iValume;
                    updateVolume();
                }
                if (cfsettings.iPlaySpeed!= cf.iPlaySpeed)
                {
                    cfsettings.iPlaySpeed = cf.iPlaySpeed;
                    UpdateSpeed();
                }
                cfsettings.bAutoPalyNext = cf.bAutoPalyNext;
                if (cfsettings.rootDirArr != cf.rootDirArr)
                {
                    cfsettings.rootDirArr.Clear();
                    cfsettings.rootDirArr.AddRange(cf.rootDirArr);
                    SaveMarkData();
                    fileParseTool.saveMarkFiles();
                    InitFileParseTool();
                }
            }
        }
        private void ShowHelpForm()
        {
            System.Diagnostics.Process.Start("http://www.skewky.com/forum.php?mod=viewthread&tid=2&extra=");
        }
        private void ShowAboutForm()
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

        private void resetTimerInterval()
        {
            double dInv = 1 / cfsettings.getDoubleSpeed();
            timer1.Interval = (int)(dInv * 1000);
        }
        private void threadUpdateAllTimeView()
        {
            //Thread trd = new Thread(this.UpdateAllTimeView);
            //trd.Start();
            UpdateCalender();
        }

        #region updateStatus
        private void updatePlayStatus_Start()
        {
            vlc_player_.Play();
            vlc_player_.SetRate(cfsettings.getDoubleSpeed());
            vlc_player_.SetVolume(cfsettings.iValume);

            double dDuration = vlc_player_.Duration();
            trackBar1.SetRange(0, (int)dDuration);
            trackBar1.Value = 0;
            timer1.Start();
            is_playing_ = true;
            string strNowPlaying = "当前播放："+ fileParseTool.MinutePath(curDt);
            lbNowPlaying.Text = strNowPlaying;
            tssPause.Text = "";
            
            UpdateMarkData();
        }
        private void updatePlayStatus_Stop()
        {
            vlc_player_.Stop();
            trackBar1.Value = trackBar1.Maximum;
            timer1.Stop();
            is_playing_ = false;
            lbNowPlaying.Text = "";
            tssPause.Text = "已停止";
            SaveMarkData();
        }
        private void UpdateMarkData()
        {
            MarkData mk = new MarkData();
            
            if(fileParseTool.GetMarkData(curDt,ref mk))
            {
                tbNote.Text = mk.Description;
                picBin.Visible = mk.ToDelete;
                picLove.Visible = mk.Favourite;
                picPriv.Visible = mk.Private;
                picNote.Visible = mk.Describ;
            }
            else if(!ck_ContinuMark.Checked)
            {
                tbNote.Text = string.Empty;
                picBin.Visible = false;
                picLove.Visible = false;
                picPriv.Visible = false;
                picNote.Visible = false;
            }           
        }
        private void SaveMarkData()
        {
            if (!nowValid())
                return;
            MarkData mk = new MarkData();
            mk.Description = tbNote.Text;
            mk.ToDelete = picBin.Visible;
            mk.Favourite = picLove.Visible;
            mk.Private = picPriv.Visible;
            fileParseTool.SetMarkData(curDt, mk);
        }
        private void UpdateAllTimeView()
        {
            UpdateCalender();
        }
        private void UpdateAllTimeView_Force()
        {
            UpdateCalender(true);
        }
        private void UpdateCalender(bool bForceRefresh = false)
        {
            if (bForceRefresh)
                monthCalendar2.SetSelectionRange(curDt, curDt);
            DateTime curDate = monthCalendar2.SelectionStart;
            monthCalendar2.SetSelectionRange(curDate, curDate);
            if (bForceRefresh ||
                curDate.Year != curDt.Year ||
                curDate.Month != curDt.Month)
            {
                reMarkCalendar(monthCalendar2);
            }
            curDt = curDate;
            updateHourAndMinView(bForceRefresh);

        }
        private void reMarkCalendar(System.Windows.Forms.MonthCalendar mc)
        {
            mc.RemoveAllBoldedDates();

            SelectionRange disRange = mc.GetDisplayRange(false);
            DateTime dt = disRange.Start;
            if (fileParseTool.DayBlod(dt))
                mc.AddBoldedDate(dt);
            while (dt != disRange.End)
            {
                dt = dt.AddDays(1);
                if (fileParseTool.DayBlod(dt))
                    mc.AddBoldedDate(dt);
            }
            mc.UpdateBoldedDates();
        }
        private void UpdateHours(bool bForceUpdate = false)
        {
            int height = pBhour.Height;
            int width = pBhour.Width;
            int drawWidth = width / 24;
            Point drawPt = new Point(0, 0);
            drawPt.X += drawWidth / 2;
            Point drawPt1 = drawPt;
            drawPt1.Y += height;
            Graphics g = pBhour.CreateGraphics();
            for (int i = 0; i < 24; i++)
            {
                DateTime nowdt = new DateTime(curDt.Year, curDt.Month, curDt.Day, i, 0, 0);
                bool bNowBlod = fileParseTool.HourBlod(nowdt);
                System.Drawing.Color cl = bNowBlod ? cfsettings.myColors.clrNormal:cfsettings.myColors.clrBg;
                g.DrawLine(new Pen(cl, drawWidth), drawPt, drawPt1);
                g.DrawString(string.Format("{0}", i), Label.DefaultFont, new SolidBrush(Color.Black), drawPt);
                if (i == curDt.Hour)
                {
                    g.DrawRectangle(new Pen(Color.Black, 1), drawPt.X - drawWidth / 2 + 1, drawPt.Y + 1, drawWidth - 2, height - 2);
                }
                drawPt.X += drawWidth;
                drawPt1.X += drawWidth;
            }
            pBhour.Update();
        }
        private void UpdateMinute(bool bForceUpdate = false)
        {
            int height = pBmin.Height;
            int width = pBmin.Width;
            int drawWidth = width / 60;
            Point drawPt = new Point(0, 0);
            drawPt.X += drawWidth / 2;
            Point drawPt1 = drawPt;
            drawPt1.Y += height;
            Graphics g = pBmin.CreateGraphics();
            for (int i = 0; i < 60; i++)
            {
                DateTime nowdt = new DateTime(curDt.Year, curDt.Month, curDt.Day, curDt.Hour, i, 0);
                //BackGround
                 bool bNowBlod = fileParseTool.MinuteBlod(nowdt);
                System.Drawing.Color clr = bNowBlod?cfsettings.myColors.clrNormal:cfsettings.myColors.clrBg;
                g.DrawLine(new Pen(clr, drawWidth), drawPt, drawPt1); 
                if(bNowBlod)
                    updateMinute_Marks(g, nowdt,drawWidth,drawPt, height);
                if (i == 0 || i == 30 || i == 59)   //Draw key minutes
                {
                    Point tmpDrawPt = drawPt;
                    tmpDrawPt.X -= drawWidth / 2;
                    g.DrawString(string.Format("{0}", i), Label.DefaultFont, new SolidBrush(Color.Black), tmpDrawPt);
                }
                if (i == curDt.Minute)  //DrawCurTime and Rect
                {
                    Point tmpDrawPt = drawPt;
                    tmpDrawPt.X -= drawWidth / 2;
                    g.DrawString(string.Format("{0}", i), Label.DefaultFont, new SolidBrush(Color.Black), tmpDrawPt);

                    g.DrawRectangle(new Pen(Color.Black, 1), drawPt.X - drawWidth / 2 + 1, drawPt.Y + 1, drawWidth - 2, height - 2);
                }
                drawPt.X += drawWidth;
                drawPt1.X += drawWidth;
            }
            pBmin.Update();
            //updatePicBounds();
        }
        private void updateMinute_Marks(Graphics g, DateTime nowdt,int drawWidth,Point drawPt,int height)
        {
            Point drawPt1 = drawPt;
            drawPt1.Y += height;
            int markHeight = height/5;

            MarkData mk = new MarkData();
            System.Drawing.Color clr = cfsettings.myColors.clrNormal;
            fileParseTool.GetMarkData(nowdt, ref mk);


            //Favourite
            drawPt1 = drawPt;
            drawPt1.Y += markHeight;
            clr = mk.Favourite ? cfsettings.myColors.clrFavorite : cfsettings.myColors.clrNormal;
            g.DrawLine(new Pen(clr, drawWidth), drawPt, drawPt1);
            drawPt1.Y += 1;

            //ToDelete
            drawPt = drawPt1;
            drawPt1.Y += markHeight;
            clr = mk.ToDelete ? cfsettings.myColors.clrToDelete : cfsettings.myColors.clrNormal;
            g.DrawLine(new Pen(clr, drawWidth), drawPt, drawPt1);
            drawPt1.Y += 1;

            //Private
            drawPt = drawPt1;
            drawPt1.Y += markHeight;
            clr = mk.Private ? cfsettings.myColors.clrPrivate : cfsettings.myColors.clrNormal;
            g.DrawLine(new Pen(clr, drawWidth), drawPt, drawPt1);
            drawPt1.Y += 1;

            //Description
            drawPt = drawPt1;
            drawPt1.Y += markHeight;
            clr = mk.Describ ? cfsettings.myColors.clrDescrib : cfsettings.myColors.clrNormal;
            g.DrawLine(new Pen(clr, drawWidth), drawPt, drawPt1);
    
        }
        private void updateHourAndMinView(bool bForceRefresh = false)
        {
            // Thread.Sleep(10);
            UpdateHours(bForceRefresh);
            UpdateMinute(bForceRefresh);
        }
        private void updateHourAndMinView_Force()
        {
            updateHourAndMinView(true);
        }
        private void updateVolume(bool bLouder)
        {
            //设置声音
            cfsettings.iValume = vlc_player_.GetVolume();

            if (bLouder)
                cfsettings.iValume += 5;
            else
                cfsettings.iValume -= 5;

            if (cfsettings.iValume < 0)
                cfsettings.iValume = 0;
            updateVolume();
        }
        private void updateVolume()
        {
            vlc_player_.SetVolume(cfsettings.iValume);
            txSound.Text = string.Format("{0}", cfsettings.iValume);
            if (cfsettings.iValume > 100)
                txSound.ForeColor = Color.Red;
            else
                txSound.ForeColor = Color.Black;
        }
        private void UpdateSpeed()
        {
            double dRate = cfsettings.getDoubleSpeed();
            vlc_player_.SetRate(dRate);
            if (cfsettings.iPlaySpeed == 2)
            {
                txSpeed.Visible = false;
                tssPlaySpeed.Text = "";
            }
            else
            {
                txSpeed.Visible = true;
                txSpeed.Text = string.Format("播放速度：{0:N1}x", dRate);
                tssPlaySpeed.Text = string.Format("播放速度：{0:N1}x", dRate);
          
            }
            resetTimerInterval();
        }
        #endregion

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            UpdateCalender();
        }
        private void pBmin_Click(object sender, EventArgs e)
        {

        }

        private void pBhour_Click(object sender, EventArgs e)
        {
        }

        private void pBmin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pBhour_Paint(object sender, PaintEventArgs e)
        {


            /*pBhour.Refresh();*/
        }

        private void pBhour_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int height = pBhour.Height;
            int width = pBhour.Width;
            int drawWidth = width / 24;
            Point clkPt = new Point(e.Location.X, e.Location.Y);
            int clkHour = clkPt.X / drawWidth;
            clkHour = Math.Min(clkHour, 23);

            if (curDt.Hour != clkHour)
            {
                curDt = new DateTime(curDt.Year, curDt.Month, curDt.Day,
                                        clkHour, curDt.Minute, curDt.Second);
                updateHourAndMinView();
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {

        }

        private void pBmin_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int height = pBmin.Height;
            int width = pBmin.Width;
            int drawWidth = width / 60;
            Point clkPt = new Point(e.Location.X, e.Location.Y);
            int clkMinute = clkPt.X / drawWidth;
            clkMinute = Math.Min(clkMinute, 59);
            if (curDt.Minute != clkMinute)
            {
                if (is_playing_)
                    updatePlayStatus_Stop();
                curDt = new DateTime(curDt.Year, curDt.Month, curDt.Day,
                                        curDt.Hour, clkMinute, curDt.Second);
                 UpdateMinute();
                 playCurrentDt();
            }
        }
        private bool playCurrentDt()
        {
            if (fileParseTool.MinuteBlod(curDt))
            {
                PlayRecord(curDt);
                return true;
            }
            return false;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                //Thread.Sleep(1);
                this.updateHourAndMinView_Force();

            }
            this.updateHourAndMinView_Force();

        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            //Thread.Sleep(1000);
            updateHourAndMinView();
        }

        private void pBmin_MouseMove(object sender, MouseEventArgs e)
        {
            int height = pBmin.Height;
            int width = pBmin.Width;
            int drawWidth = width / 60;
            Point clkPt = new Point(e.Location.X, e.Location.Y);
            clkPt.Y += height;
            int clkMinute = clkPt.X / drawWidth;
            clkMinute = Math.Min(clkMinute, 59);
             DateTime dispDt = new DateTime(curDt.Year, curDt.Month, curDt.Day,
                                        curDt.Hour, clkMinute, curDt.Second);
            
            //if (curDt.Minute != clkMinute)
            //{
                string msg = string.Format("{0}/{1:D2}/{2:D2} {3:D2}:{4:D2}",
                                                curDt.Year, curDt.Month, curDt.Day,
                                        curDt.Hour, clkMinute);
                //toolTip1.SetToolTip(this.pBmin, msg);
            //    toolTip1.Show(msg, pBmin, clkPt, 3);
            //}//
            MarkData mk = new MarkData();
            if (fileParseTool.GetMarkData(dispDt, ref mk)&&
                mk.Describ)
            {
                msg = "["+msg + "] " + mk.Description;
                msg = msg.Replace("\n", " ");
                msg = msg.Replace("\r", " ");
                tssNote.Text = msg;            
            }
            else
                tssNote.Text = "";
        }

        private void pBmin_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void ck_ContinuMark_MouseHover(object sender, EventArgs e)
        {

            string msg = string.Format("持续备注\n直到取消勾选\n或碰到下一个有备注的视频");
            Point pt = ck_ContinuMark.Location;
            pt.X -= 220;
            pt.Y += 20;
            toolTip1.Show(msg, ck_ContinuMark, pt, 3000);
        }


        private void ck_ContinuMark_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lbMinute_Click(object sender, EventArgs e)
        {

        }


        #region MenuClickEnv
        private void FileMgr_MenuItem_Click(object sender, EventArgs e)
        {
            ShowFileMgrForm();
        }

        private void About_MenuItem1_Click(object sender, EventArgs e)
        {
            ShowAboutForm();
        }

        private void ReadMe_MenuItem_Click(object sender, EventArgs e)
        {
            ShowHelpForm();

        }

        private void Settings_MenuItem_Click(object sender, EventArgs e)
        {
            ShowSettingsForm();
        }
        #endregion

        #region PicButtoms
        private void picPrivGray_MouseClick(object sender, MouseEventArgs e)
        {
            if (!nowValid())
                return;
            picPriv.Visible = true;
            SaveMarkData();
            UpdateMinute(true);
        }

        private void picBinGray_MouseClick(object sender, MouseEventArgs e)
        {
            if (!nowValid())
                return;
            picBin.Visible = true;
            SaveMarkData();
            UpdateMinute(true);
            
        }

        private void picLoveGray_MouseClick(object sender, MouseEventArgs e)
        {
            if (!nowValid())
                return;
            picLove.Visible = true;
            SaveMarkData();
            UpdateMinute(true);
           
        }

        private void picLove_MouseClick(object sender, MouseEventArgs e)
        {
            if (!nowValid())
                return;
            picLove.Visible = false;
            SaveMarkData();
            UpdateMinute(true);
        }

        private void picBin_MouseClick(object sender, MouseEventArgs e)
        {
            if (!nowValid())
                return;
            picBin.Visible = false;
            SaveMarkData();
            UpdateMinute(true);
        }

        private void picPriv_MouseClick(object sender, MouseEventArgs e)
        {
            if (!nowValid())
                return;
            picPriv.Visible = false;
            SaveMarkData();
            UpdateMinute(true);
        }

        private void picNote_MouseClick(object sender, MouseEventArgs e)
        {
                      
        }

        private void picNoteGray_Click(object sender, EventArgs e)
        {
            
        }

        private void picMarks_Paint(object sender, PaintEventArgs e)
        {
            //updatePicBounds();
        }
       private void updatePicBounds()
        {
            if (picLove.Visible)
            {
                Graphics g = picLove.CreateGraphics();
                g.DrawRectangle(new Pen(cfsettings.myColors.clrFavorite, 4), 0, 0, picLove.Width - 1, picLove.Height - 1);
                picLove.Update();
            }
            if (picBin.Visible)
            {
                Graphics g = picBin.CreateGraphics();
                g.DrawRectangle(new Pen(cfsettings.myColors.clrToDelete, 4), 0, 0, picBin.Width - 1, picBin.Height - 1);
                picBin.Update();
            }
            if (picPriv.Visible)
            {
                Graphics g = picPriv.CreateGraphics();
                g.DrawRectangle(new Pen(cfsettings.myColors.clrPrivate, 4), 0, 0, picPriv.Width - 1, picPriv.Height - 1);
                picPriv.Update();
            }
            if (picNote.Visible)
            {
                Graphics g = picNote.CreateGraphics();
                g.DrawRectangle(new Pen(cfsettings.myColors.clrDescrib, 4), 0, 0, picNote.Width - 1, picNote.Height - 1);
                picNote.Update();
            }
        }

 
  
        #endregion


        private void lbNowPlaying_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string path = fileParseTool.MinutePath(curDt);
            if (Directory.Exists(Path.GetDirectoryName(path)))
                System.Diagnostics.Process.Start("explorer.exe", Path.GetDirectoryName(path));
        }

        private bool nowValid()
        {
            if(fileParseTool.MinuteBlod(curDt))
                return true;
            return false;
        }

        private void tbNote_TextChanged(object sender, EventArgs e)
        {
            if (!nowValid())
                return;
            picNote.Visible = !string.IsNullOrEmpty(tbNote.Text);
            SaveMarkData();
            UpdateMinute(true);
        
        }

        private void pBmin_MouseLeave(object sender, EventArgs e)
        {
            tssNote.Text = "";
        }

   

     }
}
