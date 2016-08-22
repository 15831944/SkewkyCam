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
        public SettingsForm()
        {
            InitializeComponent();

        }
        public void initValues(ConfigSettings cf)
        {
            rootDirs.Clear();
            rootDirs.AddRange(cf.rootDirArr);
            tbSpeed.Value = cf.iPlaySpeed;
            tbSound.Value = cf.iValume;
            ckAutoplay.Checked = cf.bAutoPalyNext;
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

     
    }
}
