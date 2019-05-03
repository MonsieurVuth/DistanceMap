using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDistance
{
    class JsonLoad
    {
        private string FilePath;
        public JsonLoad(String path)
        {
            this.FilePath = path;
        }

        public List<MapItem> InfoMap()
        {
            using (StreamReader r = new StreamReader(this.FilePath))
            {
                var json = r.ReadToEnd();
                List<MapItem> items = JsonConvert.DeserializeObject<List<MapItem>>(json);
                return items;
            }
        }
    }
}
