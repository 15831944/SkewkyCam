using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Com.Skewky.Vlc
{
    public partial class VlcControl : UserControl
    {

        public bool bFullScreen = false;
        VlcPlayerUI playUI = new VlcPlayerUI();
        //FullScreenForm fsp = null;//定义成全局量的话第二次显示异常
        private bool bDbClick = false;
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
            bDbClick = true;
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
                if (fsp.ShowDialog() == DialogResult.OK)
                {
                    playUI.setPlayInfo(fsp.fullPlayInfo);
                    bFullScreen = false;
                }
        }
        private void picEnv_MouseClick(object sender, EventArgs e)
        {
            bDbClick = false;
            Thread th = new Thread(new ThreadStart(signClicked));
            th.Start();
        }
        private void signClicked()
        {
            Thread.Sleep(ConstVars.iDbClickIntervel);
            if (!bDbClick)
            {
                playUI.TogglePlay();
            }
        }

        #region Key Envents
        private void VlcControl_KeyUp(object sender, KeyEventArgs e)
        {
            playUI.Env_KeyUp(sender, e);
        }
        #endregion

        private void picEnv_MouseEnter(object sender, EventArgs e)
        {
           this.Focus();
        }

        private void picEnv_MouseMove(object sender, MouseEventArgs e)
        {
           this.Focus();
        }

        private void picEnv_MouseHover(object sender, EventArgs e)
        {
           this.Focus();
        }
        private void picEnv_MouseWheel(object sender, MouseEventArgs e)
        {
            playUI.updateVolume(e.Delta > 0);

        }
        
    }
}



//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Text;
//using System.Windows.Forms;
//using System.Threading;
 
//namespace CSharp_002_回调机制
//{
//    public partial class frmMain : Form
//    {
//        //定义回调
//        private delegate void SetProgressBar2ValueCallBack(int value);
//        //声明回调
//        private SetProgressBar2ValueCallBack setProgressBar2ValueCallBack;
 
//        public frmMain()
//        {
//            InitializeComponent();
//        }
 
//        private void btnStart_Click(object sender, EventArgs e)
//        {
//            //初始化回调
//            setProgressBar2ValueCallBack = new SetProgressBar2ValueCallBack(SetProgressBar2ValueMethod);
 
 
//            Thread progressBar2Thread = new Thread(SetProgressBar2Value);
//            progressBar2Thread.Start();
 
//            for (int i = 0; i <= 100; i++)
//            {
//                Application.DoEvents();
//                Thread.Sleep(50);
//                pgProgressBar1.Value = i;
//            }
//        }
 
//        //设置进度条2的值 的线程
//        private void SetProgressBar2Value()
//        {
//            for (int i = 0; i <= 100;i++ )
//            {
//                Thread.Sleep(50);
//                pgProgressBar2.Invoke(setProgressBar2ValueCallBack, i);
//            }
//        }
//        //设置进度条2的值 被委托的方法
//        private void SetProgressBar2ValueMethod(int value)
//        {
//            pgProgressBar2.Value = value;
//        }
 
//    }//end class frmMain
//}