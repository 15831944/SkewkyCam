using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using Com.Skewky.Vlc;
using ThreadState = System.Threading.ThreadState;

namespace Com.Skewky.Cam
{
    public partial class MainForm : Form
    {
 //       private readonly VlcPlayer _vlcPlayer;
 //       private VlcPlayer _vlcPlayerNext;
       private bool _bFindNext;
        private ConfigSettings _cfsettings;
        private DateTime _curDt;
        private FileParseBase _fileParseTool;
//        private bool _isFullScreen;
        private bool _isPlaying;
        public Thread TrdFileMgr;
        public Thread TrdFindNextFile;

        public MainForm()
        {
            _isPlaying = false;
           // _isFullScreen = false;
            _bFindNext = false;
            _cfsettings = new ConfigSettings();
            LoadConfig();

            InitFileParseTool();

            InitializeComponent();

            KeyPreview = true;

            //_vlcPlayer = NewVlcPlayer();
            //_vlcPlayerNext = NewVlcPlayer();
         
            ResetTimerInterval();
            pBmin.BackColor = _cfsettings.MyColors.ClrBg;
            pBhour.BackColor = _cfsettings.MyColors.ClrBg;
        }

/*
        private VlcPlayer NewVlcPlayer()
        {
            var pluginPath = Environment.CurrentDirectory + "\\plugins\\";
            var vlcPlayer = new VlcPlayer(pluginPath);
            var renderWnd = panelPlay.Handle;
            vlcPlayer.SetRenderWindow((int) renderWnd);
            return vlcPlayer;
        }*/

        private string ConfigFile()
        {
            return Environment.CurrentDirectory + "\\config.ske";
        }

