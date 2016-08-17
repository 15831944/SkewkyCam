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
        public MainForm()
        {
             
            
            is_playing_ = false;
            is_fullScreen_ = false;
            bFindNext = false;
            
            loadConfig();

            InitFileParseTool();    
            
            InitializeComponent();

            this.KeyPreview = true;
            
            vlc_player_ = newVlcPlayer();
            vlc_player_Next =newVlcPlayer();
            txSound.Text = string.Format("{0}", cfsettings.iValume);
            tbVideoTime.Text = "00:00:00/00:00:00";
            resetTimerInterval();

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
            string filePath = configFile();
            try
            {
                cfsettings.iValume = 50;
                cfsettings.iRecType = 15;
                Stream s = File.Open(filePath, FileMode.Create, FileAccess.ReadWrite);
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(s, cfsettings);
                s.Close();
            }
            catch(Exception e)
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
                    s.Close();
                }      
            }
            catch (Exception e)
            {
                File.Delete(filePath);
            }
            if (cfsettings.rootDirArr == null)
                cfsettings.rootDirArr = new List<string>();
            if(cfsettings.rootDirArr.Count==0)
                cfsettings.rootDirArr.Add(@"E:\Meida\XM");
           
        }
        private void InitFileParseTool()
        {
            switch(cfsettings.iRecType)
            {
                case 0: //XiaoMi
                    fileParseTool = new FileParseXiaoMi();
                    break;
                default:
                    fileParseTool = new FileParseXiaoMi();
                    break;        
            }
            fileParseTool.setRootDir(cfsettings.rootDirArr[0]);
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
        private void updatePlayStatus_Start()
        {
            vlc_player_.Play();
            vlc_player_.SetRate(cfsettings.iPlaySpeed / 10);
            vlc_player_.SetVolume(cfsettings.iValume);

            double dDuration = vlc_player_.Duration();
            trackBar1.SetRange(0, (int)dDuration);
            trackBar1.Value = 0;
            timer1.Start();
            is_playing_ = true;
        }
        private void updatePlayStatus_Stop()
        {
            vlc_player_.Stop();
            trackBar1.Value = trackBar1.Maximum;
            timer1.Stop();
            is_playing_ = false;
        }
        private void threadFindNextFile()
        {
            vlc_player_Next = newVlcPlayer();
            Thread trd = new Thread(this.PrepearNextFile);
            trd.Start();
        }
        private void PlayRecord(DateTime dt, bool AutoPlayNext = false)
        {
            string path = fileParseTool.MinutePath(dt);
            PlayRecord(path,AutoPlayNext);
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
                    if(fileParseTool.findNextDt(curDt,ref nextDt))
                    {
                        PlayRecord(nextDt, true);
                    }
                    else
                    {
                        string msg = string.Format("没有找到下一个要播放文件");
                        toolTip1.Show(msg,pBmin, 15,15, 3);
                    }
                }
                else
                {
                    int curVal = trackBar1.Value + 1000 * cfsettings.iPlaySpeed/10;;
                    curVal = Math.Max(trackBar1.Minimum, curVal);
                    curVal = Math.Min(trackBar1.Maximum, curVal);
                    double curPlayTime = vlc_player_.GetPlayTime()*1000;
                    curPlayTime = Math.Max(trackBar1.Minimum, curPlayTime);
                    curPlayTime = Math.Min(trackBar1.Maximum, curPlayTime);
                    trackBar1.Value = (int)curPlayTime;
                    tbVideoTime.Text = string.Format("{0}/{1}", 
                        GetTimeString(trackBar1.Value/1000), 
                        GetTimeString(trackBar1.Maximum/1000));
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
                vlc_player_.SetPlayTime(trackBar1.Value);
                trackBar1.Value = (int)vlc_player_.GetPlayTime();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            updateHourAndMinView_Force();
        }
        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            //设置声音
            cfsettings.iValume = vlc_player_.GetVolume();
           
            if (e.Delta == 120)
                cfsettings.iValume += 5;
            else if (e.Delta == -120)
                cfsettings.iValume -=5;
            
            if (cfsettings.iValume < 0)
                cfsettings.iValume = 0;
            vlc_player_.SetVolume(cfsettings.iValume);
            txSound.Text = string.Format("{0}", cfsettings.iValume);
            if (cfsettings.iValume > 100)
                txSound.ForeColor = Color.Red;
            else
                txSound.ForeColor = Color.Black;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

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
            if(clk == MouseButtons.Middle)
            {
                toggleFullScreen();
            }

        }

        private void pBplayEnv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                togglePlay();
        }
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
                is_playing_ = false;
            }
            else
            {
                vlc_player_.Play();
                timer1.Start();
                is_playing_ = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            vlc_player_.Stop();
            saveConfig();
        }


        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (Keys.Space == e.KeyCode)
            {
                togglePlay();
            }
            if (Keys.Left == e.KeyCode ||
                Keys.Right == e.KeyCode)
            {
                //前进
                if (Keys.Left == e.KeyCode)
                {
                    int newPlayTime = trackBar1.Value - 5 * cfsettings.iPlaySpeed / 10;
                    newPlayTime = newPlayTime < 0 ? 0 : newPlayTime;
                    vlc_player_.SetPlayTime(newPlayTime);
                    trackBar1.Value = (int)vlc_player_.GetPlayTime();
                }
                //后退
                if (Keys.Right == e.KeyCode)
                {
                    int newPlayTime = trackBar1.Value + 5 * cfsettings.iPlaySpeed / 10;
                    newPlayTime = newPlayTime < 0 ? 0 : newPlayTime;
                    vlc_player_.SetPlayTime(newPlayTime);
                    trackBar1.Value = (int)vlc_player_.GetPlayTime();
                }
            }
            if (Keys.Up == e.KeyCode ||
                Keys.Down == e.KeyCode)
            {
                //加速
                if (Keys.Up == e.KeyCode)
                {
                    if (cfsettings.iPlaySpeed < 10)
                        cfsettings.iPlaySpeed += 1;
                    else
                        cfsettings.iPlaySpeed += 5;
                    if (cfsettings.iPlaySpeed > 160)
                        cfsettings.iPlaySpeed = 160;
                }
                //减速
                if (Keys.Down == e.KeyCode)
                {
                    if (cfsettings.iPlaySpeed <= 10)
                        cfsettings.iPlaySpeed -= 1;
                    else
                        cfsettings.iPlaySpeed -= 5;
                    if (cfsettings.iPlaySpeed < 1)
                        cfsettings.iPlaySpeed = 1;
                }
                UpdateSpeed();
            }
        }
        private void UpdateSpeed()
        {
            double dRate = (double)cfsettings.iPlaySpeed / 10.0;
            vlc_player_.SetRate(dRate);
            if (cfsettings.iPlaySpeed == 10)
            {
                txSpeed.Visible = false;
            }
            else
            {
                txSpeed.Visible = true;
                txSpeed.Text = string.Format("播放速度：{0:N1}x", dRate);
            }
            resetTimerInterval();
        }
        

        private void resetTimerInterval()
        {
            double dInv = 10.0 / (double)cfsettings.iPlaySpeed;
            timer1.Interval = (int)(dInv * 1000);
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            UpdateCalender();
        }
        private void threadUpdateAllTimeView()
        {
            //Thread trd = new Thread(this.UpdateAllTimeView);
            //trd.Start();
            UpdateCalender();
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
            if (bForceRefresh||
                curDate.Year != curDt.Year ||
                curDate.Month != curDt.Month)
            {
                reMarkCalendar(monthCalendar2);
            }
            curDt = curDate;
            UpdateHours(bForceRefresh);
            UpdateMinute(bForceRefresh);
        }
        private void reMarkCalendar(System.Windows.Forms.MonthCalendar mc)
        {
            mc.RemoveAllBoldedDates();

            SelectionRange disRange = mc.GetDisplayRange(false);
            DateTime dt = disRange.Start;
            if (fileParseTool.DayBlod(dt))
                mc.AddBoldedDate(dt);
            while(dt != disRange.End)
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
                System.Drawing.Color cl = bNowBlod ? System.Drawing.Color.Red : System.Drawing.SystemColors.ActiveBorder;
                g.DrawLine(new Pen(cl, drawWidth), drawPt, drawPt1);
                g.DrawString(string.Format("{0}", i), Label.DefaultFont, new SolidBrush(Color.Black), drawPt);
                if(i==curDt.Hour)
                {
                    g.DrawRectangle(new Pen(Color.Black, 2), drawPt.X-drawWidth/2+1,drawPt.Y+1,drawWidth-2,height-2);
                }
                drawPt.X += drawWidth;
                drawPt1.X += drawWidth;
            }

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
                bool bNowBlod = fileParseTool.MinuteBlod(nowdt);
                System.Drawing.Color cl = bNowBlod ? System.Drawing.Color.Red : System.Drawing.SystemColors.ActiveBorder;
                g.DrawLine(new Pen(cl, drawWidth), drawPt, drawPt1);
                if (i==0||i==30||i==59)
                {
                    Point tmpDrawPt = drawPt;
                    tmpDrawPt.X -= drawWidth / 2;
                    g.DrawString(string.Format("{0}", i), Label.DefaultFont, new SolidBrush(Color.Black), tmpDrawPt);
                }
                if (i == curDt.Minute)
                {
                    Point tmpDrawPt = drawPt;
                    tmpDrawPt.X -= drawWidth / 2;
                    g.DrawString(string.Format("{0}", i), Label.DefaultFont, new SolidBrush(Color.Black), tmpDrawPt);
                
                    g.DrawRectangle(new Pen(Color.Black, 2), drawPt.X - drawWidth / 2+1, drawPt.Y+1, drawWidth-2, height-2);
                }
                drawPt.X += drawWidth;
                drawPt1.X += drawWidth;
            }

        }
        private void updateHourAndMinView(bool bForceRefresh = false)
        {
            UpdateHours(bForceRefresh);
            UpdateMinute(bForceRefresh);
        }
        private void updateHourAndMinView_Force()
        {
            updateHourAndMinView(true);
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
                curDt = new DateTime(curDt.Year,curDt.Month, curDt.Day,
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
            int clkMinute= clkPt.X / drawWidth;
            clkMinute = Math.Min(clkMinute, 59);
            if(curDt.Minute != clkMinute)
            {
                curDt = new DateTime(curDt.Year, curDt.Month, curDt.Day,
                                        curDt.Hour, clkMinute, curDt.Second);
                UpdateMinute();
                playCurrentDt();
            }
        }
        private bool playCurrentDt()
        {
            if(fileParseTool.MinuteBlod(curDt))
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
                this.updateHourAndMinView_Force();
                
            }
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
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
            if (curDt.Minute != clkMinute)
            {
                DateTime dispDt = new DateTime(curDt.Year, curDt.Month, curDt.Day,
                                        curDt.Hour, clkMinute, curDt.Second);
                string msg = string.Format("{0}/{1:D2}/{2:D2} {3:D2}:{4:D2}",
                                                curDt.Year, curDt.Month, curDt.Day,
                                        curDt.Hour, clkMinute);
                toolTip1.Show(msg, pBmin, clkPt,3);
            }
        }

        private void pBmin_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void ck_ContinuMark_MouseHover(object sender, EventArgs e)
        {
            
            string msg = string.Format("持续标注\n直到取消勾选\n或碰到下一个有标注的视频");
            Point pt = ck_ContinuMark.Location;
            pt.X -= 220;
            pt.Y += 20;
            toolTip1.Show(msg, ck_ContinuMark, pt, 3000);
        }

        private void pBplayEnv_Click(object sender, EventArgs e)
        {

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

       
    }
}
