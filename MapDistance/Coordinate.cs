using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
namespace MapDistance
{
    class Coordinate
    {

        public double GetDistance(double latitude1, double longitude1, double latitude2, double longitude2)
        {
            var firstCordinate = new GeoCoordinate(latitude1, longitude1);
            var secondCordinate = new GeoCoordinate(latitude2, longitude2);

            double distance = firstCordinate.GetDistanceTo(secondCordinate);
            return distance;
        }
    }
}
