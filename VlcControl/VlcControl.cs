using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Com.Skewky.Vlc
{
    public partial class VlcControl: UserControl
    {
        private VlcPlayer vlc_player_ = null;
        private VlcPlayer vlc_player_Next = null;
        private bool bFindNext = false;
        private bool bAutoPlayNext = true;
        
        private bool is_playing_;
        public bool bFullScreen = false;

        public int iPlaySpeed = 2;
        public int iValume = 80;

        private int iCurWidth;
        private int iCurHeight;
        private Point panelBasePt;
             
        public VlcControl()
        {
            InitializeComponent();
        }
        public void release()
        {
            if (vlc_player_!=null)
            {
                vlc_player_.Stop();
            }
            if (vlc_player_Next != null)
            {
                vlc_player_Next.Stop();
            }
        }
        public bool initVlcPlayer()
        {
            vlc_player_ = newVlcPlayer();
            return true;
        }
        public bool setVlcPlayer(VlcPlayer vlc)
        {
            vlc_player_.Copy(vlc);
            return true;
        }
        public bool getVlcPlayer(ref VlcPlayer vlc)
        {
            vlc.Copy(vlc_player_);
            return true;
        }
        private VlcPlayer newVlcPlayer()
        {
            string pluginPath = System.Environment.CurrentDirectory + "\\vlc\\plugins\\";
            VlcPlayer vlcPlayer = new VlcPlayer(pluginPath);
            IntPtr render_wnd = this.panelPlay.Handle;
            vlcPlayer.SetRenderWindow((int)render_wnd);
            return vlcPlayer;
        }
        public void PlayFile(string path)
        {
            vlc_player_.PlayFile(path);
            updatePlayStatus_Start();
        }

        private void InitNextFile(string path)
        {
            if (!System.IO.File.Exists(path))
                return;
            if (!bAutoPlayNext)
                return;
            bFindNext = true;
            vlc_player_.PlayFile(path);
        }
        private void PlayNext()
        {
            if (!bAutoPlayNext||!bFindNext)
                return;
            vlc_player_.Copy(vlc_player_Next);
            vlc_player_.Pause();
            bFindNext = false;
            updatePlayStatus_Start();
        }
        #region updateStatus
        private void updatePlayStatus_Start()
        {
            vlc_player_.Play();
            vlc_player_.SetRate(ConstVars.getDoubleSpeed(iPlaySpeed));
            vlc_player_.SetVolume(iValume);

            double dDuration = vlc_player_.Duration();
            tbProcess.SetRange(0, (int)dDuration);
            tbProcess.Value = 0;
            timer1.Start();
            is_playing_ = true;
           // string strNowPlaying = "当前播放：" + fileParseTool.MinutePath(curDt);
           // lbNowPlaying.Text = strNowPlaying;
           // tssPause.Text = "";

           // UpdateMarkData();
        }
        private void updatePlayStatus_Stop()
        {
            vlc_player_.Stop();
            tbProcess.Value = tbProcess.Maximum;
            timer1.Stop();
            is_playing_ = false;
           // lbNowPlaying.Text = "";
          //  tssPause.Text = "已停止";
          //  SaveMarkData();
        }
        private void resetTimerInterval()
        {
            double dInv = 1 / ConstVars.getDoubleSpeed(iPlaySpeed);
            timer1.Interval = (int)(dInv * 1000);
        }
        public void Play()
        {
            updatePlayStatus_Start();
        }
        public void updateTexts()
        {
            updateVolume();
            UpdateSpeed();
        }
          private void updateVolume(bool bLouder)
        {
            //设置声音
            iValume = vlc_player_.GetVolume();

            if (bLouder)
                iValume += 5;
            else
                iValume -= 5;

            if (iValume < 0)
                iValume = 0;
            updateVolume();
        }
        private void updateVolume()
        {
            vlc_player_.SetVolume(iValume);
            lbSound.Text = string.Format("{0}", iValume);
            if (iValume > 100)
                lbSound.ForeColor = Color.Red;
            else
                lbSound.ForeColor = Color.Black;
        }
        private void UpdateSpeed()
        {
            double dRate = ConstVars.getDoubleSpeed(iPlaySpeed);
            vlc_player_.SetRate(dRate);
            if (iPlaySpeed == 2)
            {
                lbSpeed.Visible = false;
                lbSpeed.Text = "";
            }
            else
            {
                lbSpeed.Visible = true;
                lbSpeed.Text = string.Format("播放速度：{0:N1}x", dRate);
          
            }
            resetTimerInterval();
        }
        #endregion

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
                    PlayNext();
                }
                else
                {
                    int curVal = tbProcess.Value + (int)(1000 * ConstVars.getDoubleSpeed(iPlaySpeed));
                    curVal = Math.Max(tbProcess.Minimum, curVal);
                    curVal = Math.Min(tbProcess.Maximum, curVal);
                    double curPlayTime = vlc_player_.GetPlayTime() * 1000;
                    curPlayTime = Math.Max(tbProcess.Minimum, curPlayTime);
                    curPlayTime = Math.Min(tbProcess.Maximum, curPlayTime);
                    tbProcess.Value = (int)curPlayTime;
                    lbVideoTime.Text = string.Format("{0}/{1}",
                        GetTimeString(tbProcess.Value / 1000),
                        GetTimeString(tbProcess.Maximum / 1000));
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
        private void tbProcess_Scroll(object sender, EventArgs e)
        {
            if (is_playing_)
            {
                vlc_player_.SetPlayTime(tbProcess.Value / 1000.0);
                tbProcess.Value = (int)vlc_player_.GetPlayTime();
            }
        }
        private void lbSpeed_Click(object sender, EventArgs e)
        {

        }

        private void panelPlay_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
         
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
         
        /*if(bFullScreen)
        {
            panelPlay.SetBounds(panelBasePt.X, panelBasePt.Y, panelBasePt.X + iCurWidth, panelBasePt.Y+iCurHeight);
            bFullScreen = false;
            vlc_player_.SetRenderWindow((int)this.panelPlay.Handle);
          
        }
        else
        {
            System.Drawing.Rectangle rect = panelPlay.Bounds;
            iCurHeight = rect.Height;
            iCurWidth = rect.Width;
            panelBasePt = rect.Location;


           
            int iActulaWidth = Screen.PrimaryScreen.Bounds.Width;
            int iActulaHeight = Screen.PrimaryScreen.Bounds.Height;
            panelPlay.SetBounds(0,0,iActulaWidth,iActulaHeight);
            var parentControl = panelPlay.Parent;
            vlc_player_.SetRenderWindow((int)0);
            panelPlay.Parent.SetBounds(0, 0, iActulaWidth+20, iActulaHeight+20);
            bFullScreen = true;
        }
            
               vlc_player_.SetFullScreen(!bFullScreen);
               bFullScreen = !bFullScreen;
         */
             FullScreenPlayer fsp = null;
            
                if (fsp == null)
                    fsp = new FullScreenPlayer();
                if (bFullScreen)
                {
                    fsp.Close();
                    fsp.Visible = false;
                    bFullScreen = false;
                    fsp.getVlc(ref vlc_player_);
                    vlc_player_.Play();
                }
                else 
                {
                    bFullScreen = true;
                    fsp.setVlc(vlc_player_);
                    vlc_player_.Pause();
                    fsp.UpdateVlcStatusStart();
                    int iActulaWidth = Screen.PrimaryScreen.Bounds.Width;
                    int iActulaHeight = Screen.PrimaryScreen.Bounds.Height;
                    fsp.SetBounds(0, 0, iActulaWidth, iActulaHeight);
                   // fsp.Visible = true;
                    if (fsp.ShowDialog() == DialogResult.OK)
                    {
                        vlc_player_.setPlayInfo(fsp.fullPlayInfo);
                        bFullScreen = false;
                    }
                       
                }
                
        }

    }
}
