using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDistance
{
    class MapItem
    {
        public String city { get; set; }
        public Double lan { get; set; }
        public Double lng { get; set; }

        public MapItem(string city, Double lat, Double longe)
        {
            this.city = city;
            this.lan = lat;
            this.lng = longe;
        }

    }
}
