using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Com.Skewky.Cam
{
    public partial class FileMgrForm : Form
    {
        enum CurOprType
        {
            None = 0,
            CopyFile,
            MoveFile,
            DelFile,
            OprFinished
        }
        public FileMgr fileMgr;
        bool bLove = false;
        bool bDel = false;
        bool bPriv = false;
        bool bNote = false;
        bool bNormal = false;
        DateTime dtS = new DateTime(2014,01,12);
        DateTime dtE = DateTime.Now;
         CurOprType iCurOprType = CurOprType.None;
        string keyWord = "";
        string destFolder = "";
        List<string> oprFiles = new List<string>();
        public FileMgrForm(ConfigSettings cf)
        {
            this.KeyPreview = true;

            InitializeComponent();


            fileMgr = new FileMgr(cf);
            initList();
            threadInitAllFiles();
            dtStart.Value = dtS;
        }
        private void initList()
        {
            ColumnHeader cFile = new ColumnHeader();//创建一个列
            cFile.Text = "文件";//列名
            cFile.Width = 120;
            ColumnHeader cStatu = new ColumnHeader();
            cStatu.Text = "状态";
            cStatu.Width = 50;
            ColumnHeader cDiscr = new ColumnHeader();
            cDiscr.Text = "备注";
            cDiscr.Width = 180;
            ColumnHeader cPath = new ColumnHeader();
            cPath.Text = "路径";
            cPath.Width = 180;
            listFiles.Columns.AddRange(new ColumnHeader[] { cFile, cStatu, cDiscr, cPath });//将列加入listView1
            listFiles.View = View.Details;//列的显示模式
        }
        private void initAllFile()
        {
            fileMgr.fileArr.Clear();
            fileMgr.initAllFiles();
        }

        private void threadInitAllFiles()
        {
            timerInitFiles.Interval = 10;
            timerInitFiles.Start();
            Thread trd = new Thread(this.initAllFile);
            trd.Start();
        }
        private void threadCopyFiles()
        {
            timerOprFiles.Interval = 10;
            timerOprFiles.Start();
            iCurOprType = CurOprType.CopyFile;
            lbCurOpr.Text = "后台导出:";
            Thread trd = new Thread(this.copyFiles);
            trd.Start();
        }
        private void threadMoveFiles()
        {
            timerOprFiles.Interval = 10;
            timerOprFiles.Start();
            iCurOprType = CurOprType.MoveFile;
            lbCurOpr.Text = "后台移动:";
            Thread trd = new Thread(this.moveFiles);
            trd.Start();
        }
        private void threadDelFiles()
        {
            timerOprFiles.Interval = 10;
            timerOprFiles.Start();
             iCurOprType = CurOprType.DelFile;
             lbCurOpr.Text = "后台删除:";
             Thread trd = new Thread(this.delFiles);
            trd.Start();
         }
        private void dtStart_ValueChanged(object sender, EventArgs e)
        {
            DateTime dtMin = new DateTime(2014, 11, 1);
            if (dtStart.Value < dtMin)
                dtStart.Value = dtMin;
            if (dtStart.Value > dtEnd.Value)
            {
                dtMin = dtStart.Value;
                dtStart.Value = dtEnd.Value;
                dtEnd.Value = dtMin;
            }
            previewSearchFilter();
        }

        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {
            DateTime dtMax = DateTime.Now;
            if (dtEnd.Value > dtMax)
                dtEnd.Value = dtMax;
            if (dtStart.Value > dtEnd.Value)
            {
                dtMax = dtStart.Value;
                dtStart.Value = dtEnd.Value;
                dtEnd.Value = dtMax;
            }
            previewSearchFilter();
        }

        private void tsmiAll_Click(object sender, EventArgs e)
        {

        }

        private void tsmiAll_CheckedChanged(object sender, EventArgs e)
        {

            // tsslFilter.Text = getFileterString(tsmiLove.Checked, tsmiDel.Checked, tsmiPriv.Checked, tsmiNote.Checked, tsmiAll.Checked,
            //                                dtStart.Value, dtEnd.Value, tbKeyword.Text);
            //fillAllFilesToList();
        }
        private string getFileterString(bool bbLove, bool bbDel, bool bbPriv, bool bbNote, bool bbNormal, DateTime ddS, DateTime ddE, string keyWord)
        {
            bool bHidden = false;
            bool bShow = false;
            String strHidden = "隐藏：";
            String strShow = "显示：";
            if (bbLove)
            {
                bShow = true;
                strShow += "喜爱 ";
            }
            else
            {
                bHidden = true;
                strHidden += "喜爱 ";
            }
            if (bbDel)
            {
                bShow = true;
                strShow += "待删除 ";
            }
            else
            {
                bHidden = true;
                strHidden += "待删 ";
            }
            if (bbPriv)
            {
                bShow = true;
                strShow += "隐私 ";
            }
            else
            {
                bHidden = true;
                strHidden += "隐私 ";
            }
            if (bbNote)
            {
                bShow = true;
                strShow += "备注 ";
            }
            else
            {
                bHidden = true;
                strHidden += "备注 ";
            }
            if (bbNormal)
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
            if (bShow && !bHidden)
                strRes = "[显示全部]";
            else if (!bShow && bHidden)
                strRes = "[什么状况？全隐藏了]";
            else
            {
                if (bShow)
                    strRes = strShow;
                if (bHidden)
                    strRes += strHidden;
            }
            strRes += "[";
            strRes += ddS.ToString("yyyy-MM-dd HH:mm");
            strRes += "--";
            strRes += ddE.ToString("yyyy-MM-dd HH:mm");
            strRes += "]";

            strRes += "关键字:" + keyWord;
            return strRes;
        }

        private void timerInitFiles_Tick(object sender, EventArgs e)
        {
            if (fileMgr.bInitFilesInprocess)
                tssLabel.Text = string.Format("正在扫描文件：已发现{0}个文件", fileMgr.fileArr.Count);
            else
            {
                tssLabel.Text = string.Format("扫描完成：共发现{0}个文件", fileMgr.fileArr.Count);
                updateFilesList();
                timerInitFiles.Stop();
            }
        }
      
        private void updateFilesList()
        {
            initList();
            listFiles.Items.Clear();
            listFiles.Groups.Clear();
            listFiles.ShowGroups = true;
            int maxShow = 300;
            int iIndexed = 0;
            for (int i = 0; i < fileMgr.fileArr.Count; i++)
            {
                if (!File.Exists(fileMgr.fileArr[i]))
                {
                    fileMgr.fileArr.RemoveAt(i);
                    i--;
                    i = Math.Max(i, 0);
                    continue;
                }
                DateTime dt = fileMgr.fileTool.getDtMinByPath(fileMgr.fileArr[i]);
                MarkData mk = new MarkData();
                fileMgr.fileTool.GetMarkData(dt, ref mk);
                bool bCheckShow = checkShow(dt, mk);
                if (!bCheckShow)
                    continue;
                iIndexed++;

                if (i < maxShow)
                {
                    string gpName = string.Format("{0:4D}-{1:2D}-{2:2D}", dt.Year, dt.Month, dt.Day);
                    gpName = dt.ToString("yyyy-MM-dd");
                    string fileName = dt.ToString("yyyy-MM-dd HH:mm");

                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = fileName;
                    lvi.SubItems.Add(mk.MDStr);
                    lvi.SubItems.Add(mk.Description);
                    lvi.SubItems.Add(fileMgr.fileArr[i]);
                    ListViewGroup gp = getGroup(gpName);
                    gp.Items.Add(lvi);
                    listFiles.Items.Add(lvi);
                }
            }
            string msg = string.Format("显示文件:{0}/{1} ", Math.Min(maxShow, iIndexed), fileMgr.fileArr.Count);
            if (iIndexed > maxShow)
                msg += string.Format("符合条件的文件数过多({0}>{1}),列表仅显示了前{1}条,请缩小搜索范围!", iIndexed, maxShow, maxShow);
            tssLabel.Text = msg;
        }
        private bool checkShow(DateTime dt, MarkData mk)
        {
            if (dt < dtS)
                return false;
            if (dt > dtE)
                return false;
            if (!bLove && mk.Favourite)
                return false;
            if (!bDel && mk.ToDelete)
                return false;
            if (!bPriv && mk.Private)
                return false;
            if (!bNote && mk.Describ)
                return false;
            if (!bNormal && !(mk.Favourite || mk.ToDelete || mk.Private || mk.Describ))
                return false;
            if (string.IsNullOrEmpty(keyWord))
                return true;
            else if (!mk.Describ || !mk.Description.Contains(keyWord))
                return false;
            return true;
        }
        private ListViewGroup getGroup(string gpName)
        {
            foreach (ListViewGroup gp in listFiles.Groups)
            {
                if (gp.Header == gpName)
                {
                    return gp;
                }
            }
            ListViewGroup lg = new ListViewGroup();
            lg.Header = gpName;
            lg.HeaderAlignment = HorizontalAlignment.Left;
            listFiles.Groups.Add(lg);
            return lg;
        }

        private void tbKeyword_TextChanged(object sender, EventArgs e)
        {
            previewSearchFilter();
        }
        private void previewSearchFilter()
        {
            lbSearchPrview.Text = getFileterString(miLove.Checked, miDel.Checked, miPriv.Checked, miNote.Checked, miAll.Checked,
                                                dtStart.Value, dtEnd.Value, tbKeyword.Text);
        }
        private void btSelAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lv in listFiles.Items)
            {
                lv.Checked = true;
            }
        }

        private void btSelRev_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lv in listFiles.Items)
            {
                lv.Checked = !lv.Checked;
            }
        }
        private void getSelectedPath(ref List<string> listSels)
        {
            listSels.Clear();
            foreach (ListViewItem lvi in listFiles.CheckedItems)
            {
                    listSels.Add(lvi.SubItems[3].Text);
            }
        }
        private void btExport_Click(object sender, EventArgs e)
        {
            if (listFiles.CheckedItems.Count == 0)
                return;
            destFolder = "";
            if (selectAfolder(true, "请选择要导出到哪个目录", ref destFolder))
            {
                getSelectedPath(ref oprFiles);
                threadCopyFiles();
            }
        }

        private void btMove_Click(object sender, EventArgs e)
        {
            if (listFiles.CheckedItems.Count == 0)
                return ;
            destFolder = "";
            if (selectAfolder(true, "请选择要移动到哪个目录", ref destFolder))
            {
                getSelectedPath(ref oprFiles);
                threadMoveFiles();
            }
        }
        private void moveFiles() //move
        {
            fileMgr.moveFiles(oprFiles, destFolder);
        }
        private void copyFiles() //export
        {
            fileMgr.copyFiles(oprFiles, destFolder);
        
        }
        private void delFiles()
        {
            fileMgr.delFiles(oprFiles);
        }
        private void btDelete_Click(object sender, EventArgs e)
        {
            if (listFiles.CheckedItems.Count == 0)
                return;
            DialogResult res = MessageBox.Show("确认删除所选文件?此操作不可逆!", "确定删除操作", MessageBoxButtons.OKCancel,
                                                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if(res == DialogResult.OK)
                {
                   getSelectedPath(ref oprFiles);
                   threadDelFiles();
                }
        }
        private bool selectAfolder(bool bForExort, string Description, ref string rootDir)
        {
            string path = "";
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.Description = Description;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog.SelectedPath;
                if (fileMgr.newFolderValid(path))
                {
                    rootDir = path;
                    return true;
                }
                else
                {
                    string desMsg = "所选目录不能是已有目录的子目录或父目录,请重新选择";
                    return selectAfolder(bForExort, desMsg, ref rootDir);
                }
            }
            else
            {
                return false;
            }
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            bLove = miLove.Checked;
            bDel = miDel.Checked;
            bPriv = miPriv.Checked;
            bNote = miNote.Checked;
            bNormal = miAll.Checked;
            dtS = dtStart.Value;
            dtE = dtEnd.Value;
            keyWord = tbKeyword.Text;
            tsslFilter.Text = getFileterString(bLove, bDel, bPriv, bNote, bNormal, dtS, dtE, keyWord);
            updateFilesList();
        }

        private void miLove_CheckedChanged(object sender, EventArgs e)
        {
            previewSearchFilter();
        }

        private void miReloadFiles_Click(object sender, EventArgs e)
        {
            threadInitAllFiles();
        }

        private void FileMgrForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {

            }

        }

        private void timerOprFiles_Tick(object sender, EventArgs e)
        {
            updateCurOprStatus();
        }
        private void updateCurOprStatus()
        {
            if (iCurOprType == CurOprType.None)
            {
                lbCurOpr.Visible = false;
                tssProcess.Visible = false;
            }
            else if(iCurOprType == CurOprType.OprFinished)
            {
                timerOprFiles.Interval = 5000;
                iCurOprType = CurOprType.None;
            }
            else   //3kinds of file opr
            {
                lbCurOpr.Visible = true;
                tssProcess.Visible = true;
                tssProcess.Value = fileMgr.iCurIndex;
                tssProcess.Maximum = fileMgr.iTotal;
                if(!fileMgr.bOprFilesInprocess)
                {
                    string msgStr = "";
                    if (iCurOprType == CurOprType.CopyFile)
                    {
                        msgStr = "导出完成";
                    }
                    else if (iCurOprType == CurOprType.MoveFile)
                    {
                        msgStr = "移动完成";
                    }
                    else if (iCurOprType == CurOprType.DelFile)
                    {
                        msgStr = "删除完成";
                    }
                    if (fileMgr.iFaild != 0)
                        msgStr += string.Format("成功{0}失败{1}个", fileMgr.iCurIndex, fileMgr.iFaild);
                    lbCurOpr.Text = msgStr;
                    tssProcess.Visible = false;
                    iCurOprType = CurOprType.OprFinished;
                    updateFilesList();
                }
            }

        }

    }
}
