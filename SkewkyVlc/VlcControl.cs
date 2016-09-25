using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Com.Skewky.Vlc
{
    public partial class VlcControl : UserControl
    {

        public bool bFullScreen = false;

        VlcPlayerUI playUI = new VlcPlayerUI();
        //FullScreenForm fsp = null;//定义成全局量的话第二次显示异常
          
        public VlcControl()
        {
            InitializeComponent();
            playUI.setComponents(panelPlay, timer1, tbProcess, lbVideoTime, lbSound, lbSpeed);
        }
        public void release()
        {
            playUI.release();
        }
        public void PlayFile(string path)
        {
            playUI.PlayFile(path);
        }
        private void picEnv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
//             FullScreenForm fsp = null;
//             if (fsp == null)
//                 fsp = new FullScreenForm();
//             if (bFullScreen)
//             {
//                 bFullScreen = false;
//                 playUI.setPlayInfo(fsp.getVlcPlayInfo());
//                 playUI.Play();
//             }
//             else
//             {
// 
// 
//             }
            if (e.Button == MouseButtons.Left)
            {
                playUI.TogglePlay();
            }
            else if (e.Button == MouseButtons.Right)
                fullScreenPlay();
        }
        private void fullScreenPlay()
        {
            FullScreenForm fsp = null; 
            if (fsp == null)
                fsp = new FullScreenForm();
          
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
        private void picEnv_MouseClick(object sender, MouseEventArgs e)
        {
            //playUI.TogglePlay();
        }


        #region Key Envents
        private void VlcControl_KeyUp(object sender, KeyEventArgs e)
        {
            playUI.Env_KeyUp(sender, e);
        }
        #endregion
    }
}
