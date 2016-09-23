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

        public bool bFullScreen = false;

        VlcPlayerUI playUI = new VlcPlayerUI();

        public VlcControl()
        {
            InitializeComponent();
            playUI.setComponents(panelPlay, timer1, tbProcess, lbVideoTime, lbSound, lbSpeed);
        }
        public void PlayFile(string path)
        {
            playUI.PlayFile(path);
        }
        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FullScreenForm fsp = null;
            if (fsp == null)
                fsp = new FullScreenForm();
            if (bFullScreen)
            {
                bFullScreen = false;
                playUI.setPlayInfo(fsp.getVlcPlayInfo());
                playUI.Play();
            }
            else
            {
                bFullScreen = true;
                fsp.setVlcPlayInfo(playUI.getPlayInfo());
                playUI.Pause();
                int iActulaWidth = Screen.PrimaryScreen.Bounds.Width;
                int iActulaHeight = Screen.PrimaryScreen.Bounds.Height;
                fsp.SetBounds(0, 0, iActulaWidth, iActulaHeight);
                // fsp.Visible = true;
                if (fsp.ShowDialog() == DialogResult.OK)
                {
                    playUI.setPlayInfo(fsp.fullPlayInfo);
                    bFullScreen = false;
                }

            }

        }

    }
}
