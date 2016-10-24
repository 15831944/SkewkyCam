using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Com.Skewky.Cam
{
    public partial class FileMgrForm : Form
    {
        private bool _bDel = true;
        private bool _bFirstTimeUpdateList;
        private bool _bLove = true;
        private bool _bNormal = true;
        private bool _bNote = true;
        private bool _bPriv = true;
        private string _destFolder = "";
        private DateTime _dtE = DateTime.Now;
        private DateTime _dtS = new DateTime(2014, 11, 01);
        private CurOprType _iCurOprType = CurOprType.None;
        private string _keyWord = "";
        private List<string> _oprFiles = new List<string>();

        //private VlcPlayer vlc_player_;
        private Thread _trdFileInit;
        private Thread _trdFileOpr;
        public FileOpr FileOperator;


        public FileMgrForm(ConfigSettings cf)
        {
            KeyPreview = true;

            InitializeComponent();

            miLove.Checked = _bLove;
            miDel.Checked = _bDel;
            miPriv.Checked = _bPriv;
            miAll.Checked = _bNormal;
            miNote.Checked = _bNote;
            dtStart.Value = _dtS;
            dtEnd.Value = _dtE;
            //vlc_player_ = newVlcPlayer();
            FileOperator = new FileOpr(cf);
            InitList();
            ThreadInitAllFiles();
            dtStart.Value = _dtS;
            tsslFilter.Text = getFileterString(_bLove, _bDel, _bPriv, _bNote, _bNormal, _dtS, _dtE, _keyWord);
            lbCurOpr.Text = "";
        }

        private void PlayFile(string path)
        {
            vlcCtrl.PlayFile(path);
        }

        private void InitList()
        {
            var cFile = new ColumnHeader
            {
                Text = "文件",
                Width = 120
            }; //创建一个列
            //列名
            var cStatu = new ColumnHeader
            {
                Text = "状态",
                Width = 50
            };
            var cDiscr = new ColumnHeader
            {
                Text = "备注",
                Width = 180
            };
            var cPath = new ColumnHeader();
            cPath.Text = "路径";
            cPath.Width = 280;
            listFiles.Columns.AddRange(new[] {cFile, cStatu, cDiscr, cPath}); //将列加入listView1
            listFiles.View = View.Details; //列的显示模式
        }

        private void InitAllFile()
        {
            FileOperator.FileArr.Clear();
            FileOperator.InitAllFiles();
        }

        private void ThreadInitAllFiles()
        {
            timerInitFiles.Interval = 10;
            timerInitFiles.Start();
            _bFirstTimeUpdateList = true;
            _trdFileInit = new Thread(InitAllFile);
            _trdFileInit.Start();
        }

        private void ThreadCopyFiles()
        {
            timerOprFiles.Interval = 10;
            timerOprFiles.Start();
            _iCurOprType = CurOprType.CopyFile;
            lbCurOpr.Text = @"后台导出:";
            _trdFileOpr = new Thread(CopyFiles);
            _trdFileOpr.Start();
        }

        private void ThreadMoveFiles()
        {
            timerOprFiles.Interval = 10;
            timerOprFiles.Start();
            _iCurOprType = CurOprType.MoveFile;
            lbCurOpr.Text = @"后台移动:";
            _trdFileOpr = new Thread(MoveFiles);
            _trdFileOpr.Start();
        }

        private void ThreadDelFiles()
        {
            timerOprFiles.Interval = 10;
            timerOprFiles.Start();
            _iCurOprType = CurOprType.DelFile;
            lbCurOpr.Text = @"后台删除:";
            _trdFileOpr = new Thread(DelFiles);
            _trdFileOpr.Start();
        }

        private void dtStart_ValueChanged(object sender, EventArgs e)
        {
            var dtMin = new DateTime(2014, 11, 1);
            if (dtStart.Value < dtMin)
                dtStart.Value = dtMin;
            if (dtStart.Value > dtEnd.Value)
            {
                dtMin = dtStart.Value;
                dtStart.Value = dtEnd.Value;
                dtEnd.Value = dtMin;
            }
            PreviewSearchFilter();
        }

        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {
            var dtMax = DateTime.Now;
            if (dtEnd.Value > dtMax)
                dtEnd.Value = dtMax;
            if (dtStart.Value > dtEnd.Value)
            {
                dtMax = dtStart.Value;
                dtStart.Value = dtEnd.Value;
                dtEnd.Value = dtMax;
            }
            PreviewSearchFilter();
        }

        private string getFileterString(bool bbLove, bool bbDel, bool bbPriv, bool bbNote, bool bbNormal, DateTime ddS,
            DateTime ddE, string keyWord)
        {
            var bHidden = false;
            var bShow = false;
            var strHidden = "隐藏：";
            var strShow = "显示：";
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
            var strRes = "";
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
            if (FileOperator.BInitFilesInprocess)
            {
                tssLabel.Text = string.Format("正在扫描文件：已发现{0}个文件", FileOperator.FileArr.Count);
                if (_bFirstTimeUpdateList && FileOperator.FileArr.Count > 300)
                {
                    var fileArr = new List<string>();
                    fileArr.AddRange(FileOperator.FileArr);
                    UpdateFilesList_ByArr(fileArr);
                    _bFirstTimeUpdateList = false;
                }
            }
            else
            {
                tssLabel.Text = string.Format("扫描完成：共发现{0}个文件", FileOperator.FileArr.Count);
                UpdateFilesList();
                timerInitFiles.Stop();
            }
        }

        private void UpdateFilesList_ByArr(List<string> fileArr)
        {
            listFiles.Items.Clear();
            listFiles.Groups.Clear();
            listFiles.ShowGroups = true;
            var maxShow = 1000;
            var iIndexed = 0;
            for (var i = 0; i < fileArr.Count; i++)
            {
                if (!File.Exists(fileArr[i]))
                {
                    fileArr.RemoveAt(i);
                    i--;
                    i = Math.Max(i, 0);
                    continue;
                }
                var dt = FileOperator.FileTool.GetDtMinByPath(fileArr[i]);
                var mk = new MarkData();
                FileOperator.FileTool.GetMarkData(dt, ref mk);
                var bCheckShow = CheckShow(dt, mk);
                if (!bCheckShow)
                    continue;

                if (iIndexed < maxShow)
                {
                    iIndexed++;
                    var gpName = string.Format("{0:4D}-{1:2D}-{2:2D}", dt.Year, dt.Month, dt.Day);
                    gpName = dt.ToString("yyyy-MM-dd");
                    var fileName = dt.ToString("yyyy-MM-dd HH:mm");

                    var lvi = new ListViewItem();
                    lvi.Text = fileName;
                    lvi.SubItems.Add(mk.MarkDataStr);
                    lvi.SubItems.Add(mk.Description);
                    lvi.SubItems.Add(fileArr[i]);
                    var gp = GetGroup(gpName);
                    gp.Items.Add(lvi);
                    listFiles.Items.Add(lvi);
                }
                else
                    break;
            }
            var msg = string.Format("显示文件:{0}/{1} ", Math.Min(maxShow, iIndexed), fileArr.Count);
            if (iIndexed > maxShow)
                msg += string.Format("符合条件的文件数过多({0}>{1}),列表仅显示了前{1}条,请缩小搜索范围!", iIndexed, maxShow, maxShow);
            tssLabel.Text = msg;
        }

        private void UpdateFilesList()
        {
            UpdateFilesList_ByArr(FileOperator.FileArr);
        }

        private bool CheckShow(DateTime dt, MarkData mk)
        {
            if (dt < _dtS)
                return false;
            if (dt > _dtE)
                return false;
            if (!_bLove && mk.Favourite)
                return false;
            if (!_bDel && mk.ToDelete)
                return false;
            if (!_bPriv && mk.Private)
                return false;
            if (!_bNote && mk.Describ)
                return false;
            if (!_bNormal && !(mk.Favourite || mk.ToDelete || mk.Private || mk.Describ))
                return false;
            if (string.IsNullOrEmpty(_keyWord))
                return true;
            if (!mk.Describ || !mk.Description.Contains(_keyWord))
                return false;
            return true;
        }

        private ListViewGroup GetGroup(string gpName)
        {
            foreach (ListViewGroup gp in listFiles.Groups)
            {
                if (gp.Header == gpName)
                {
                    return gp;
                }
            }
            var lg = new ListViewGroup();
            lg.Header = gpName;
            lg.HeaderAlignment = HorizontalAlignment.Left;
            listFiles.Groups.Add(lg);
            return lg;
        }

        private void tbKeyword_TextChanged(object sender, EventArgs e)
        {
            PreviewSearchFilter();
        }

        private void PreviewSearchFilter()
        {
            lbSearchPrview.Text = getFileterString(miLove.Checked, miDel.Checked, miPriv.Checked, miNote.Checked,
                miAll.Checked,
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

        private void GetSelectedPath(ref List<string> listSels)
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
            _destFolder = "";
            if (SelectAfolder(true, "请选择要导出到哪个目录", ref _destFolder))
            {
                GetSelectedPath(ref _oprFiles);
                ThreadCopyFiles();
            }
        }

        private void btMove_Click(object sender, EventArgs e)
        {
            if (listFiles.CheckedItems.Count == 0)
                return;
            _destFolder = "";
            if (SelectAfolder(true, "请选择要移动到哪个目录", ref _destFolder))
            {
                GetSelectedPath(ref _oprFiles);
                ThreadMoveFiles();
            }
        }

        private void MoveFiles() //move
        {
            FileOperator.MoveFiles(_oprFiles, _destFolder);
        }

        private void CopyFiles() //export
        {
            FileOperator.CopyFiles(_oprFiles, _destFolder);
        }

        private void DelFiles()
        {
            FileOperator.DelFiles(_oprFiles);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (listFiles.CheckedItems.Count == 0)
                return;
            var res = MessageBox.Show("确认删除所选文件?此操作不可逆!", "确定删除操作", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.OK)
            {
                GetSelectedPath(ref _oprFiles);
                ThreadDelFiles();
            }
        }

        private bool SelectAfolder(bool bForExort, string Description, ref string rootDir)
        {
            var path = "";
            var folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.Description = Description;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog.SelectedPath;
                if (FileOperator.NewFolderValid(path))
                {
                    rootDir = path;
                    return true;
                }
                var desMsg = "所选目录不能是已有目录的子目录或父目录,请重新选择";
                return SelectAfolder(bForExort, desMsg, ref rootDir);
            }
            return false;
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            _bLove = miLove.Checked;
            _bDel = miDel.Checked;
            _bPriv = miPriv.Checked;
            _bNote = miNote.Checked;
            _bNormal = miAll.Checked;
            _dtS = dtStart.Value;
            _dtE = dtEnd.Value;
            _keyWord = tbKeyword.Text;
            tsslFilter.Text = getFileterString(_bLove, _bDel, _bPriv, _bNote, _bNormal, _dtS, _dtE, _keyWord);
            UpdateFilesList();
        }

        private void miLove_CheckedChanged(object sender, EventArgs e)
        {
            PreviewSearchFilter();
        }

        private void miReloadFiles_Click(object sender, EventArgs e)
        {
            ThreadInitAllFiles();
        }

        private void timerOprFiles_Tick(object sender, EventArgs e)
        {
            UpdateCurOprStatus();
        }

        private void UpdateCurOprStatus()
        {
            if (_iCurOprType == CurOprType.None)
            {
                lbCurOpr.Visible = false;
                tssProcess.Visible = false;
            }
            else if (_iCurOprType == CurOprType.OprFinished)
            {
                timerOprFiles.Interval = 5000;
                _iCurOprType = CurOprType.None;
            }
            else //3kinds of file opr
            {
                lbCurOpr.Visible = true;
                tssProcess.Visible = true;
                tssProcess.Value = FileOperator.CurIndex;
                tssProcess.Maximum = FileOperator.TotalCount;
                if (!FileOperator.BOprFilesInprocess)
                {
                    var msgStr = "";
                    if (_iCurOprType == CurOprType.CopyFile)
                    {
                        msgStr = "导出完成 ";
                    }
                    else if (_iCurOprType == CurOprType.MoveFile)
                    {
                        msgStr = "移动完成 ";
                    }
                    else if (_iCurOprType == CurOprType.DelFile)
                    {
                        msgStr = "删除完成 ";
                    }
                    if (FileOperator.FaildCount != 0)
                        msgStr += string.Format("成功{0}失败{1}个", FileOperator.CurIndex, FileOperator.FaildCount);
                    lbCurOpr.Text = msgStr;
                    tssProcess.Visible = false;
                    _iCurOprType = CurOprType.OprFinished;
                    UpdateFilesList();
                }
            }
        }

        private void listFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listFiles.SelectedItems.Count > 0)
            {
                var filePath = listFiles.SelectedItems[0].SubItems[3].Text;
                PlayFile(filePath);
            }
        }

        private void FileMgrForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_trdFileInit != null)
            {
                _trdFileInit.Abort();
            }
            if (_trdFileOpr != null)
            {
                _trdFileOpr.Abort();
            }
        }

        private void FileMgrForm_Leave(object sender, EventArgs e)
        {
        }

        private void FileMgrForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            vlcCtrl.Release();
        }

        private enum CurOprType
        {
            None = 0,
            CopyFile,
            MoveFile,
            DelFile,
            OprFinished
        }

        private void vlcCtrl_Load(object sender, EventArgs e)
        {

        }
    }
}