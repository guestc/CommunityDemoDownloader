namespace CommunityDemoDownloader
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_dir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_done = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBox_autodownload = new System.Windows.Forms.CheckBox();
            this.checkBox_powerboot = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox_olny = new System.Windows.Forms.CheckBox();
            this.checkBox_all = new System.Windows.Forms.CheckBox();
            this.textBox_url = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox_dir);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button_done);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.textBox_url);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(11, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(533, 241);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(427, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_dir
            // 
            this.textBox_dir.Location = new System.Drawing.Point(140, 185);
            this.textBox_dir.Name = "textBox_dir";
            this.textBox_dir.Size = new System.Drawing.Size(272, 21);
            this.textBox_dir.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "下载路径: ";
            // 
            // button_done
            // 
            this.button_done.Location = new System.Drawing.Point(215, 215);
            this.button_done.Name = "button_done";
            this.button_done.Size = new System.Drawing.Size(75, 23);
            this.button_done.TabIndex = 6;
            this.button_done.Text = "完成";
            this.button_done.UseVisualStyleBackColor = true;
            this.button_done.Click += new System.EventHandler(this.button_done_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.checkBox_autodownload);
            this.panel3.Controls.Add(this.checkBox_powerboot);
            this.panel3.Location = new System.Drawing.Point(71, 121);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(388, 49);
            this.panel3.TabIndex = 5;
            // 
            // checkBox_autodownload
            // 
            this.checkBox_autodownload.AutoSize = true;
            this.checkBox_autodownload.Location = new System.Drawing.Point(193, 19);
            this.checkBox_autodownload.Name = "checkBox_autodownload";
            this.checkBox_autodownload.Size = new System.Drawing.Size(72, 16);
            this.checkBox_autodownload.TabIndex = 1;
            this.checkBox_autodownload.Text = "自动下载";
            this.checkBox_autodownload.UseVisualStyleBackColor = true;
            // 
            // checkBox_powerboot
            // 
            this.checkBox_powerboot.AutoSize = true;
            this.checkBox_powerboot.Location = new System.Drawing.Point(30, 20);
            this.checkBox_powerboot.Name = "checkBox_powerboot";
            this.checkBox_powerboot.Size = new System.Drawing.Size(72, 16);
            this.checkBox_powerboot.TabIndex = 0;
            this.checkBox_powerboot.Text = "开机自启";
            this.checkBox_powerboot.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBox_olny);
            this.panel2.Controls.Add(this.checkBox_all);
            this.panel2.Location = new System.Drawing.Point(71, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(388, 45);
            this.panel2.TabIndex = 4;
            // 
            // checkBox_olny
            // 
            this.checkBox_olny.AutoSize = true;
            this.checkBox_olny.Checked = true;
            this.checkBox_olny.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_olny.Location = new System.Drawing.Point(30, 14);
            this.checkBox_olny.Name = "checkBox_olny";
            this.checkBox_olny.Size = new System.Drawing.Size(108, 16);
            this.checkBox_olny.TabIndex = 2;
            this.checkBox_olny.Text = "仅下载个人DEMO";
            this.checkBox_olny.UseVisualStyleBackColor = true;
            this.checkBox_olny.CheckedChanged += new System.EventHandler(this.checkBox_olny_CheckedChanged);
            // 
            // checkBox_all
            // 
            this.checkBox_all.AutoSize = true;
            this.checkBox_all.Location = new System.Drawing.Point(193, 14);
            this.checkBox_all.Name = "checkBox_all";
            this.checkBox_all.Size = new System.Drawing.Size(180, 16);
            this.checkBox_all.TabIndex = 3;
            this.checkBox_all.Text = "爬取战绩中所有人的有效demo";
            this.checkBox_all.UseVisualStyleBackColor = true;
            this.checkBox_all.CheckedChanged += new System.EventHandler(this.checkBox_all_CheckedChanged);
            // 
            // textBox_url
            // 
            this.textBox_url.Location = new System.Drawing.Point(160, 30);
            this.textBox_url.Name = "textBox_url";
            this.textBox_url.Size = new System.Drawing.Size(299, 21);
            this.textBox_url.TabIndex = 1;
            this.textBox_url.Text = "https://www.5ewin.com/data/player/guestc";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "个人战绩页面";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 272);
            this.Controls.Add(this.panel1);
            this.Name = "SettingForm";
            this.Text = "SettingForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingForm_FormClosed);
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_done;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox checkBox_autodownload;
        private System.Windows.Forms.CheckBox checkBox_powerboot;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox_olny;
        private System.Windows.Forms.CheckBox checkBox_all;
        private System.Windows.Forms.TextBox textBox_url;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_dir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}