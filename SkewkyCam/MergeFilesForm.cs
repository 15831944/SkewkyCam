using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Com.Skewky.Cam
{
    public partial class MergeFilesForm : Form
    {
        public MergeFilesForm()
        {
            InitializeComponent();
        }
        public void playTestFile()
        {
            string path = @"d:\Users\bin\Desktop\新建文件夹 (2)\2016年01月03日\21时\52分00秒.mp4";
            vlcCtrl.PlayFile(path);
        }
    }
}
