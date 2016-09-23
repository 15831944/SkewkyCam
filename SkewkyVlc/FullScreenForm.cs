using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Com.Skewky.Vlc
{
    public partial class FullScreenForm : Form
    {
        VlcPlayerUI vlcPlayer= new VlcPlayerUI();
        public PlayInfo fullPlayInfo = new PlayInfo();
        public FullScreenForm()
        {
            InitializeComponent();
            vlcPlayer.setComponents(panelPlay, null, null, null, null, null);
        }
       
        public PlayInfo getVlcPlayInfo()
        {
            fullPlayInfo = vlcPlayer.getPlayInfo();
            return fullPlayInfo;
        }
        public void setVlcPlayInfo(PlayInfo playInfo)
        {
            if (null == playInfo)
            {
                return;
            }
            vlcPlayer.setPlayInfo(playInfo);
        }
        private void FullScreen_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            exitFullScreen();
        }

        private void FullScreenPlayer_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                exitFullScreen();
        }
        private void exitFullScreen()
        {
            fullPlayInfo = vlcPlayer.getPlayInfo();
            this.DialogResult = DialogResult.OK;
            vlcPlayer.Stop();
            this.Close();
        }

   
        private void FullScreenPlayer_FormClosed(object sender, FormClosedEventArgs e)
        {
            vlcPlayer.Stop();
        }
    }
}
