using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;
namespace CommunityDemoDownloader.utils
{
    class Community5E
    {
        public MainForm mainForm;
        private string user_url;
        private Config config;
        public Community5E(MainForm mf,Config cf)
        {
            mainForm = mf;
            config = cf;
            if (cf.url == "" || cf.path == "")
            {
                mainForm.setLabel("请先设置社区个人战绩链接!");
                while (mainForm.SetThreadStopped()) { Thread.Sleep(200); };
            }
            user_url = getDataUrl(getName(config.url));
        }

        public string getName(string str)
        {
            string[] a = str.Split('/');
            return a[a.Length - 1];
        }

        public string getDataUrl(string name) {
            return "https://www.5ewin.com/api/data/match_list/" + name+"?";
        }

        public List<string> getDemoUrls() {
            List<string> DemoUrls = new List<string>();
            int page = 1;
            bool end = false;
            while(!end){
                try {
                    HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(user_url + "page=" + page);
                    StreamReader sr = new StreamReader(hwr.GetResponse().GetResponseStream());
                    string data = sr.ReadToEnd();
                    Root root = JsonConvert.DeserializeObject<Root>(data);
                    sr.Close();
                    foreach (Data d in root.data)
                    {
                        if (d.demo_url == "")
                        {
                            end = true;
                            break;
                        }
                        DemoUrls.Add(d.demo_url);
                    }
                    page++;

                }
                catch (WebException e) {
                    mainForm.setLabel("获取数据出错=>"+e.Message);
                    while (mainForm.SetThreadStopped()) { Thread.Sleep(200); };
                }
            }
            return DemoUrls;
        }

        public void DownloadDemos(List<string> demos) {
            demos.ForEach(url =>
            {
                DownloadDemo(url);
            });
            mainForm.setProgress(0);
            mainForm.setLabel("下载完成!");
            mainForm.FinishDownload();
            while (!mainForm.SetThreadStopped()) { Thread.Sleep(200); };
        }

        public void DownloadDemo(object u) {
            string url = u.ToString();
            string filename = getName(url);
            if(!File.Exists(config.path +"\\"+filename.Replace("zip","dem"))) new Downloader(mainForm, url, config.path + "\\" + filename);
        }

        public void Start() {
            DownloadDemos(getDemoUrls());
        }
    }

    public class Data
    {
        /// <summary>
        /// Season
        /// </summary>
        public int season { get; set; }
        /// <summary>
        /// 20180928010657258260
        /// </summary>
        public string match_code { get; set; }
        /// <summary>
        /// 1
        /// </summary>
        public string match_type { get; set; }
        /// <summary>
        /// 2018-09-28 01:07:01
        /// </summary>
        public DateTime start_time { get; set; }
        /// <summary>
        /// 01:57:33
        /// </summary>
        public string end_time { get; set; }
        /// <summary>
        /// 51 分钟
        /// </summary>
        public string round_time { get; set; }
        /// <summary>
        /// de_inferno
        /// </summary>
        public string map { get; set; }
        /// <summary>
        /// 15
        /// </summary>
        public string score1 { get; set; }
        /// <summary>
        /// 15
        /// </summary>
        public string score2 { get; set; }
        /// <summary>
        /// 21
        /// </summary>
        public string kill { get; set; }
        /// <summary>
        /// 0
        /// </summary>
        public string is_mvp { get; set; }
        /// <summary>
        /// 0
        /// </summary>
        public string is_most_1v2 { get; set; }
        /// <summary>
        /// 0
        /// </summary>
        public string is_most_headshot { get; set; }
        /// <summary>
        /// 0
        /// </summary>
        public string is_most_first_kill { get; set; }
        /// <summary>
        /// 0
        /// </summary>
        public string is_most_end { get; set; }
        /// <summary>
        /// 0
        /// </summary>
        public string is_most_awp { get; set; }
        /// <summary>
        /// 0
        /// </summary>
        public string is_most_jump { get; set; }
        /// <summary>
        /// 0
        /// </summary>
        public string is_win { get; set; }
        /// <summary>
        /// 10.55
        /// </summary>
        public string rws { get; set; }
        /// <summary>
        /// 0.97
        /// </summary>
        public string rating { get; set; }
        /// <summary>
        /// http://d3.demo.5ewin.com/pug/20180928/20180928010657258260_de_inferno.zip
        /// </summary>
        public string demo_url { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// Success
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// Errcode
        /// </summary>
        public int errcode { get; set; }
        /// <summary>
        /// Message
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// Data
        /// </summary>
        public List<Data> data { get; set; }
    }

}
