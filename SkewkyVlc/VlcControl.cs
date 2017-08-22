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

        public bool BFullScreen = false;
        readonly VlcPlayerUi _playUi = new VlcPlayerUi();
        //FullScreenForm fsp = null;//定义成全局量的话第二次显示异常
        private bool _bDbClick = false;
        public VlcControl()
        {
            InitializeComponent();
            _playUi.SetComponents(panelPlay, timer1, tbProcess, lbVideoTime, lbSound, lbSpeed);
        }
        public void Release()
        {
            _playUi.Release();
        }
        public void PlayFile(string path)
        {
            _playUi.PlayFile(path);
        }

        public void SetAutoPlayNext(bool bAutoPlayNext)
        {
            _playUi.BAutoPlayNext = bAutoPlayNext;
        }

        public void SetNextPlayFile(string nextFilePath)
        {
            _playUi.InitNextFile(nextFilePath);
        }
        private void picEnv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _bDbClick = true;
            FullScreenPlay();
        }
        private void FullScreenPlay()
        {
            FullScreenForm fsp = null; 
            //if (fsp == null)
                fsp = new FullScreenForm();
          
                BFullScreen = true;
                fsp.SetVlcPlayInfo(_playUi.GetPlayInfo());
                _playUi.Pause();
                int iActulaWidth = Screen.PrimaryScreen.Bounds.Width;
                int iActulaHeight = Screen.PrimaryScreen.Bounds.Height;
                fsp.SetBounds(0, 0, iActulaWidth, iActulaHeight);
                if (fsp.ShowDialog() == DialogResult.OK)
                {
                    _playUi.SetPlayInfo(fsp.FullPlayInfo);
                    BFullScreen = false;
                }
        }
        private void picEnv_MouseClick(object sender, EventArgs e)
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

        #region Key Envents
        private void VlcControl_KeyUp(object sender, KeyEventArgs e)
        {
            _playUi.Env_KeyUp(sender, e);
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
            _playUi.ChangeVolume(e.Delta > 0);

        }

        public void SetValume(int iValume)
        {
            _playUi.Valume = iValume;
            _playUi.UpdateVolume();
        }

        public int GetValume()
        {
            return _playUi.Valume;
        }

        public void InitNextPlayFile(string path)
        {
            _playUi.InitNextFile(path);
        }
        public int SetPlaySpeed(int iPlaySpeed)
        {
            return _playUi.PlaySpeed = iPlaySpeed;
        }
        public int GetPlaySpeed()
        {
            return _playUi.PlaySpeed;
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