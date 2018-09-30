using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace CommunityDemoDownloader.utils
{
    class JConfig
    {
        private string Path = null;

        public JConfig(string path)
        {
            this.Path = path;
        }

        public Config get(string cm)
        {
            if (!File.Exists(Path)){
                FileStream fs = File.Create(Path);
                fs.Close();
            }
            string  str = File.ReadAllText(Path);
            JObject data1 = (JObject)JsonConvert.DeserializeObject(str);
            if (data1 == null) return null;
            dynamic data2 = data1.First;
            while (data2.Path != cm) {
                if (data2.Next == null)
                {
                    return null;
                }
                data2 = data2.Next;
            }
            return JsonConvert.DeserializeObject<Config>(data2.Value.ToString());
        }

        public void set(string cm,Config conf)
        {
            string data = File.ReadAllText(Path);
            JObject data1 = (JObject)JsonConvert.DeserializeObject(data);
            if (data1 == null) data1 = new JObject(); else data1.Remove(cm);
            data1.Add(cm,JToken.FromObject(conf));
            string readdata = JsonConvert.SerializeObject(data1);
            File.WriteAllText(Path, readdata);
            
        }
    }
}
