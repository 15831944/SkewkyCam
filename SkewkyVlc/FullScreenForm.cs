using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Com.Skewky.Vlc
{
    public partial class FullScreenForm : Form
    {
        readonly VlcPlayerUi _playUi= new VlcPlayerUi();
        public PlayInfo FullPlayInfo = new PlayInfo();
        private bool _bDbClick = true;
        public FullScreenForm()
        {
            InitializeComponent();
            _playUi.SetComponents(panelPlay, null, null, lbTimer, lbSound, lbSpeed);
            this.TopMost = true;
        }
       
        public PlayInfo GetVlcPlayInfo()
        {
            FullPlayInfo = _playUi.GetPlayInfo();
            return FullPlayInfo;
        }
        public void SetVlcPlayInfo(PlayInfo playInfo)
        {
            if (null == playInfo)
            {
                return;
            }
            _playUi.SetPlayInfo(playInfo);
        }
        private void FullScreen_MouseDoubleClick(object sender, MouseEventArgs e)
        {
         }

        private void FullScreenPlayer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                ExitFullScreen();
            else
            {
                panelCtrl.Visible = true;
                timer1.Interval = 2000;
                timer1.Start();
                _playUi.Env_KeyUp(sender, e);
                _playUi.UpdateTexts();
            }
        }
        private void ExitFullScreen()
        {
            FullPlayInfo = _playUi.GetPlayInfo();
            this.DialogResult = DialogResult.OK;
            _playUi.Stop();
            this.Visible = false;
            //this.Close();
        }

   
        private void FullScreenPlayer_FormClosed(object sender, FormClosedEventArgs e)
        {
            _playUi.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            panelCtrl.Visible = false;
        }

        private void picEnv_MouseClick(object sender, MouseEventArgs e)
        {
            _bDbClick = false;
            Thread th = new Thread(new ThreadStart(SignClicked));
            th.Start();
        }
        private void SignClicked()
        {
            Thread.Sleep(ConstVars.DbClickIntervel);
            if (!_bDbClick)
            {
                _playUi.TogglePlay();
            }
        }

        private void picEnv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _bDbClick = true;
            ExitFullScreen();
       
        }
    }
}
