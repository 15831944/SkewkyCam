using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Com.Skewky.Vlc
{
    public partial class FullScreenPlayer : Form
    {
        VlcPlayer m_vlc;
        private bool bNeedInitVlc = true;
        public PlayInfo fullPlayInfo = new PlayInfo();
        public FullScreenPlayer()
        {
            InitializeComponent();
        }
//         public void setVlcCtrl(VlcControl vlcCtrl)
//         {
//             vlcControl1 = vlcCtrl;
//         }
//         public void getVlcCtrl(ref VlcControl vlcCtrl)
//         {
//             vlcCtrl = vlcControl1;
//         }

        private VlcPlayer newVlcPlayer()
        {
            string pluginPath = System.Environment.CurrentDirectory + "\\vlc\\plugins\\";
            VlcPlayer vlcPlayer = new VlcPlayer(pluginPath);
            IntPtr render_wnd = this.panelPlay.Handle;
            vlcPlayer.SetRenderWindow((int)render_wnd);
            return vlcPlayer;
        }
        public void UpdateVlcStatusStart()
        {
            //vlcControl1.Play();
            //vlcControl1.updateTexts();
        }
        public void getVlc(ref VlcPlayer vlc)
        {
            if (bNeedInitVlc)
            {
                return;
            }
            m_vlc.getPlayInfo(ref fullPlayInfo);
            vlc.setPlayInfo(fullPlayInfo);
           // vlc.Copy(m_vlc);
           // vlcControl1.setVlcPlayer(vlc);
        }
        public void setVlc(VlcPlayer vlc)
        {
            if (bNeedInitVlc)
            {
                m_vlc = newVlcPlayer();
                //     vlcControl1.bFullScreen = true;
            }
            //  vlcControl1.setVlcPlayer(vlc);
            //m_vlc.Copy(vlc);
            //m_vlc.Play();
             vlc.getPlayInfo(ref fullPlayInfo);
            m_vlc.setPlayInfo(fullPlayInfo);
         
            //m_vlc.PlayFile(@"E:\abc\2016年02月23日\20时\08分00秒.mp4");
        }
        private void FullScreen_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            exitFullScreen();
        }

        private void FullScreenPlayer_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_vlc.Stop();
        }

        private void FullScreenPlayer_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                exitFullScreen();
        }
        private void exitFullScreen()
        {
            m_vlc.getPlayInfo(ref fullPlayInfo);
            this.DialogResult = DialogResult.OK;
            m_vlc.Stop();
            this.Close();
        }
    }
}
