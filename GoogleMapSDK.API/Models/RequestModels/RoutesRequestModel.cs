using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Models.RequestModels
{
    public class RoutesRequestModel 
    {

        
            public Origin origin { get; set; } = new Origin();
            public Destination destination { get; set; } = new Destination();
        //public Intermediate[] intermediates { get; set; } 
        public string travelMode { get; set; } = "DRIVE";
        public string routingPreference { get; set; } = "TRAFFIC_AWARE";
        public bool computeAlternativeRoutes { get; set; } = false;
            public Routemodifiers routeModifiers { get; set; }
            public string languageCode { get; set; } = "zh-TW";
        public string units { get; set; } = "IMPERIAL";



        public class Origin
        {
            public Location location { get; set; } = new Location(new LatLng(37.419734, -122.0827784));
        }

        public class Location
        {
            public Location(LatLng latLng)
            {
                this.latLng = latLng;
            }

            public LatLng latLng { get; set; }
        }



        public class Destination
        {
            public Location location { get; set; } = new Location(new LatLng(37.417670, -122.079595));
        }

        

        

        public class Routemodifiers
        {
            public bool avoidTolls { get; set; } = false;
            public bool avoidHighways { get; set; } = false;
            public bool avoidFerries { get; set; } = false;
        }

        public class Intermediate
        {
            public Location location { get; set; }
        }

        

        


    }
}