        public void SaveConfig()
        {
            try
            {
                //_cfsettings.Valume = 50;
                //_cfsettings.RecType = 15;
                var filePath = ConfigFile();
                Stream s = File.Open(filePath, FileMode.Create, FileAccess.ReadWrite);
                var b = new BinaryFormatter();
                b.Serialize(s, _cfsettings);
                s.Close();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public void LoadConfig()
        {
            _cfsettings = new ConfigSettings();
            var filePath = ConfigFile();
            try
            {
                if (File.Exists(filePath))
                {
                    Stream s = File.Open(filePath, FileMode.Open, FileAccess.Read);
                    var c = new BinaryFormatter();
                    _cfsettings = (ConfigSettings) c.Deserialize(s);
                    _cfsettings.InitLoadFaildValues();
                    _cfsettings.MyColors = new ThemeColors();
                    s.Close();
                }
            }
            catch (Exception)
            {
                File.Delete(filePath);
            }
        }

        private void InitFileParseTool()
        {
            switch (_cfsettings.RecType)
            {
                case 0: //XiaoMi
                    _fileParseTool = new FileParseXiaoMi();
                    break;
                default:
                    _fileParseTool = new FileParseXiaoMi();
                    break;
            }
            _fileParseTool.SetRootDir(_cfsettings.RootDirArr);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _cfsettings.RootDirArr[0] = _fileParseTool.GetRootDirByPath(ofd.FileName);
                InitFileParseTool();
                PlayRecord(ofd.FileName);
                UpdateCalender(true);
            }
        }

        private void PlayRecord(string path, bool autoPlayNext = false)
        {
            _curDt = _fileParseTool.GetDtMinByPath(path);
            //autoPlayNext = false;
            if (_bFindNext && autoPlayNext)
            {
               // _vlcPlayer.Copy(_vlcPlayerNext);
               // _vlcPlayer.Pause();
                vlcCtrl.PlayFile(path);
                updatePlayStatus_Start();
                UpdateHourAndMinView();
                //UpdateSpeed();
                ThreadFindNextFile();
            }
            if (File.Exists(path))
            {
                //_vlcPlayer.PlayFile(path);
                vlcCtrl.PlayFile(path);
                updatePlayStatus_Start();
                UpdateHourAndMinView();
                //UpdateSpeed();
                ThreadFindNextFile();
            }
        }

        private void PlayRecord(DateTime dt, bool autoPlayNext = false)
        {
            var path = _fileParseTool.MinutePath(dt);
            PlayRecord(path, autoPlayNext);
        }

        private void PrepearNextFile()
        {
            _bFindNext = false;
            var nextDt = _curDt;
            if (_fileParseTool.FindNextDt(_curDt, ref nextDt))
            {
                var nextfilePath = _fileParseTool.MinutePath(nextDt);
                vlcCtrl.InitNextPlayFile(nextfilePath);
                _bFindNext = true;
            }
        }

        private void ThreadFindNextFile()
        {
            //_vlcPlayerNext = NewVlcPlayer();
            TrdFindNextFile = new Thread(PrepearNextFile);
            TrdFindNextFile.Start();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = _cfsettings.RootDirArr[0];
            folderBrowserDialog.ShowNewFolderButton = false;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (_cfsettings.RootDirArr[0] != folderBrowserDialog.SelectedPath)
                {
                    _cfsettings.RootDirArr[0] = folderBrowserDialog.SelectedPath;
                    InitFileParseTool();
                    UpdateCalender(true);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
 /*           if (_isPlaying)
            {
              //  var playTime = _vlcPlayer.GetPlayTime();
              //  var duraTime = _vlcPlayer.Duration();
                var bIsPlayEnded = _vlcPlayer.IsPlayEnded();
                if (bIsPlayEnded)
                {
                    updatePlayStatus_Stop();
                    var nextDt = _curDt;
                    if (_fileParseTool.FindNextDt(_curDt, ref nextDt))
                    {
                        PlayRecord(nextDt, true);
                    }
                    else
                    {
                        var msg = "没有找到下一个要播放文件";
                        toolTip1.Show(msg, pBmin, 15, 15, 3);
                    }
                }
/ *
                else
                {
                    var curVal = trackBar1.Value + (int) (1000*_cfsettings.GetDoubleSpeed());
                    curVal = Math.Max(trackBar1.Minimum, curVal);
                    curVal = Math.Min(trackBar1.Maximum, curVal);
                    var curPlayTime = _vlcPlayer.GetPlayTime()*1000;
                    curPlayTime = Math.Max(trackBar1.Minimum, curPlayTime);
                    curPlayTime = Math.Min(trackBar1.Maximum, curPlayTime);
                    trackBar1.Value = (int) curPlayTime;
                    tbVideoTime.Text = string.Format("{0}/{1}",
                        GetTimeString(trackBar1.Value/1000),
                        GetTimeString(trackBar1.Maximum/1000));
                }* /
            }*/
        }

/*
        private string GetTimeString(int val)
        {
            var hour = val/3600;
            val %= 3600;
            var minute = val/60;
            var second = val%60;
            return string.Format("{0:00}:{1:00}:{2:00}", hour, minute, second);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (_isPlaying)
            {
                _vlcPlayer.SetPlayTime(trackBar1.Value/1000.0);
                trackBar1.Value = (int) _vlcPlayer.GetPlayTime();
            }
        }*/

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            updateHourAndMinView_Force();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_vlcPlayer.Stop();
            vlcCtrl.Release();
            SaveConfig();
            SaveMarkData();
            _fileParseTool.SaveMarkFiles();
            if (TrdFindNextFile != null)
            {
                TrdFindNextFile.Abort();
            }
        }


/*
        private void ToggleFullScreen()
        {
            _isFullScreen = !_isFullScreen;
            _vlcPlayer.SetFullScreen(_isFullScreen);
        }

        private void TogglePlay()
        {
            if (_isPlaying)
            {
                _vlcPlayer.Pause();
                timer1.Stop();
                tssPause.Text = "已暂停";
                _isPlaying = false;
            }
            else
            {
                _vlcPlayer.Play();
                timer1.Start();
                tssPause.Text = "";
                _isPlaying = true;
            }
        }*/

        private void ShowFileMgrForm()
        {
            if (TrdFileMgr == null)
            {
                TrdFileMgr = new Thread(TrdShowFileMgrForm);
            }
            if (TrdFileMgr.ThreadState == ThreadState.Unstarted)
            {
                TrdFileMgr.SetApartmentState(ApartmentState.STA);
                TrdFileMgr.Start();
            }
            else if (TrdFileMgr.ThreadState == ThreadState.Stopped)
            {
                TrdFileMgr.Abort();
                TrdFileMgr = new Thread(TrdShowFileMgrForm);
                TrdFileMgr.SetApartmentState(ApartmentState.STA);
                TrdFileMgr.Start();
            }
        }

        private void TrdShowFileMgrForm()
        {
            _fileParseTool.SaveMarkFiles();
            var fmf = new FileMgrForm(_cfsettings);
            fmf.ShowDialog();
        }

        private void ShowSettingsForm()
        {
            var sf = new SettingsForm();
            sf.InitValues(_cfsettings);
            if (sf.ShowDialog() == DialogResult.OK)
            {
                var cf = sf.GetValues();
                if (_cfsettings.Valume != cf.Valume)
                {
                    _cfsettings.Valume = cf.Valume;
                    vlcCtrl.SetValume(_cfsettings.Valume);
                }
                if (_cfsettings.PlaySpeed != cf.PlaySpeed)
                {
                    _cfsettings.PlaySpeed = cf.PlaySpeed;
                    vlcCtrl.SetPlaySpeed(_cfsettings.PlaySpeed);
                }
                _cfsettings.BAutoPalyNext = cf.BAutoPalyNext;
                if (_cfsettings.RootDirArr != cf.RootDirArr)
                {
                    _cfsettings.RootDirArr.Clear();
                    _cfsettings.RootDirArr.AddRange(cf.RootDirArr);
                    SaveMarkData();
                    _fileParseTool.SaveMarkFiles();
                    InitFileParseTool();
                }
            }
        }

        private void ShowHelpForm()
        {
            Process.Start("http://www.skewky.com/forum.php?mod=viewthread&tid=2&extra=");
        }

        private void ShowAboutForm()
        {
            var ab = new AboutBox1();
            ab.ShowDialog();
        }

        private void ResetTimerInterval()
        {
            var dInv = 1/_cfsettings.GetDoubleSpeed();
            timer1.Interval = (int) (dInv*1000);
        }

        private void ThreadUpdateAllTimeView()
        {
            //Thread trd = new Thread(this.UpdateAllTimeView);
            //trd.Start();
            UpdateCalender();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            UpdateCalender();
        }

        private void pBmin_Click(object sender, EventArgs e)
        {
        }

        private void pBhour_Click(object sender, EventArgs e)
        {
        }

        private void pBmin_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pBhour_Paint(object sender, PaintEventArgs e)
        {
            /*pBhour.Refresh();*/
        }

        private void pBhour_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var height = pBhour.Height;
            var width = pBhour.Width;
            var drawWidth = width/24;
            var clkPt = new Point(e.Location.X, e.Location.Y);
            var clkHour = clkPt.X/drawWidth;
            clkHour = Math.Min(clkHour, 23);

            if (_curDt.Hour != clkHour)
            {
                _curDt = new DateTime(_curDt.Year, _curDt.Month, _curDt.Day,
                    clkHour, _curDt.Minute, _curDt.Second);
                UpdateHourAndMinView();
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
        }

        private void pBmin_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var height = pBmin.Height;
            var width = pBmin.Width;
            var drawWidth = width/60;
            var clkPt = new Point(e.Location.X, e.Location.Y);
            var clkMinute = clkPt.X/drawWidth;
            clkMinute = Math.Min(clkMinute, 59);
            if (_curDt.Minute != clkMinute)
            {
                if (_isPlaying)
                    updatePlayStatus_Stop();
                _curDt = new DateTime(_curDt.Year, _curDt.Month, _curDt.Day,
                    _curDt.Hour, clkMinute, _curDt.Second);
                UpdateMinute();
                PlayCurrentDt();
            }
        }

