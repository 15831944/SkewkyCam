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

        public bool is_playing_ = false;
    
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
            updateTexts();
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
            updateTexts();
     
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
            updateTexts();
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
            updateTexts();
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
            updateTexts();
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
            updateTexts();
        }
        public void Pause()
        {
            m_vlc.Pause();
            updateTexts();
        }
        public void TogglePlay()
        {
            if (is_playing_)
                m_vlc.Pause();
            else
                m_vlc.Play();
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
            UpdateVedioTime();
        }
        public void updateVolume(bool bLouder)
        {
            //设置声音
             initVlcPlayer();
           iValume = m_vlc.GetVolume();

            if (bLouder)
                iValume += 5;
            else
                iValume -= 5;

            if (iValume < 0)
                iValume = 0;
            m_vlc.SetVolume(iValume);
            updateVolume();
        }
        public void updateVolume()
        {

            if (null == lbSound)
                return;
            lbSound.Text = string.Format("{0}", iValume);
            if (iValume > 100)
                lbSound.ForeColor = Color.Red;
            else
                lbSound.ForeColor = Color.Black;
        }
        public void SetSpeed(int iSpeed)
        {

            initVlcPlayer();
            iPlaySpeed = iSpeed;
            double dRate = ConstVars.getDoubleSpeed(iPlaySpeed);
            m_vlc.SetRate(dRate);
            resetTimerInterval();
            UpdateSpeed();
        }
        public void UpdateSpeed()
        {

            if (lbSpeed == null)
                return;

            initVlcPlayer();
            double dRate = ConstVars.getDoubleSpeed(iPlaySpeed);
            
            lbSpeed.Visible = true;
            lbSpeed.Text = string.Format("{0:N1}x", dRate);
        }
        public void UpdateVedioTime(double dSteep = 0)
        {
            initVlcPlayer();
            double curPlayTime = m_vlc.GetPlayTime() * 1000 + dSteep;
            curPlayTime = Math.Max(0, curPlayTime);
            curPlayTime = Math.Min(m_vlc.Duration(), curPlayTime);
            if (!double.Equals(dSteep,0.0))
            {
                m_vlc.SetPlayTime(curPlayTime/1000);
            }

            if (lbVideoTime == null)
                return;

            lbVideoTime.Text = string.Format("{0}/{1}",
                GetTimeString((int)(curPlayTime / 1000.0)),
                GetTimeString((int)(m_vlc.Duration() / 1000.0)));

            if (tbProcess == null)
                return;
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
            SetSpeed(iPlaySpeed);
        }
        #region Key Envents
        public void Env_KeyUp(object sender, KeyEventArgs e)
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

            }
            else if (e.Alt)
            {
                KeyEnv_TogglePlay(sender, e);

            }
            else if (e.Control)
            {
                KeyEnv_Speed(sender, e);
            }
            else if (e.Shift)
            {

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
                TogglePlay();
            }
        }
        private void KeyEnv_Speed(object sender, KeyEventArgs e)
        {
            if (Keys.Up == e.KeyCode ||
                Keys.Down == e.KeyCode)
            {
                int curSpd = iPlaySpeed;
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
                curSpd = Math.Max(curSpd, 0);
                curSpd = Math.Min(curSpd, 6);
                SetSpeed(curSpd);
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
                double dSpeedStep = 5000;      //5s per step
                //后退
                if (Keys.Left == e.KeyCode)
                {
                    dSpeedStep = -dSpeedStep;
                }
                //前进
                if (Keys.Right == e.KeyCode)
                {
                }
                UpdateVedioTime(dSpeedStep); ;
                //trackBar1.Value = (int)vlc_player_.GetPlayTime();
            }

        }

        #endregion
     
    }
}
