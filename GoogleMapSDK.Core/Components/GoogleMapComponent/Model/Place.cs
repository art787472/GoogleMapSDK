using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.Component.GoogleMapComponent.Model
{
    public class Place
    {
        public Location Location { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public float Rating { get; set; }
        public string Photo_Reference { get; set; }
    }

    public class Location
    {
        public Location(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
