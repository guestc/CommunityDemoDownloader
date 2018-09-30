using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityDemoDownloader.utils
{
    public class Config
    {
        public string path { set; get; }
        public string url { set; get; }
        public bool olny { set; get; }
        public bool autodownload { set; get; }
        public bool powerboot { set; get; }
    }
}