        private bool PlayCurrentDt()
        {
            if (_fileParseTool.MinuteBlod(_curDt))
            {
                PlayRecord(_curDt);
                return true;
            }
            return false;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                //Thread.Sleep(1);
                updateHourAndMinView_Force();
            }
            updateHourAndMinView_Force();
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            //Thread.Sleep(1000);
            UpdateHourAndMinView();
        }

        private void pBmin_MouseMove(object sender, MouseEventArgs e)
        {
            var height = pBmin.Height;
            var width = pBmin.Width;
            var drawWidth = width/60;
            var clkPt = new Point(e.Location.X, e.Location.Y);
            clkPt.Y += height;
            var clkMinute = clkPt.X/drawWidth;
            clkMinute = Math.Min(clkMinute, 59);
            var dispDt = new DateTime(_curDt.Year, _curDt.Month, _curDt.Day,
                _curDt.Hour, clkMinute, _curDt.Second);

            //if (_curDt.Minute != clkMinute)
            //{
            var msg = string.Format("{0}/{1:D2}/{2:D2} {3:D2}:{4:D2}",
                _curDt.Year, _curDt.Month, _curDt.Day,
                _curDt.Hour, clkMinute);
            //toolTip1.SetToolTip(this.pBmin, msg);
            //    toolTip1.Show(msg, pBmin, clkPt, 3);
            //}//
            var mk = new MarkData();
            if (_fileParseTool.GetMarkData(dispDt, ref mk) &&
                mk.Describ)
            {
                msg = "[" + msg + "] " + mk.Description;
                msg = msg.Replace("\n", " ");
                msg = msg.Replace("\r", " ");
                tssNote.Text = msg;
            }
            else
                tssNote.Text = "";
        }

