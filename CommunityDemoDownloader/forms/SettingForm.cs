using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommunityDemoDownloader.utils;

namespace CommunityDemoDownloader
{
    public partial class SettingForm : Form
    {
        private MainForm mainForm;
        private int Community;

        public SettingForm(MainForm mf,int community)
        {
            mainForm = mf;
            Community = community;
            InitializeComponent();
        }

        private void button_done_Click(object sender, EventArgs e)
        {
            if (textBox_dir.Text == "" || textBox_url.Text == "") {
                MessageBox.Show("请正确填写参数!");
                return;
            }
            Config conf = new Config();
            conf.olny = checkBox_olny.Checked;
            conf.url = textBox_url.Text;
            conf.powerboot = checkBox_powerboot.Checked;
            conf.path = textBox_dir.Text;
            conf.autodownload = checkBox_autodownload.Checked;
            JConfig jc = new JConfig(mainForm.data_path);
            jc.set(Community.ToString(),conf);
            MessageBox.Show("保存成功!");
            this.Close();
        }

        private void SettingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Visible = true;
        }

        private void checkBox_olny_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_all.Checked = !checkBox_olny.Checked;
        }

        private void checkBox_all_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_olny.Checked = !checkBox_all.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path;
            do
            {
                folderBrowserDialog1.ShowDialog();
                path = folderBrowserDialog1.SelectedPath;
            } while (path == null);
            textBox_dir.Text = path;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            InitConfig();
        }

        private void InitConfig() {
            JConfig jc = new JConfig(mainForm.data_path);
            Config cf = jc.get(Community.ToString());
            if (cf != null) {
                textBox_url.Text = cf.url;
                textBox_dir.Text = cf.path;
                checkBox_olny.Checked = cf.olny;
                checkBox_all.Checked = !cf.olny;
                checkBox_powerboot.Checked = cf.powerboot;
                checkBox_autodownload.Checked = cf.autodownload;
            }
        }
    }
}
