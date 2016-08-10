﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Com.Skewky.Cam
{
    public partial class Form1 : Form
    {
        private VlcPlayer vlc_player_;
        private bool is_playing_;
        private bool is_fullScreen_;
        private int vlc_Speed;
        private int vlc_Valume;
        private FileParseBase fileParseTool;
        private int recType;
        private string rootDir;
        private DateTime curDt;
        public Form1()
        {
             string pluginPath = System.Environment.CurrentDirectory + "\\vlc\\plugins\\";
            vlc_player_ = new VlcPlayer(pluginPath);
            vlc_Speed = 10;
            vlc_Valume = 50;

            
            is_playing_ = false;
            is_fullScreen_ = false;
            recType = 0;
            rootDir = @"E:\Meida\XM";

            InitFileParseTool();    
            
            InitializeComponent();

            this.KeyPreview = true;
            IntPtr render_wnd = this.panel1.Handle;
            vlc_player_.SetRenderWindow((int)render_wnd);
            txSound.Text = string.Format("{0}", vlc_Valume);
            tbVideoTime.Text = "00:00:00/00:00:00";
           

        }
        private void InitFileParseTool()
        {
            if (recType == 0)
                fileParseTool = new FileParseXiaoMi();
            fileParseTool.setRootDir(rootDir);
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                PlayRecord(ofd.FileName);
            }
        }
        private void PlayRecord(string path)
        {
            if (System.IO.File.Exists(path))
            {
                vlc_player_.PlayFile(path);
                vlc_player_.SetRate(vlc_Speed / 10);
                vlc_player_.SetVolume(vlc_Valume);

                double dDuration = vlc_player_.Duration()*1000;
                trackBar1.SetRange(0, (int)dDuration);
                trackBar1.Value = 0;
                timer1.Start();
                is_playing_ = true;
                UpdateHours();
                UpdateMinute();
            }
        }
        private void PlayRecord(DateTime dt)
        {
            string path = fileParseTool.MinutePath(dt);
            PlayRecord(path);
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = rootDir;
            folderBrowserDialog.ShowNewFolderButton = false;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (rootDir!= folderBrowserDialog.SelectedPath)
                {
                    rootDir = folderBrowserDialog.SelectedPath;
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
                    vlc_player_.Stop();
                    timer1.Stop();
                    DateTime nextDt = curDt;
                    if(fileParseTool.findNextDt(curDt,ref nextDt))
                    {
                        string nextfilePath = fileParseTool.MinutePath(nextDt);
                        curDt = nextDt;
                        PlayRecord(curDt);
                    }
                    else
                    {
                        string msg = string.Format("没有找到下一个要播放文件");
                        toolTip1.Show(msg,pBmin, 15,15, 3);
                    }
                }
                else
                {
                    int curVal = trackBar1.Value + 1000 * vlc_Speed/10;;
                    curVal = Math.Max(trackBar1.Minimum, curVal);
                    curVal = Math.Min(trackBar1.Maximum, curVal);
                    double curPlayTime = vlc_player_.GetPlayTime()*1000;
                    trackBar1.Value = (int)curPlayTime;
                    tbVideoTime.Text = string.Format("{0}/{1}", 
                        GetTimeString(trackBar1.Value), 
                        GetTimeString(trackBar1.Maximum));
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
        }
        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            //设置声音
            vlc_Valume = vlc_player_.GetVolume();
           
            if (e.Delta == 120)
                vlc_Valume += 5;
            else if (e.Delta == -120)
                vlc_Valume -=5;
            
            if (vlc_Valume < 0)
                vlc_Valume = 0;
            vlc_player_.SetVolume(vlc_Valume);
            txSound.Text = string.Format("{0}", vlc_Valume);
            if (vlc_Valume > 100)
                txSound.ForeColor = Color.Red;
            else
                txSound.ForeColor = Color.Black;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.pBplayEnv.Focus();
      
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            this.pBplayEnv.Focus();
      
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            vlc_player_.Stop();
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                togglePlay();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
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
                    int newPlayTime = trackBar1.Value - 5 * vlc_Speed / 10;
                    newPlayTime = newPlayTime < 0 ? 0 : newPlayTime;
                    vlc_player_.SetPlayTime(newPlayTime);
                    trackBar1.Value = (int)vlc_player_.GetPlayTime();
                }
                //后退
                if (Keys.Right == e.KeyCode)
                {
                    int newPlayTime = trackBar1.Value + 5 * vlc_Speed / 10;
                    newPlayTime = newPlayTime < 0 ? 0 : newPlayTime;
                    vlc_player_.SetPlayTime(newPlayTime);
                    trackBar1.Value = (int)vlc_player_.GetPlayTime();
                }
            }
            if(Keys.Up == e.KeyCode||
                Keys.Down == e.KeyCode)
            {
                double dRate = (double)(vlc_Speed / 10);
                //加速
                if (Keys.Up == e.KeyCode)
                {
                    if (vlc_Speed < 10)
                        vlc_Speed += 1;
                    else
                        vlc_Speed += 5;
                    if (vlc_Speed > 160)
                        vlc_Speed = 160;
                    dRate = (double)vlc_Speed / 10.0;
                    vlc_player_.SetRate(dRate);
                }
                //减速
                if (Keys.Down == e.KeyCode)
                {
                    if (vlc_Speed <= 10)
                        vlc_Speed -= 1;
                    else
                        vlc_Speed -= 5;
                    if (vlc_Speed < 1)
                        vlc_Speed = 1;
                    dRate = (double)vlc_Speed / 10.0;
                    vlc_player_.SetRate(dRate);
                }
                if(vlc_Speed==10)
                {
                    txSpeed.Visible = false;
                }
                else
                {
                    txSpeed.Visible = true;
                    txSpeed.Text = string.Format("播放速度：{0:N1}x", dRate);
                }
            }

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            UpdateCalender();
        }
        private void UpdateCalender(bool bForceRefresh = false)
        {

            DateTime curDate = monthCalendar2.SelectionStart;
            monthCalendar2.SetSelectionRange(curDate, curDate);
            DateTime prvDate = curDate.AddMonths(-1);
            monthCalendar1.SetSelectionRange(prvDate, prvDate);
            DateTime postDate = curDate.AddMonths(1);
            monthCalendar3.SetSelectionRange(postDate, postDate);
            if (bForceRefresh||
                curDate.Year != curDt.Year ||
                curDate.Month != curDt.Month)
             {
                reMarkCalendar(monthCalendar1);
                reMarkCalendar(monthCalendar2);
                reMarkCalendar(monthCalendar3);
         
             }
            curDt = curDate;
            UpdateHours();
            UpdateMinute();
        }
        private void reMarkCalendar(System.Windows.Forms.MonthCalendar mc)
        {
            mc.RemoveAllBoldedDates();

            SelectionRange disRange = mc.GetDisplayRange(true);
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
        private void UpdateHours()
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
                System.Drawing.Color cl = bNowBlod ? System.Drawing.Color.Red : System.Drawing.Color.Yellow;
                g.DrawLine(new Pen(cl, drawWidth), drawPt, drawPt1);
                g.DrawString(string.Format("{0}", i), Label.DefaultFont, new SolidBrush(Color.Black), drawPt);
                if(i==curDt.Hour)
                {
                    g.DrawRectangle(new Pen(Color.Black, 2), drawPt.X-drawWidth/2,drawPt.Y,drawWidth,height);
                }
                drawPt.X += drawWidth;
                drawPt1.X += drawWidth;
            }

        }
        private void UpdateMinute()
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
                System.Drawing.Color cl = bNowBlod ? System.Drawing.Color.Red : System.Drawing.Color.Yellow;
                g.DrawLine(new Pen(cl, drawWidth), drawPt, drawPt1);
                if (i==0||i==30||i==59)
                {
                    g.DrawString(string.Format("{0}", i), Label.DefaultFont, new SolidBrush(Color.Black), drawPt);
                }
                if (i == curDt.Minute)
                {
                    g.DrawRectangle(new Pen(Color.Black, 2), drawPt.X - drawWidth / 2, drawPt.Y, drawWidth, height);
                }
                drawPt.X += drawWidth;
                drawPt1.X += drawWidth;
            }

        }
        private void label0_Click(object sender, EventArgs e)
        {
            label1.BackColor = System.Drawing.Color.Red;
            label10.BackColor = System.Drawing.Color.Gray;
            label13.BackColor = System.Drawing.Color.Green;
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
                UpdateHours();
                UpdateMinute();
    
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
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
                Autoplay();
            }
        }
        private bool Autoplay()
        {
            if(fileParseTool.MinuteBlod(curDt))
            {
                PlayRecord(curDt);
                return true;
            }
            return false;
         }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                UpdateHours();
                UpdateMinute();
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            UpdateHours();
            UpdateMinute();
        
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


    }
}