        private void pBmin_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void ck_ContinuMark_MouseHover(object sender, EventArgs e)
        {
            var msg = "持续备注\n直到取消勾选\n或碰到下一个有备注的视频";
            var pt = ck_ContinuMark.Location;
            pt.X -= 220;
            pt.Y += 20;
            toolTip1.Show(msg, ck_ContinuMark, pt, 3000);
        }


        private void ck_ContinuMark_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void lbMinute_Click(object sender, EventArgs e)
        {
        }


        private void lbNowPlaying_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var path = _fileParseTool.MinutePath(_curDt);
            if (Directory.Exists(Path.GetDirectoryName(path)))
                Process.Start("explorer.exe", Path.GetDirectoryName(path));
        }

        private bool IsNowValid()
        {
            if (_fileParseTool.MinuteBlod(_curDt))
                return true;
            return false;
        }

        private void tbNote_TextChanged(object sender, EventArgs e)
        {
            if (!IsNowValid())
                return;
            picNote.Visible = !string.IsNullOrEmpty(tbNote.Text);
            SaveMarkData();
            UpdateMinute(true);
        }

        private void pBmin_MouseLeave(object sender, EventArgs e)
        {
            tssNote.Text = "";
        }

        /*#region PlayEnvMouseEnv

        private void pBplayEnv_MouseWheel(object sender, MouseEventArgs e)
        {
            updateVolume(e.Delta == 120);
        }

        private void pBplayEnv_MouseEnter(object sender, EventArgs e)
        {
            pBplayEnv.Focus();
        }

        private void pBplayEnv_MouseHover(object sender, EventArgs e)
        {
            pBplayEnv.Focus();
        }

        private void pBplayEnv_MouseClick(object sender, MouseEventArgs e)
        {
            var clk = e.Button;
            if (clk == MouseButtons.Left)
            {
                // TogglePlay();
            }
            if (clk == MouseButtons.Middle)
            {
                ToggleFullScreen();
            }
        }

        private void pBplayEnv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                TogglePlay();
        }

        private void pBplayEnv_Click(object sender, EventArgs e)
        {
        }

        #endregion*/

        #region Key Envents

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.Control && e.Shift)
            {
                //pressed all the control keys
                //Do some thing
            }
            else if (e.Alt && e.Control)
            {
            }
            else if (e.Alt && e.Shift)
            {
            }
            else if (e.Shift && e.Control)
            {
                KeyEnv_FileForm(sender, e);
                KeyEnv_SettingsForm(sender, e);
                KeyEnv_AboutForm(sender, e);
                KeyEnv_HelpForm(sender, e);
            }
            else if (e.Alt)
            {
                //KeyEnv_TogglePlay(sender, e);
            }
            else if (e.Control)
            {
               // KeyEnv_Speed(sender, e);
               // KeyEnv_Marks(sender, e);
            }
            else if (e.Shift)
            {
                if (e.KeyCode == Keys.S)
                {
                    var mff = new MergeFilesForm();
                    mff.PlayTestFile();
                    mff.ShowDialog();
                }
            }
            else //Normal key input
            {
                //KeyEnv_Process(sender, e);
               // KeyEnv_Sound(sender, e);
            }
        }

