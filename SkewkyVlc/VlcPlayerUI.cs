using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Com.Skewky.Vlc
{
    class VlcPlayerUI
    {
        private VlcPlayer m_vlc = null;
        private VlcPlayer m_vlcNext = null;
        private bool bFindNext = false;
        private bool bAutoPlayNext = true;

        private bool is_playing_;
    
        public int iPlaySpeed = 2;
        public int iValume = 80;

        private Panel panelPlay = null;
        private Timer playTimer = null;
        private TrackBar tbProcess = null;
        private Label lbVideoTime = null;
        private Label lbSound = null;
        private Label lbSpeed = null;
        public void setComponents(Panel panel, Timer timer, TrackBar tbBar, Label lbVdTime, Label lbSd, Label lbSp)
        {
            panelPlay = panel;
            playTimer = timer;
            tbProcess = tbBar;
            lbVideoTime = lbVdTime;
            lbSound = lbSd;
            lbSpeed = lbSp;

            if (playTimer != null)
            {
                playTimer.Tick += new System.EventHandler(playTimer_Tick);
            }
            if (tbProcess != null)
            {
                tbProcess.Scroll += new System.EventHandler(tbProcess_Scroll);
            }
            if (lbSpeed != null)
            {
                lbSpeed.Click += new System.EventHandler(lbSpeed_Click);
            }
        }
        public void release()
        {
            if (m_vlc != null)
                m_vlc.Stop();
            if (m_vlcNext != null)
                m_vlcNext.Stop();
        }
        private bool initVlcPlayer()
        {
            if (null == m_vlc)
            {
                m_vlc = newVlcPlayer();
                m_vlcNext = newVlcPlayer();
            }
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
            initVlcPlayer();
            m_vlc.PlayFile(path);
            updatePlayStatus_Start();
        }
        public void setPlayInfo(PlayInfo pInfo)
        {
            initVlcPlayer();
            m_vlc.setPlayInfo(pInfo);
        }
        public PlayInfo getPlayInfo()
        {
            initVlcPlayer();
            return m_vlc.getPlayInfo();
        }
        private void InitNextFile(string path)
        {

            initVlcPlayer();
            if (!System.IO.File.Exists(path))
                return;
            if (!bAutoPlayNext)
                return;
            bFindNext = true;
            m_vlc.PlayFile(path);
        }
        private void PlayNext()
        {

            initVlcPlayer();
            if (!bAutoPlayNext || !bFindNext)
                return;
            m_vlc.Copy(m_vlcNext);
            m_vlc.Pause();
            bFindNext = false;
            updatePlayStatus_Start();
        }
        #region updateStatus
        private void updatePlayStatus_Start()
        {

            initVlcPlayer();
            m_vlc.Play();
            m_vlc.SetRate(ConstVars.getDoubleSpeed(iPlaySpeed));
            m_vlc.SetVolume(iValume);

            double dDuration = m_vlc.Duration();
            if (tbProcess != null)
            {
                tbProcess.SetRange(0, (int)dDuration);
                tbProcess.Value = 0;
            }
            if (playTimer !=null)
            {
                playTimer.Start();
            }
            is_playing_ = true;
        }
        private void updatePlayStatus_Stop()
        {
            initVlcPlayer();
            m_vlc.Stop();
            if (tbProcess != null)
            {
                tbProcess.Value = tbProcess.Maximum;
            }
            if (playTimer != null)
            {
                playTimer.Stop();
            } 
            is_playing_ = false;
        }
        private void resetTimerInterval()
        {
            if(playTimer ==null)
                return;
            double dInv = 1 / ConstVars.getDoubleSpeed(iPlaySpeed);
            playTimer.Interval = (int)(dInv * 1000);
        }
        public void Play()
        {
            m_vlc.Play();
        }
        public void Pause()
        {
            m_vlc.Pause();
        }
        public void Stop()
        {
            m_vlc.Stop();
        }
        public void updateTexts()
        {

            initVlcPlayer();
            updateVolume();
            UpdateSpeed();
        }
        private void updateVolume(bool bLouder)
        {
            //设置声音
            iValume = m_vlc.GetVolume();

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

            initVlcPlayer();
            m_vlc.SetVolume(iValume);
            if (null == lbSound)
                return;
            lbSound.Text = string.Format("{0}", iValume);
            if (iValume > 100)
                lbSound.ForeColor = Color.Red;
            else
                lbSound.ForeColor = Color.Black;
        }
        private void UpdateSpeed()
        {

            initVlcPlayer();
            double dRate = ConstVars.getDoubleSpeed(iPlaySpeed);
            m_vlc.SetRate(dRate);
            resetTimerInterval();
            if (lbSpeed == null)
                return;

            lbSpeed.Visible = true;
            lbSpeed.Text = string.Format("{0:N1}x", dRate);
        }
        private void UpdateVedioTime()
        {
            if (lbVideoTime == null)
            {
                return;
            }
            int curVal = tbProcess.Value + (int)(1000 * ConstVars.getDoubleSpeed(iPlaySpeed));
            curVal = Math.Max(tbProcess.Minimum, curVal);
            curVal = Math.Min(tbProcess.Maximum, curVal);
            double curPlayTime = m_vlc.GetPlayTime() * 1000;
            curPlayTime = Math.Max(tbProcess.Minimum, curPlayTime);
            curPlayTime = Math.Min(tbProcess.Maximum, curPlayTime);
            lbVideoTime.Text = string.Format("{0}/{1}",
                GetTimeString(tbProcess.Value / 1000),
                GetTimeString(tbProcess.Maximum / 1000));
            tbProcess.Value = (int)curPlayTime;
        }
        #endregion

        private void playTimer_Tick(object sender, EventArgs e)
        {

            initVlcPlayer();
            if (is_playing_)
            {
                double playTime = m_vlc.GetPlayTime();
                double duraTime = m_vlc.Duration();
                bool bIsPlayEnded = m_vlc.isPlayEnded();
                if (bIsPlayEnded)
                {
                    updatePlayStatus_Stop();
                    PlayNext();
                }
                else
                {
                    UpdateVedioTime();
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

            initVlcPlayer();
            if (is_playing_&&tbProcess!=null)
            {
                m_vlc.SetPlayTime(tbProcess.Value / 1000.0);
                tbProcess.Value = (int)m_vlc.GetPlayTime();
            }
        }
        private void lbSpeed_Click(object sender, EventArgs e)
        {
            iPlaySpeed++;
            if (iPlaySpeed == 7)
                iPlaySpeed = 0;
            UpdateSpeed();
        }


    
    }
}
