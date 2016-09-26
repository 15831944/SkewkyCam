﻿using System;
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
        VlcPlayerUI playUI= new VlcPlayerUI();
        public PlayInfo fullPlayInfo = new PlayInfo();
        public FullScreenForm()
        {
            InitializeComponent();
            playUI.setComponents(panelPlay, null, null, lbTimer, lbSound, lbSpeed);
            this.TopMost = true;
        }
       
        public PlayInfo getVlcPlayInfo()
        {
            fullPlayInfo = playUI.getPlayInfo();
            return fullPlayInfo;
        }
        public void setVlcPlayInfo(PlayInfo playInfo)
        {
            if (null == playInfo)
            {
                return;
            }
            playUI.setPlayInfo(playInfo);
        }
        private void FullScreen_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            exitFullScreen();
        }

        private void FullScreenPlayer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                exitFullScreen();
            else
            {
                panelCtrl.Visible = true;
                timer1.Interval = 2000;
                timer1.Start();
                playUI.Env_KeyUp(sender, e);
                playUI.updateTexts();
            }
        }
        private void exitFullScreen()
        {
            fullPlayInfo = playUI.getPlayInfo();
            this.DialogResult = DialogResult.OK;
            playUI.Stop();
            this.Visible = false;
            //this.Close();
        }

   
        private void FullScreenPlayer_FormClosed(object sender, FormClosedEventArgs e)
        {
            playUI.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            panelCtrl.Visible = false;
        }
    }
}