using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Web;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib;
using System.Threading;
namespace CommunityDemoDownloader.utils
{
    class Downloader
    {
        private string filepath;
        private string url;
        /// <summary>
        /// -1 done
        /// -2 faild
        /// </summary>
        private int progress_down = 0;
        private int progress_unzip = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="u">Demo Url</param>
        /// <param name="f">Save FilePath</param>
        /// 

        private MainForm mainForm;
        private long lenght;
        public Downloader(MainForm mf,string u,string f) {
            filepath = f;
            mainForm = mf;
            url = u;
            Download();
        }

        public void getLenght() {
            HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse rep = (HttpWebResponse)hwr.GetResponse();

            if (rep.StatusCode != HttpStatusCode.OK) {
                progress_down = -2;
            }
            lenght = rep.ContentLength;
        }

        public void Download() {

            if (filepath.Contains(".dem"))
            {
                if (File.Exists(filepath.Replace(".zip", string.Empty))) return;
            }
            else {
                if (File.Exists(filepath.Replace("zip", "dem"))) return;
            }
            try
            {
                mainForm.setLabel("获取demo数据中");
                HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse rep = (HttpWebResponse)hwr.GetResponse();
                Stream demo = rep.GetResponseStream();
                FileStream fs = File.Create(filepath);
                mainForm.setLabel("下载demo压缩文件: "+fs.Name);
                long cachelong = rep.ContentLength;
                byte[] cache = new byte[1024];
                int size;
                while ((size = demo.Read(cache, 0, cache.Length)) > 0) {
                    fs.Write(cache,0,size);
                    cachelong -= size;
                    progress_down = (int)(((rep.ContentLength - cachelong) / (double)rep.ContentLength) * 100);
                    mainForm.setProgress(progress_down);
                }
                rep.Close();
                demo.Close();
                fs.Flush();
                fs.Close();
                unZip();
            }
            catch (Exception e) {
                mainForm.setLabel("下载出错=>" + e.Message);
                while (mainForm.SetThreadStopped()) { Thread.Sleep(200); };
            }
        }

        private void unZip() {
            FileInfo f = new FileInfo(filepath);
            if (!f.Exists) return;
            try {
                ZipInputStream zip = new ZipInputStream(File.OpenRead(f.FullName));
                ZipEntry ze = zip.GetNextEntry();
                FileStream fs = File.Create(f.DirectoryName + "\\" + ze.Name);
                mainForm.setLabel("解压压缩文件: " + ze.Name);
                int size;
                long cahcelen = zip.Length;
                byte[] cache = new byte[1024];
                while ((size = zip.Read(cache, 0, cache.Length)) > 0)
                {
                    fs.Write(cache, 0, size);
                    cahcelen -= size;
                    progress_unzip = (int)(((zip.Length - cahcelen) / (double)zip.Length) * 100);
                    mainForm.setProgress(progress_unzip);
                }
                fs.Flush();
                fs.Close();
                zip.Close();
                f.Delete();
            } catch (Exception e) {
                mainForm.setLabel("解压出错=>" + e.Message);
                while (mainForm.SetThreadStopped()) { Thread.Sleep(200); };
            }
        }

    }
}
