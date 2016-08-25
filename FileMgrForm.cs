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
            ColumnHeader cFile = new ColumnHeader();//创建一个列
            cFile.Text = "文件";//列名
            cFile.Width = 80;
            ColumnHeader cStatu = new ColumnHeader();
            cStatu.Text = "状态";
            ColumnHeader cDiscr = new ColumnHeader();
            cDiscr.Text = "备注";
            listFiles.Columns.AddRange(new ColumnHeader[] { cFile, cStatu, cDiscr });//将这两列加入listView1
            listFiles.View = View.Details;//列的显示模式
            initList();
        }
        private void initList()
        {
           listFiles.Items.Clear();
              
            ListViewItem lvi = new ListViewItem();
            lvi.Text = "a";
            lvi.SubItems.Add("b");
            lvi.SubItems.Add("c");
            lvi.SubItems.Add("d");
            lvi.SubItems.Add("e");
            listFiles.Items.Add(lvi);

            ListViewGroup lg = new ListViewGroup();
            lg.Header = "2016";
            lg.HeaderAlignment = HorizontalAlignment.Center;
            listFiles.Groups.Add(lg);
            lg.Items.Add(lvi);
            ListViewGroup otherlvg = new ListViewGroup();
            listFiles.Groups.Add(otherlvg);
            listFiles.ShowGroups = true;
            for (int i = 0; i < 500; i++)
            {
                lvi = new ListViewItem();
                lvi.Text = string.Format("{0}{1}", DateTime.Now.ToString(), i);
                lvi.SubItems.Add("b11");
                lvi.SubItems.Add("c11");
                lvi.SubItems.Add("d22");
                lvi.SubItems.Add("e22");
                listFiles.Items.Add(lvi);
                if(i<50||i>450)
                    otherlvg.Items.Add(lvi);
           
            }
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
            if (tsmiNote.Checked)
            {
                bShow = true;
                strShow += "备注 ";
            }
            else
            {
                bHidden = true;
                strHidden += "备注 ";
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

        private void btSelAll_Click(object sender, EventArgs e)
        {

        }
    }
}