/*      Key envents for player
        private void KeyEnv_TogglePlay(object sender, KeyEventArgs e)
        {
            if (Keys.Space == e.KeyCode)
            {
                TogglePlay();
            }
        }

        private void KeyEnv_Speed(object sender, KeyEventArgs e)
        {
            if (Keys.Up == e.KeyCode ||
                Keys.Down == e.KeyCode)
            {
                var curSpd = _cfsettings.PlaySpeed;
                //加速
                if (Keys.Up == e.KeyCode)
                {
                    curSpd += 1;
                }
                //减速
                if (Keys.Down == e.KeyCode)
                {
                    curSpd -= 1;
                }
                _cfsettings.PlaySpeed = Math.Max(curSpd, 0);
                _cfsettings.PlaySpeed = Math.Min(curSpd, 6);
                UpdateSpeed();
            }
        }

        private void KeyEnv_Sound(object sender, KeyEventArgs e)
        {
            if (Keys.Up == e.KeyCode ||
                Keys.Down == e.KeyCode)
            {
                //加速
                updateVolume(Keys.Up == e.KeyCode);
            }
        }

        private void KeyEnv_Process(object sender, KeyEventArgs e)
        {
            if (Keys.Left == e.KeyCode ||
                Keys.Right == e.KeyCode)
            {
                var iSpeedStep = 5000; //5s per step
                var dureTime = (int) _vlcPlayer.Duration();
                //前进
                if (Keys.Left == e.KeyCode)
                {
                    iSpeedStep = -iSpeedStep;
                }
                //后退
                if (Keys.Right == e.KeyCode)
                {
                }
                var newPlayTime = trackBar1.Value + iSpeedStep;
                var dNewPlayTime = newPlayTime/1000.0;
                dNewPlayTime = Math.Max(0, dNewPlayTime);
                dNewPlayTime = Math.Min(dNewPlayTime, _vlcPlayer.Duration());
                _vlcPlayer.SetPlayTime(dNewPlayTime);
                _vlcPlayer.Play();
                //trackBar1.Value = (int)_vlcPlayer.GetPlayTime();
            }
        }*/

        private void KeyEnv_FileForm(object sender, KeyEventArgs e)
        {
            if (Keys.F == e.KeyCode)
            {
                ShowFileMgrForm();
            }
        }

        private void KeyEnv_SettingsForm(object sender, KeyEventArgs e)
        {
            if (Keys.S == e.KeyCode)
            {
                ShowSettingsForm();
            }
        }

        private void KeyEnv_AboutForm(object sender, KeyEventArgs e)
        {
            if (Keys.A == e.KeyCode)
            {
                ShowAboutForm();
            }
        }

        private void KeyEnv_HelpForm(object sender, KeyEventArgs e)
        {
            if (Keys.H == e.KeyCode)
            {
                ShowHelpForm();
            }
        }

        private void KeyEnv_Marks(object sender, KeyEventArgs e)
        {
            if (!IsNowValid())
                return;
            if (Keys.D1 == e.KeyCode ||
                Keys.NumPad1 == e.KeyCode)
            {
                picLove.Visible = !picLove.Visible;
            }
            else if (Keys.D2 == e.KeyCode ||
                     Keys.NumPad2 == e.KeyCode)
            {
                picBin.Visible = !picBin.Visible;
            }
            else if (Keys.D3 == e.KeyCode ||
                     Keys.NumPad3 == e.KeyCode)
            {
                picPriv.Visible = !picPriv.Visible;
            }
            SaveMarkData();
            UpdateMinute(true);
        }

        #endregion

        #region updateStatus

        private void updatePlayStatus_Start()
        {
/*
            _vlcPlayer.Play();
            _vlcPlayer.SetRate(_cfsettings.GetDoubleSpeed());
            _vlcPlayer.SetVolume(_cfsettings.Valume);

            var dDuration = _vlcPlayer.Duration();
            trackBar1.SetRange(0, (int) dDuration);
            trackBar1.Value = 0;*/
            timer1.Start();
            _isPlaying = true;
            var strNowPlaying = "当前播放：" + _fileParseTool.MinutePath(_curDt);
            lbNowPlaying.Text = strNowPlaying;
            tssPause.Text = "";

            UpdateMarkData();
        }

        private void updatePlayStatus_Stop()
        {
/*
            _vlcPlayer.Stop();
            trackBar1.Value = trackBar1.Maximum;*/
            timer1.Stop();
            _isPlaying = false;
            lbNowPlaying.Text = "";
            tssPause.Text = @"已停止";
            SaveMarkData();
        }

        private void UpdateMarkData()
        {
            var mk = new MarkData();

            if (_fileParseTool.GetMarkData(_curDt, ref mk))
            {
                tbNote.Text = mk.Description;
                picBin.Visible = mk.ToDelete;
                picLove.Visible = mk.Favourite;
                picPriv.Visible = mk.Private;
                picNote.Visible = mk.Describ;
            }
            else if (!ck_ContinuMark.Checked)
            {
                tbNote.Text = string.Empty;
                picBin.Visible = false;
                picLove.Visible = false;
                picPriv.Visible = false;
                picNote.Visible = false;
            }
        }

        private void SaveMarkData()
        {
            if (!IsNowValid())
                return;
            var mk = new MarkData();
            mk.Description = tbNote.Text;
            mk.ToDelete = picBin.Visible;
            mk.Favourite = picLove.Visible;
            mk.Private = picPriv.Visible;
            _fileParseTool.SetMarkData(_curDt, mk);
        }

        private void UpdateAllTimeView()
        {
            UpdateCalender();
        }

        private void UpdateAllTimeView_Force()
        {
            UpdateCalender(true);
        }

        private void UpdateCalender(bool bForceRefresh = false)
        {
            if (bForceRefresh)
                monthCalendar2.SetSelectionRange(_curDt, _curDt);
            var curDate = monthCalendar2.SelectionStart;
            monthCalendar2.SetSelectionRange(curDate, curDate);
            if (bForceRefresh ||
                curDate.Year != _curDt.Year ||
                curDate.Month != _curDt.Month)
            {
                RemarkCalendar(monthCalendar2);
            }
            _curDt = curDate;
            UpdateHourAndMinView(bForceRefresh);
        }

        private void RemarkCalendar(MonthCalendar mc)
        {
            mc.RemoveAllBoldedDates();

            var disRange = mc.GetDisplayRange(false);
            var dt = disRange.Start;
            if (_fileParseTool.DayBlod(dt))
                mc.AddBoldedDate(dt);
            while (dt != disRange.End)
            {
                dt = dt.AddDays(1);
                if (_fileParseTool.DayBlod(dt))
                    mc.AddBoldedDate(dt);
            }
            mc.UpdateBoldedDates();
        }

        private void UpdateHours(bool bForceUpdate = false)
        {
            var height = pBhour.Height;
            var width = pBhour.Width;
            var drawWidth = width/24;
            var drawPt = new Point(0, 0);
            drawPt.X += drawWidth/2;
            var drawPt1 = drawPt;
            drawPt1.Y += height;
            var g = pBhour.CreateGraphics();
            for (var i = 0; i < 24; i++)
            {
                var nowdt = new DateTime(_curDt.Year, _curDt.Month, _curDt.Day, i, 0, 0);
                var bNowBlod = _fileParseTool.HourBlod(nowdt);
                var cl = bNowBlod ? _cfsettings.MyColors.ClrNormal : _cfsettings.MyColors.ClrBg;
                g.DrawLine(new Pen(cl, drawWidth), drawPt, drawPt1);
                g.DrawString(string.Format("{0}", i), DefaultFont, new SolidBrush(Color.Black), drawPt);
                if (i == _curDt.Hour)
                {
                    g.DrawRectangle(new Pen(Color.Black, 1), drawPt.X - drawWidth/2 + 1, drawPt.Y + 1, drawWidth - 2,
                        height - 2);
                }
                drawPt.X += drawWidth;
                drawPt1.X += drawWidth;
            }
            pBhour.Update();
        }

        private void UpdateMinute(bool bForceUpdate = false)
        {
            var height = pBmin.Height;
            var width = pBmin.Width;
            var drawWidth = width/60;
            var drawPt = new Point(0, 0);
            drawPt.X += drawWidth/2;
            var drawPt1 = drawPt;
            drawPt1.Y += height;
            var g = pBmin.CreateGraphics();
            for (var i = 0; i < 60; i++)
            {
                var nowdt = new DateTime(_curDt.Year, _curDt.Month, _curDt.Day, _curDt.Hour, i, 0);
                //BackGround
                var bNowBlod = _fileParseTool.MinuteBlod(nowdt);
                var clr = bNowBlod ? _cfsettings.MyColors.ClrNormal : _cfsettings.MyColors.ClrBg;
                g.DrawLine(new Pen(clr, drawWidth), drawPt, drawPt1);
                if (bNowBlod)
                    updateMinute_Marks(g, nowdt, drawWidth, drawPt, height);
                if (i == 0 || i == 30 || i == 59) //Draw key minutes
                {
                    var tmpDrawPt = drawPt;
                    tmpDrawPt.X -= drawWidth/2;
                    g.DrawString(string.Format("{0}", i), DefaultFont, new SolidBrush(Color.Black), tmpDrawPt);
                }
                if (i == _curDt.Minute) //DrawCurTime and Rect
                {
                    var tmpDrawPt = drawPt;
                    tmpDrawPt.X -= drawWidth/2;
                    g.DrawString(string.Format("{0}", i), DefaultFont, new SolidBrush(Color.Black), tmpDrawPt);

                    g.DrawRectangle(new Pen(Color.Black, 1), drawPt.X - drawWidth/2 + 1, drawPt.Y + 1, drawWidth - 2,
                        height - 2);
                }
                drawPt.X += drawWidth;
                drawPt1.X += drawWidth;
            }
            pBmin.Update();
            //updatePicBounds();
        }

        private void updateMinute_Marks(Graphics g, DateTime nowdt, int drawWidth, Point drawPt, int height)
        {
            var drawPt1 = drawPt;
            drawPt1.Y += height;
            var markHeight = height/5;

            var mk = new MarkData();
            var clr = _cfsettings.MyColors.ClrNormal;
            _fileParseTool.GetMarkData(nowdt, ref mk);


            //Favourite
            drawPt1 = drawPt;
            drawPt1.Y += markHeight;
            clr = mk.Favourite ? _cfsettings.MyColors.ClrFavorite : _cfsettings.MyColors.ClrNormal;
            g.DrawLine(new Pen(clr, drawWidth), drawPt, drawPt1);
            drawPt1.Y += 1;

            //ToDelete
            drawPt = drawPt1;
            drawPt1.Y += markHeight;
            clr = mk.ToDelete ? _cfsettings.MyColors.ClrToDelete : _cfsettings.MyColors.ClrNormal;
            g.DrawLine(new Pen(clr, drawWidth), drawPt, drawPt1);
            drawPt1.Y += 1;

            //Private
            drawPt = drawPt1;
            drawPt1.Y += markHeight;
            clr = mk.Private ? _cfsettings.MyColors.ClrPrivate : _cfsettings.MyColors.ClrNormal;
            g.DrawLine(new Pen(clr, drawWidth), drawPt, drawPt1);
            drawPt1.Y += 1;

            //Description
            drawPt = drawPt1;
            drawPt1.Y += markHeight;
            clr = mk.Describ ? _cfsettings.MyColors.ClrDescrib : _cfsettings.MyColors.ClrNormal;
            g.DrawLine(new Pen(clr, drawWidth), drawPt, drawPt1);
        }

        private void UpdateHourAndMinView(bool bForceRefresh = false)
        {
            // Thread.Sleep(10);
            UpdateHours(bForceRefresh);
            UpdateMinute(bForceRefresh);
        }

        private void updateHourAndMinView_Force()
        {
            UpdateHourAndMinView(true);
        }

