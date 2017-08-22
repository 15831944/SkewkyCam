using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Com.Skewky.Vlc
{
    class VlcPlayerUi
    {
        #region fileds
        public int PlaySpeed = 2;
        public int Valume = 80;
        public NextFileSta NfSta = NextFileSta.NfNeedFind;
        private string _nextFilePath = "";

        public bool BAutoPlayNext
        {
            get { return _bAutoPlayNext; }
            set { _bAutoPlayNext = value; }
        }

        private bool _bAutoPlayNext = true;

        private VlcPlayer _mVlc = null;
        //private VlcPlayer _mVlcNext = null;
        private Panel _panelPlay = null;
        private Timer _playTimer = null;
        private TrackBar _tbProcess = null;
        private Label _lbVideoTime = null;
        private Label _lbSound = null;
        private Label _lbSpeed = null;
        private bool InitVlcPlayer()
        {
            if (null == _mVlc)
            {
                _mVlc = NewVlcPlayer();
                //_mVlcNext = NewVlcPlayer();
            }
            return true;
        }
        private VlcPlayer NewVlcPlayer()
        {
            string pluginPath = System.Environment.CurrentDirectory + "\\plugins\\";
            VlcPlayer vlcPlayer = new VlcPlayer(pluginPath);
            IntPtr renderWnd = this._panelPlay.Handle;
            vlcPlayer.SetRenderWindow((int)renderWnd);
            return vlcPlayer;
        }
        public void InitNextFile(string path)
        {

            InitVlcPlayer();
            if (string.IsNullOrEmpty(path))   //clear
            {
                NfSta = NextFileSta.NfNeedFind;
                _nextFilePath = path;
                return;
            }
            if (!System.IO.File.Exists(path))
            {
                NfSta = NextFileSta.NfNotFind;
                return;
            }
            if (!_bAutoPlayNext)
                return;
            _nextFilePath = path;
            NfSta = NextFileSta.NfFound;
            //  UpdateTexts();

        }
        #endregion

        #region private methonds
        private void PlayNext()
        {

            InitVlcPlayer();
            if (!_bAutoPlayNext || NfSta != NextFileSta.NfFound)
                return;
            _mVlc.PlayFile(_nextFilePath);
            NfSta = NextFileSta.NfNeedFind;
            updatePlayStatus_Start();
            UpdateTexts();
        }
        private static string GetTimeString(int val)
        {
            int hour = val / 3600;
            val %= 3600;
            int minute = val / 60;
            int second = val % 60;
            return string.Format("{0:00}:{1:00}:{2:00}", hour, minute, second);
        }
        private void playTimer_Tick(object sender, EventArgs e)
        {

            InitVlcPlayer();
            if (_mVlc.IsPlaying)
            {
                double playTime = _mVlc.GetPlayTime();
                double duraTime = _mVlc.Duration();
                bool bIsPlayEnded = _mVlc.IsPlayEnded();
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
        #endregion

        #region publicMethonds
        public void SetComponents(Panel panel, Timer timer, TrackBar tbBar, Label lbVdTime, Label lbSd, Label lbSp)
        {
            _panelPlay = panel;
            _playTimer = timer;
            _tbProcess = tbBar;
            _lbVideoTime = lbVdTime;
            _lbSound = lbSd;
            _lbSpeed = lbSp;

            if (_playTimer != null)
            {
                _playTimer.Tick += new System.EventHandler(playTimer_Tick);
            }
            if (_tbProcess != null)
            {
                _tbProcess.Scroll += new System.EventHandler(tbProcess_Scroll);
            }
            if (_lbSpeed != null)
            {
                _lbSpeed.Click += new System.EventHandler(lbSpeed_Click);
            }
        }

        public void Release()
        {
            if (_mVlc != null)
                _mVlc.Stop();
            //if (_mVlcNext != null)
            //    _mVlcNext.Stop();
        }
        public void PlayFile(string path)
        {
            InitVlcPlayer();
            _mVlc.PlayFile(path);
            updatePlayStatus_Start();
        }

        public string GetPlayPath()
        {
            InitVlcPlayer();
            return _mVlc.GetPlayPath();
        }
        public void SetPlayInfo(PlayInfo pInfo)
        {
            InitVlcPlayer();
            _mVlc.SetPlayInfo(pInfo);
            UpdateTexts();
        }
        public PlayInfo GetPlayInfo()
        {
            InitVlcPlayer();
            return _mVlc.GetPlayInfo();
        }
        #endregion

        #region updateStatus
        private void updatePlayStatus_Start()
        {

            InitVlcPlayer();
            _mVlc.Play();
            _mVlc.SetRate(ConstVars.GetDoubleSpeed(PlaySpeed));
            _mVlc.SetVolume(Valume);

            double dDuration = _mVlc.Duration();
            if (_tbProcess != null)
            {
                _tbProcess.SetRange(0, (int)dDuration);
                _tbProcess.Value = 0;
            }
            if (_playTimer != null)
            {
                _playTimer.Start();
            }
            UpdateTexts();
        }
        private void updatePlayStatus_Stop()
        {
            InitVlcPlayer();
            _mVlc.Stop();
            if (_tbProcess != null)
            {
                _tbProcess.Value = _tbProcess.Maximum;
            }
            if (_playTimer != null)
            {
                _playTimer.Stop();
            }
            UpdateTexts();
        }
        private void ResetTimerInterval()
        {
            if (_playTimer == null)
                return;
            double dInv = 1 / ConstVars.GetDoubleSpeed(PlaySpeed);
            _playTimer.Interval = (int)(dInv * 1000);
        }
        public void Play()
        {
            InitVlcPlayer();
            _mVlc.Play();
            UpdateTexts();
        }
        public void Pause()
        {
            InitVlcPlayer();
            _mVlc.Pause();
            UpdateTexts();
        }
        public void TogglePlay()
        {
            InitVlcPlayer();
            _mVlc.TooglePlay();
            //UpdateTexts(); 因为暂停使用了Thread,如果添加这句会造成因线程中调用界面的东西而崩溃

        }
        public void Stop()
        {
            InitVlcPlayer();
            _mVlc.Stop();
        }
        public void UpdateTexts()
        {
            InitVlcPlayer();
            UpdateVolume();
            UpdateSpeed();
            UpdateVedioTime();
        }

        public void SetValume(int iValume)
        {
            Valume = iValume;
            UpdateVolume();
        }
        public void ChangeVolume(bool bLouder)
        {
            //设置声音
            InitVlcPlayer();
            Valume = _mVlc.GetVolume();

            if (bLouder)
                Valume += 5;
            else
                Valume -= 5;
            if (Valume < 0)
                Valume = 0;
            UpdateVolume();
        }
        public void UpdateVolume()
        {

            InitVlcPlayer();
            _mVlc.SetVolume(Valume);

            if (null == _lbSound)
                return;
            _lbSound.Text = string.Format("{0}", Valume);
            if (Valume > 100)
                _lbSound.ForeColor = Color.Red;
            else
                _lbSound.ForeColor = Color.Black;
        }
        public void SetSpeed(int iSpeed)
        {

            InitVlcPlayer();
            PlaySpeed = iSpeed;
            double dRate = ConstVars.GetDoubleSpeed(PlaySpeed);
            _mVlc.SetRate(dRate);
            ResetTimerInterval();
            UpdateSpeed();
        }
        public void UpdateSpeed()
        {

            if (_lbSpeed == null)
                return;

            InitVlcPlayer();
            double dRate = ConstVars.GetDoubleSpeed(PlaySpeed);

            _lbSpeed.Visible = true;
            _lbSpeed.Text = string.Format("{0:N1}x", dRate);
        }
        public void UpdateVedioTime(double dSteep = 0)
        {
            InitVlcPlayer();
            double curPlayTime = _mVlc.GetPlayTime() * 1000 + dSteep;
            curPlayTime = Math.Max(0, curPlayTime);
            curPlayTime = Math.Min(_mVlc.Duration(), curPlayTime);
            if (!double.Equals(dSteep, 0.0))
            {
                _mVlc.SetPlayTime(curPlayTime / 1000);
            }

            if (_lbVideoTime == null)
                return;

            _lbVideoTime.Text = string.Format("{0}/{1}",
                GetTimeString((int)(curPlayTime / 1000.0)),
                GetTimeString((int)(_mVlc.Duration() / 1000.0)));

            if (_tbProcess == null)
                return;
            _tbProcess.Value = (int)curPlayTime;
        }
        #endregion

        #region MouseEnvents
        private void tbProcess_Scroll(object sender, EventArgs e)
        {

            InitVlcPlayer();
            if (_mVlc.IsPlaying && _tbProcess != null)
            {
                _mVlc.SetPlayTime(_tbProcess.Value / 1000.0);
                _tbProcess.Value = (int)_mVlc.GetPlayTime();
            }
        }
        private void lbSpeed_Click(object sender, EventArgs e)
        {
            PlaySpeed++;
            if (PlaySpeed == 7)
                PlaySpeed = 0;
            SetSpeed(PlaySpeed);
        }
        #endregion

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
                int curSpd = PlaySpeed;
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
                //音量调节
                ChangeVolume(Keys.Up == e.KeyCode);
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
