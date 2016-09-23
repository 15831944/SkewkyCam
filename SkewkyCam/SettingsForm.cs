using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Com.Skewky.Cam
{
    public partial class SettingsForm : Form
    {
        private double[] dSpeed = new double[7] { 0.1, 0.5, 1, 2, 4, 8, 16 };
        private List<string> rootDirs = new List<string>();
        private ThemeColors tempColor = new ThemeColors();
        public SettingsForm()
        {
            InitializeComponent();
            timer1.Interval = 100;
            timer1.Start();
            cbRecType.SelectedIndex = 0;
            updateColors();
        }
        public void initValues(ConfigSettings cf)
        {
            rootDirs.Clear();
            rootDirs.AddRange(cf.rootDirArr);
            tbSpeed.Value = cf.iPlaySpeed;
            tbSound.Value = cf.iValume;
            ckAutoplay.Checked = cf.bAutoPalyNext;
            tempColor = cf.myColors;
            updateRootDirs();
            updateSound();
            updateSpeed();
            cbRecType.SelectedValue = 1;
        }
        public ConfigSettings getValues()
        {
            ConfigSettings cf = new ConfigSettings();
            cf.iPlaySpeed = tbSpeed.Value;
            cf.iValume = tbSound.Value;
            cf.bAutoPalyNext = ckAutoplay.Checked;
            cf.rootDirArr = rootDirs;
            cf.myColors = tempColor;
            return cf;
        }
        private void updateRootDirs()
        {
            listRootDirs.Items.Clear();
            foreach (string path in rootDirs)
            {
                listRootDirs.Items.Add(path);
            }
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void updateSpeed()
        {
            string spd = string.Format("{0}", dSpeed[tbSpeed.Value]);
            lbSpeed.Text = spd;

        }
        
        private void trackBarSpeed_Scroll(object sender, EventArgs e)
        {
            updateSpeed();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            updateSpeed();
        }
     private void lbSpeedMin_MouseClick(object sender, MouseEventArgs e)
        {
            tbSpeed.Value = 0;
            updateSpeed();
        }

        private void lbSpeed1_MouseClick(object sender, MouseEventArgs e)
        {
            tbSpeed.Value = 2;
            updateSpeed();
        
        }

        private void lbSpeedMax_MouseClick(object sender, MouseEventArgs e)
        {
            tbSpeed.Value = 6;
            updateSpeed();
        
        }
        private void updateSound()
        {
            string sud = string.Format("{0}", tbSound.Value);
            lbSound.Text = sud;

        }
        private void tbSound_ValueChanged(object sender, EventArgs e)
        {
            updateSound();
        }

        private void tbSound_Scroll(object sender, EventArgs e)
        {
            updateSound();
       
        }

        private void lbSoundMin_MouseClick(object sender, MouseEventArgs e)
        {
            tbSound.Value = 0;
            updateSound();
       
        }
        private void lbSound50_MouseClick(object sender, MouseEventArgs e)
        {
            tbSound.Value = 50;
            updateSound();
        
        }
        private void lbSound100_MouseClick(object sender, MouseEventArgs e)
        {
            tbSound.Value = 100;
            updateSound();
       
        }

        private void lbSoundMax_MouseClick(object sender, MouseEventArgs e)
        {
            tbSound.Value = 200;
            updateSound();
       
        }

        private void SettingsForm_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbDlg = new FolderBrowserDialog();
            if (fbDlg.ShowDialog() == DialogResult.OK)
            {
                if (!rootDirs.Contains(fbDlg.SelectedPath))
                {
                    rootDirs.Add(fbDlg.SelectedPath);
                    listRootDirs.Items.Add(fbDlg.SelectedPath);
                }
            }
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (listRootDirs.SelectedItems!=null)
            {
                foreach (ListViewItem lvi in listRootDirs.SelectedItems)
                {
                    listRootDirs.Items.Remove(lvi);
                }
                rootDirs.Clear();
                foreach (ListViewItem lvi in listRootDirs.Items)
                {
                    rootDirs.Add(lvi.Text);
                }

            }
        }
        private void updateColors()
        {
            btLove.BackColor = tempColor.clrFavorite;
            btToDel.BackColor = tempColor.clrToDelete;
            btPriv.BackColor = tempColor.clrPrivate;
            btNote.BackColor = tempColor.clrDescrib;
            btNormal.BackColor = tempColor.clrNormal;
            btBg.BackColor = tempColor.clrBg;
           // pbDemo.BackColor = tempColor.clrBg;

            btLove.ForeColor =  Color.FromArgb(255-btLove.BackColor.R,255-btLove.BackColor.R,255-btLove.BackColor.R);
            btToDel.ForeColor = Color.FromArgb(255 - btToDel.BackColor.R, 255 - btToDel.BackColor.R, 255 - btToDel.BackColor.R);
            btPriv.ForeColor = Color.FromArgb(255 - btPriv.BackColor.R, 255 - btPriv.BackColor.R, 255 - btPriv.BackColor.R);
            btNote.ForeColor = Color.FromArgb(255 - btNote.BackColor.R, 255 - btNote.BackColor.R, 255 - btNote.BackColor.R);
            btNormal.ForeColor = Color.FromArgb(255 - btNormal.BackColor.R, 255 - btNormal.BackColor.R, 255 - btNormal.BackColor.R);
            btBg.ForeColor = Color.FromArgb(255 - btBg.BackColor.R, 255 - btBg.BackColor.R, 255 - btBg.BackColor.R);

            Point drawPt = new Point(0,0); 
            Point drawPt1 = new Point();
            int drawWidth = 12;
            int markHeight = 5;
            Graphics g = pbDemo.CreateGraphics();

            drawPt.X = 24;
            drawPt.Y = 1;
            //Normal
            drawPt1 = drawPt;
            drawPt1.Y = 25;
            g.DrawLine(new Pen(tempColor.clrBg, 48), drawPt, drawPt1);
          

            drawPt.X = 18;
            drawPt.Y = 1;
            //Normal
            drawPt1 = drawPt;
            drawPt1.Y = 25;
            g.DrawLine(new Pen(tempColor.clrNormal, drawWidth), drawPt, drawPt1);
           

            //Favourite
            drawPt1 = drawPt;
            drawPt1.Y += markHeight;
             g.DrawLine(new Pen(tempColor.clrFavorite, drawWidth), drawPt, drawPt1);
            drawPt1.Y += 1;

            drawPt = drawPt1;
            drawPt1.Y += markHeight;
            g.DrawLine(new Pen(tempColor.clrToDelete, drawWidth), drawPt, drawPt1);
            drawPt1.Y += 1;

            //Private
            drawPt = drawPt1;
            drawPt1.Y += markHeight;
            g.DrawLine(new Pen(tempColor.clrPrivate, drawWidth), drawPt, drawPt1);
            drawPt1.Y += 1;

            //Description
            drawPt = drawPt1;
            drawPt1.Y += markHeight;
            g.DrawLine(new Pen(tempColor.clrDescrib, drawWidth), drawPt, drawPt1);

            drawPt.X = 30;
            drawPt.Y = 1;
            drawPt1.X = 30;
            drawPt1.Y = 25;

            g.DrawLine(new Pen(tempColor.clrNormal, drawWidth), drawPt, drawPt1);
            pbDemo.Update();
        }
        private void btLove_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = tempColor.clrFavorite;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                tempColor.clrFavorite = colorDialog1.Color;
            updateColors();
        }

       

        private void btToDel_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = tempColor.clrToDelete;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                tempColor.clrToDelete = colorDialog1.Color;
            updateColors();
        
        }

        private void btNormal_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = tempColor.clrNormal;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                tempColor.clrNormal = colorDialog1.Color;
            updateColors();
        
        }

        private void btPriv_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = tempColor.clrPrivate;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                tempColor.clrPrivate = colorDialog1.Color;
            updateColors();
        
        }

        private void btNote_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = tempColor.clrDescrib;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                tempColor.clrDescrib = colorDialog1.Color;
            updateColors();
        
        }

        private void btBg_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = tempColor.clrBg;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                tempColor.clrBg = colorDialog1.Color;
            updateColors();
        
        }

        private void pbDemo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tempColor = new ThemeColors();
            updateColors();
        
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            updateColors();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            updateColors();
        }

     
    }
}
