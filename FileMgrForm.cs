using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Com.Skewky.Cam
{
    public partial class FileMgrForm : Form
    {
        public FileMgrForm()
        {
            InitializeComponent();
        }

        private void dtStart_ValueChanged(object sender, EventArgs e)
        {
            DateTime dtMin = new DateTime(2014,11,1);
            if (dtStart.Value < dtMin)
                dtStart.Value = dtMin;
        }

        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {
            DateTime dtMax = DateTime.Now;
            if (dtEnd.Value > dtMax)
                dtEnd.Value = dtMax;
        }

        private void tsmiAll_Click(object sender, EventArgs e)
        {

        }

        private void tsmiAll_CheckedChanged(object sender, EventArgs e)
        {
            bool bHidden = false;
            bool bShow = false;
            String strHidden = "隐藏：";
            String strShow = "显示：";
            if (tsmiLove.Checked)
            {
                 bShow = true;
                 strShow += "喜爱 ";
            }
            else
            {
               bHidden = true;
                strHidden += "喜爱 ";
            }
            if (tsmiDel.Checked)
            {
                bShow = true;
                strShow += "待删除 ";
            }
            else
            {
                bHidden = true;
                strHidden += "待删 ";
            }
            if (tsmiPriv.Checked)
            {
                bShow = true;
                strShow += "隐私 ";
            }
            else
            {
                bHidden = true;
                strHidden += "隐私 ";
            }
            if (tsmiAll.Checked)
            {
                bShow = true;
                strShow += "无标注 ";
            }
            else
            {
                bHidden = true;
                strHidden += "无标注 ";
            }
            string strRes = "";
            if(bShow && !bHidden)
                strRes = "显示全部";
            else if (!bShow && bHidden)
                strRes = "什么状况？全隐藏了";
            else 
            {
                if (bShow)
                    strRes = strShow;
                if (bHidden)
                    strRes += strHidden;
            }
            tsslFilter.Text = strRes;
        }
    }
}
