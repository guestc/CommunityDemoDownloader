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
    class CommunityB5
    {
        public MainForm mainForm;
        private string steamid;
        private Config config;
        public CommunityB5(MainForm mf, Config cf)
        {
            mainForm = mf;
            config = cf;
            if (cf.url == "" || cf.path == "") {
                mainForm.setLabel("请先设置社区个人战绩链接!");
                while (mainForm.SetThreadStopped()) { Thread.Sleep(200); };
            }
            steamid = getName(config.url);
        }

        public void Start() {
            getDemoUrls().ForEach(url =>
            {
                DownloadDemo(url);
            });
            mainForm.setProgress(0);
            mainForm.setLabel("下载完成!");
            while (!mainForm.SetThreadStopped()) { Thread.Sleep(200); };

        }

        private void DownloadDemo(string url) {
            new Downloader(mainForm, url, config.path+"\\"+getName(url));
        }

        public string getName(string str)
        {
            string[] a = str.Split('/');
            return a[a.Length - 1];
        }

        public string getDataUrl(int page)
        {
            return "https://www.b5csgo.com.cn/personalCenterV2Controller/match.do?pageNum=" + page.ToString() + "&pageSize=20&steamId=" + steamid + "&matchClass=-1&favourites=-1&gameTime=&competitionName=&mapId=-1";
        }

        public List<string> getDemoUrls() {
            List<string> urls = new List<string>();
            try
            {
                for (int x = 1; ; x++)
                {
                    string jsondata;
                    HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(getDataUrl(x));
                    hwr.Method = "POST";
                    hwr.Accept = "application/json, text/plain, */*";
                    StreamReader sr = new StreamReader(hwr.GetResponse().GetResponseStream());
                    jsondata = sr.ReadToEnd();
                    B5Root b5 = JsonConvert.DeserializeObject<B5Root>(jsondata);
                    foreach (ItemsItem item in b5.data.items)
                    {
                        if (item.canDownload != 0) return urls;
                        urls.Add("http://demo.nbcsgo.com/demos/b5match_" + item.matchId + ".dem.zip");
                    }
                }
            }
            catch (WebException e)
            {
                mainForm.setLabel("获取数据出错=>" + e.Message);
                while (mainForm.SetThreadStopped()) { Thread.Sleep(200); };
            }
            return urls;
        }

    }

    public class ItemsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int matchId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int classId { get; set; }
        /// <summary>
        /// 对战匹配
        /// </summary>
        public string className { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mapName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string score { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string updateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string eloChange { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string achievement { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string kad { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string roomMates { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int favourite { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int canDownload { get; set; }
    }

    public class B5Data
    {
        /// <summary>
        /// 
        /// </summary>
        public int pageNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pageSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int startIndex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pages { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hasPrePage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hasNextPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ItemsItem> items { get; set; }
    }

    public class B5Root
    {
        /// <summary>
        /// 
        /// </summary>
        public string success { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public B5Data data { get; set; }
    }
}