/*
        private void updateVolume(bool bLouder)
        {
            //设置声音
            _cfsettings.Valume = _vlcPlayer.GetVolume();

            if (bLouder)
                _cfsettings.Valume += 5;
            else
                _cfsettings.Valume -= 5;

            if (_cfsettings.Valume < 0)
                _cfsettings.Valume = 0;
            updateVolume();
        }

        private void updateVolume()
        {
            _vlcPlayer.SetVolume(_cfsettings.Valume);
            txSound.Text = string.Format("{0}", _cfsettings.Valume);
            if (_cfsettings.Valume > 100)
                txSound.ForeColor = Color.Red;
            else
                txSound.ForeColor = Color.Black;
        }*/

/*
        private void UpdateSpeed()
        {
            var dRate = _cfsettings.GetDoubleSpeed();
            _vlcPlayer.SetRate(dRate);
            if (_cfsettings.PlaySpeed == 2)
            {
                txSpeed.Visible = false;
                tssPlaySpeed.Text = "";
            }
            else
            {
                txSpeed.Visible = true;
                txSpeed.Text = string.Format("播放速度：{0:N1}x", dRate);
                tssPlaySpeed.Text = string.Format("播放速度：{0:N1}x", dRate);
            }
            ResetTimerInterval();
        }*/

        #endregion

        #region MenuClickEnv

        private void FileMgr_MenuItem_Click(object sender, EventArgs e)
        {
            ShowFileMgrForm();
        }

        private void About_MenuItem1_Click(object sender, EventArgs e)
        {
            ShowAboutForm();
        }

        private void ReadMe_MenuItem_Click(object sender, EventArgs e)
        {
            ShowHelpForm();
        }

        private void Settings_MenuItem_Click(object sender, EventArgs e)
        {
            ShowSettingsForm();
        }

        #endregion

        #region PicButtoms

        private void picPrivGray_MouseClick(object sender, MouseEventArgs e)
        {
            if (!IsNowValid())
                return;
            picPriv.Visible = true;
            SaveMarkData();
            UpdateMinute(true);
        }

        private void picBinGray_MouseClick(object sender, MouseEventArgs e)
        {
            if (!IsNowValid())
                return;
            picBin.Visible = true;
            SaveMarkData();
            UpdateMinute(true);
        }

        private void picLoveGray_MouseClick(object sender, MouseEventArgs e)
        {
            if (!IsNowValid())
                return;
            picLove.Visible = true;
            SaveMarkData();
            UpdateMinute(true);
        }

        private void picLove_MouseClick(object sender, MouseEventArgs e)
        {
            if (!IsNowValid())
                return;
            picLove.Visible = false;
            SaveMarkData();
            UpdateMinute(true);
        }

        private void picBin_MouseClick(object sender, MouseEventArgs e)
        {
            if (!IsNowValid())
                return;
            picBin.Visible = false;
            SaveMarkData();
            UpdateMinute(true);
        }

        private void picPriv_MouseClick(object sender, MouseEventArgs e)
        {
            if (!IsNowValid())
                return;
            picPriv.Visible = false;
            SaveMarkData();
            UpdateMinute(true);
        }

        private void picNote_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void picNoteGray_Click(object sender, EventArgs e)
        {
        }

        private void picMarks_Paint(object sender, PaintEventArgs e)
        {
            //updatePicBounds();
        }

        private void updatePicBounds()
        {
            if (picLove.Visible)
            {
                var g = picLove.CreateGraphics();
                g.DrawRectangle(new Pen(_cfsettings.MyColors.ClrFavorite, 4), 0, 0, picLove.Width - 1,
                    picLove.Height - 1);
                picLove.Update();
            }
            if (picBin.Visible)
            {
                var g = picBin.CreateGraphics();
                g.DrawRectangle(new Pen(_cfsettings.MyColors.ClrToDelete, 4), 0, 0, picBin.Width - 1, picBin.Height - 1);
                picBin.Update();
            }
            if (picPriv.Visible)
            {
                var g = picPriv.CreateGraphics();
                g.DrawRectangle(new Pen(_cfsettings.MyColors.ClrPrivate, 4), 0, 0, picPriv.Width - 1, picPriv.Height - 1);
                picPriv.Update();
            }
            if (picNote.Visible)
            {
                var g = picNote.CreateGraphics();
                g.DrawRectangle(new Pen(_cfsettings.MyColors.ClrDescrib, 4), 0, 0, picNote.Width - 1, picNote.Height - 1);
                picNote.Update();
            }
        }

        #endregion
    }
}