using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Com.Skewky.Cam
{
    public partial class Form1 : Form
    {
        private VlcPlayer vlc_player_;
        private bool is_playing_;
        private bool is_fullScreen_;
        private int vlc_Speed;
        private int vlc_Valume;
        public Form1()
        {
            InitializeComponent();

            string pluginPath = System.Environment.CurrentDirectory + "\\vlc\\plugins\\";
            vlc_player_ = new VlcPlayer(pluginPath);
            IntPtr render_wnd = this.panel1.Handle;
            vlc_player_.SetRenderWindow((int)render_wnd);
            vlc_Speed = 10;
            vlc_Valume = 50;

            txSound.Text = string.Format("{0}", vlc_Valume);
            tbVideoTime.Text = "00:00:00/00:00:00";
            
            is_playing_ = false;
            is_fullScreen_ = false;
            this.KeyPreview = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                vlc_player_.PlayFile(ofd.FileName);
                vlc_player_.SetRate(1);
                vlc_player_.SetVolume(vlc_Valume);
           
                trackBar1.SetRange(0, (int)vlc_player_.Duration());
                trackBar1.Value = 0;
                timer1.Start();
                is_playing_ = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (is_playing_)
            {
                vlc_player_.Stop();
                trackBar1.Value = 0;
                timer1.Stop();
                is_playing_ = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (is_playing_)
            {
                if (trackBar1.Value >= trackBar1.Maximum)
                {
                    vlc_player_.Stop();
                    timer1.Stop();
                }
                else
                {
                    trackBar1.Value = trackBar1.Value + 1 * vlc_Speed/10;
                    tbVideoTime.Text = string.Format("{0}/{1}", 
                        GetTimeString(trackBar1.Value), 
                        GetTimeString(trackBar1.Maximum));
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

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (is_playing_)
            {
                vlc_player_.SetPlayTime(trackBar1.Value);
                trackBar1.Value = (int)vlc_player_.GetPlayTime();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }
        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            //设置声音
            vlc_Valume = vlc_player_.GetVolume();
           
            if (e.Delta == 120)
                vlc_Valume += 5;
            else if (e.Delta == -120)
                vlc_Valume -=5;
            
            if (vlc_Valume < 0)
                vlc_Valume = 0;
            vlc_player_.SetVolume(vlc_Valume);
            txSound.Text = string.Format("{0}", vlc_Valume);
            if (vlc_Valume > 100)
                txSound.ForeColor = Color.Red;
            else
                txSound.ForeColor = Color.Black;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox1.Focus();
      
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox1.Focus();
      
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            MouseButtons clk = e.Button;
            if (clk == MouseButtons.Left)
            {
               // togglePlay();
            }
            if(clk == MouseButtons.Middle)
            {
                toggleFullScreen();
            }

        }

        private void toggleFullScreen()
        {
            is_fullScreen_ = !is_fullScreen_;
            vlc_player_.SetFullScreen(is_fullScreen_);
        }
        private void togglePlay()
        {
            if (is_playing_)
            {
                vlc_player_.Pause();
                timer1.Stop();
                is_playing_ = false;
            }
            else
            {
                vlc_player_.Play();
                timer1.Start();
                is_playing_ = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            vlc_player_.Stop();
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                togglePlay();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (Keys.Space == e.KeyCode)
            {
                togglePlay();
            }
            //前进
            if (Keys.Left == e.KeyCode)
            {
                int newPlayTime = trackBar1.Value - 5 * vlc_Speed/10;
                newPlayTime = newPlayTime < 0 ? 0 : newPlayTime;
                vlc_player_.SetPlayTime(newPlayTime);
                trackBar1.Value = (int)vlc_player_.GetPlayTime();
            }
            //后退
            if (Keys.Right == e.KeyCode)
            {
                int newPlayTime = trackBar1.Value + 5 * vlc_Speed/10;
                newPlayTime = newPlayTime < 0 ? 0 : newPlayTime;
                vlc_player_.SetPlayTime(newPlayTime);
                trackBar1.Value = (int)vlc_player_.GetPlayTime();
            }
            //加速
            if (Keys.Up == e.KeyCode)
            {
                if (vlc_Speed < 10)
                    vlc_Speed += 1;
                else
                    vlc_Speed += 5;
                if (vlc_Speed > 160)
                    vlc_Speed = 160;
                vlc_player_.SetRate(vlc_Speed/10);
            }
            //减速
            if (Keys.Down == e.KeyCode)
            {
                if (vlc_Speed <= 10)
                    vlc_Speed -= 1;
                else
                    vlc_Speed -= 5;
                if (vlc_Speed < 1)
                    vlc_Speed = 1;
                vlc_player_.SetRate(vlc_Speed/10);
            }
            if(vlc_Speed==10)
            {
                txSpeed.Visible = false;
            }
            else
            {
                txSpeed.Visible = true;
                txSpeed.Text = string.Format("播放速度：{0}x", (double)vlc_Speed/10);
            }
        }
    }
}
