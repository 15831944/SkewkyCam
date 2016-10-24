using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Com.Skewky.Cam
{
    public partial class SettingsForm : Form
    {
        private readonly double[] _dSpeed = new double[7] {0.1, 0.5, 1, 2, 4, 8, 16};
        private readonly List<string> _rootDirs = new List<string>();
        private ThemeColors _tempColor = new ThemeColors();

        public SettingsForm()
        {
            InitializeComponent();
            timer1.Interval = 100;
            timer1.Start();
            cbRecType.SelectedIndex = 0;
            UpdateColors();
        }

        public void InitValues(ConfigSettings cf)
        {
            _rootDirs.Clear();
            _rootDirs.AddRange(cf.RootDirArr);
            tbSpeed.Value = cf.PlaySpeed;
            tbSound.Value = cf.Valume;
            ckAutoplay.Checked = cf.BAutoPalyNext;
            _tempColor = cf.MyColors;
            UpdateRootDirs();
            UpdateSound();
            UpdateSpeed();
            cbRecType.SelectedValue = 1;
        }

        public ConfigSettings GetValues()
        {
            var cf = new ConfigSettings();
            cf.PlaySpeed = tbSpeed.Value;
            cf.Valume = tbSound.Value;
            cf.BAutoPalyNext = ckAutoplay.Checked;
            cf.RootDirArr = _rootDirs;
            cf.MyColors = _tempColor;
            return cf;
        }

        private void UpdateRootDirs()
        {
            listRootDirs.Items.Clear();
            foreach (var path in _rootDirs)
            {
                listRootDirs.Items.Add(path);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateSpeed()
        {
            var spd = string.Format("{0}", _dSpeed[tbSpeed.Value]);
            lbSpeed.Text = spd;
        }

        private void trackBarSpeed_Scroll(object sender, EventArgs e)
        {
            UpdateSpeed();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpeed();
        }

        private void lbSpeedMin_MouseClick(object sender, MouseEventArgs e)
        {
            tbSpeed.Value = 0;
            UpdateSpeed();
        }

        private void lbSpeed1_MouseClick(object sender, MouseEventArgs e)
        {
            tbSpeed.Value = 2;
            UpdateSpeed();
        }

        private void lbSpeedMax_MouseClick(object sender, MouseEventArgs e)
        {
            tbSpeed.Value = 6;
            UpdateSpeed();
        }

        private void UpdateSound()
        {
            var sud = string.Format("{0}", tbSound.Value);
            lbSound.Text = sud;
        }

        private void tbSound_ValueChanged(object sender, EventArgs e)
        {
            UpdateSound();
        }

        private void tbSound_Scroll(object sender, EventArgs e)
        {
            UpdateSound();
        }

        private void lbSoundMin_MouseClick(object sender, MouseEventArgs e)
        {
            tbSound.Value = 0;
            UpdateSound();
        }

        private void lbSound50_MouseClick(object sender, MouseEventArgs e)
        {
            tbSound.Value = 50;
            UpdateSound();
        }

        private void lbSound100_MouseClick(object sender, MouseEventArgs e)
        {
            tbSound.Value = 100;
            UpdateSound();
        }

        private void lbSoundMax_MouseClick(object sender, MouseEventArgs e)
        {
            tbSound.Value = 200;
            UpdateSound();
        }

        private void SettingsForm_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            var fbDlg = new FolderBrowserDialog();
            if (fbDlg.ShowDialog() == DialogResult.OK)
            {
                if (!_rootDirs.Contains(fbDlg.SelectedPath))
                {
                    _rootDirs.Add(fbDlg.SelectedPath);
                    listRootDirs.Items.Add(fbDlg.SelectedPath);
                }
            }
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (listRootDirs.SelectedItems != null)
            {
                foreach (ListViewItem lvi in listRootDirs.SelectedItems)
                {
                    listRootDirs.Items.Remove(lvi);
                }
                _rootDirs.Clear();
                foreach (ListViewItem lvi in listRootDirs.Items)
                {
                    _rootDirs.Add(lvi.Text);
                }
            }
        }

        private void UpdateColors()
        {
            btLove.BackColor = _tempColor.ClrFavorite;
            btToDel.BackColor = _tempColor.ClrToDelete;
            btPriv.BackColor = _tempColor.ClrPrivate;
            btNote.BackColor = _tempColor.ClrDescrib;
            btNormal.BackColor = _tempColor.ClrNormal;
            btBg.BackColor = _tempColor.ClrBg;
            // pbDemo.BackColor = _tempColor.ClrBg;

            btLove.ForeColor = Color.FromArgb(255 - btLove.BackColor.R, 255 - btLove.BackColor.R,
                255 - btLove.BackColor.R);
            btToDel.ForeColor = Color.FromArgb(255 - btToDel.BackColor.R, 255 - btToDel.BackColor.R,
                255 - btToDel.BackColor.R);
            btPriv.ForeColor = Color.FromArgb(255 - btPriv.BackColor.R, 255 - btPriv.BackColor.R,
                255 - btPriv.BackColor.R);
            btNote.ForeColor = Color.FromArgb(255 - btNote.BackColor.R, 255 - btNote.BackColor.R,
                255 - btNote.BackColor.R);
            btNormal.ForeColor = Color.FromArgb(255 - btNormal.BackColor.R, 255 - btNormal.BackColor.R,
                255 - btNormal.BackColor.R);
            btBg.ForeColor = Color.FromArgb(255 - btBg.BackColor.R, 255 - btBg.BackColor.R, 255 - btBg.BackColor.R);

            var drawPt = new Point(0, 0);
            Point drawPt1;
            var drawWidth = 12;
            var markHeight = 5;
            var g = pbDemo.CreateGraphics();

            drawPt.X = 24;
            drawPt.Y = 1;
            //Normal
            drawPt1 = drawPt;
            drawPt1.Y = 25;
            g.DrawLine(new Pen(_tempColor.ClrBg, 48), drawPt, drawPt1);


            drawPt.X = 18;
            drawPt.Y = 1;
            //Normal
            drawPt1 = drawPt;
            drawPt1.Y = 25;
            g.DrawLine(new Pen(_tempColor.ClrNormal, drawWidth), drawPt, drawPt1);


            //Favourite
            drawPt1 = drawPt;
            drawPt1.Y += markHeight;
            g.DrawLine(new Pen(_tempColor.ClrFavorite, drawWidth), drawPt, drawPt1);
            drawPt1.Y += 1;

            drawPt = drawPt1;
            drawPt1.Y += markHeight;
            g.DrawLine(new Pen(_tempColor.ClrToDelete, drawWidth), drawPt, drawPt1);
            drawPt1.Y += 1;

            //Private
            drawPt = drawPt1;
            drawPt1.Y += markHeight;
            g.DrawLine(new Pen(_tempColor.ClrPrivate, drawWidth), drawPt, drawPt1);
            drawPt1.Y += 1;

            //Description
            drawPt = drawPt1;
            drawPt1.Y += markHeight;
            g.DrawLine(new Pen(_tempColor.ClrDescrib, drawWidth), drawPt, drawPt1);

            drawPt.X = 30;
            drawPt.Y = 1;
            drawPt1.X = 30;
            drawPt1.Y = 25;

            g.DrawLine(new Pen(_tempColor.ClrNormal, drawWidth), drawPt, drawPt1);
            pbDemo.Update();
        }

        private void btLove_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = _tempColor.ClrFavorite;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                _tempColor.ClrFavorite = colorDialog1.Color;
            UpdateColors();
        }


        private void btToDel_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = _tempColor.ClrToDelete;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                _tempColor.ClrToDelete = colorDialog1.Color;
            UpdateColors();
        }

        private void btNormal_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = _tempColor.ClrNormal;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                _tempColor.ClrNormal = colorDialog1.Color;
            UpdateColors();
        }

        private void btPriv_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = _tempColor.ClrPrivate;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                _tempColor.ClrPrivate = colorDialog1.Color;
            UpdateColors();
        }

        private void btNote_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = _tempColor.ClrDescrib;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                _tempColor.ClrDescrib = colorDialog1.Color;
            UpdateColors();
        }

        private void btBg_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = _tempColor.ClrBg;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                _tempColor.ClrBg = colorDialog1.Color;
            UpdateColors();
        }

        private void pbDemo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _tempColor = new ThemeColors();
            UpdateColors();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            UpdateColors();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            UpdateColors();
        }
    }
}