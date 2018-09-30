using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CommunityDemoDownloader.utils;
using System.Threading;
using System.Threading;
namespace CommunityDemoDownloader
{
    public partial class MainForm : Form
    {

        public string data_path;
        public const int _5E = 2;
        public const int B5 = 3;

        private Thread DownloadThread = null; 

        public static MainForm obj;

        public MainForm()
        {
            InitializeComponent();
            data_path = Application.StartupPath + "\\config.json";
            obj = this;
        }

        private void button_download_Click(object sender, EventArgs e)
        {
            if (DownloadThread == null || DownloadThread.ThreadState == ThreadState.Stopped)
            {
                DownloadThread = new Thread(startDownload);
                DownloadThread.Start(comboBox_communityname.SelectedItem.ToString());
            }
        }

        public void FinishDownload() {
            //todo
        }

        public bool SetThreadStopped() {
            DownloadThread.Abort();
            return DownloadThread.ThreadState == ThreadState.Stopped;
        }

        private void startDownload(object comm) {
            JConfig jc = new JConfig(data_path);
            switch (comm.ToString()) {
                case "B5":
                    CommunityB5 b5 = new CommunityB5(this, jc.get(B5.ToString()));
                    b5.Start();
                    break;

                case "5E":
                    Community5E c5e = new Community5E(this, jc.get(_5E.ToString()));
                    c5e.Start();
                    break;

            }
        }

        public void setProgress(int v) {
            progressBar1.Invoke(new Action(delegate() {
                progressBar1.Value = v;
            }));
        }

        public void setLabel(string str) {
            richTextBox1.Invoke(new Action(delegate ()
            {
                string all = str + "\n" + richTextBox1.Text;
                richTextBox1.Text = all;
                richTextBox1.Refresh();
            }));
            
        }

        private void button_setting_Click(object sender, EventArgs e)
        {
            if (comboBox_communityname.SelectedIndex == -1) {
                MessageBox.Show("请选择一个社区!");
                return;
            }
            int cm = 0;
            switch (comboBox_communityname.SelectedItem.ToString())
            {
                case "5E":
                    cm = _5E;
                    break;

                case "B5":
                    cm = B5;
                    break;
            }
            SettingForm sf = new SettingForm(this, cm);
            this.Visible = false;
            sf.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            comboBox_communityname.SelectedIndex = 0;
        }

        public static MainForm GetObject() {
            return MainForm.obj;
        }
    }
}
