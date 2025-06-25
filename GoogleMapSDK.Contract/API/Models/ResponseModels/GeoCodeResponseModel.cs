using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.API.Models.ResponseModels
{
    public class GeoCodeResponseModel
    {

        
            public Result[] results { get; set; }
            public string status { get; set; }
       

        public class Result
        {
            public Address_Components[] address_components { get; set; }
            public string formatted_address { get; set; }
            public Geometry geometry { get; set; }
            public Navigation_Points[] navigation_points { get; set; }
            public string place_id { get; set; }
            public Plus_Code plus_code { get; set; }
            public string[] types { get; set; }
        }

        public class Geometry
        {
            public Location location { get; set; }
            public string location_type { get; set; }
            public Viewport viewport { get; set; }
        }

        public class Location
        {
            public float lat { get; set; }
            public float lng { get; set; }
        }

        public class Viewport
        {
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }

        public class Northeast
        {
            public float lat { get; set; }
            public float lng { get; set; }
        }

        public class Southwest
        {
            public float lat { get; set; }
            public float lng { get; set; }
        }

        public class Plus_Code
        {
            public string compound_code { get; set; }
            public string global_code { get; set; }
        }

        public class Address_Components
        {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public string[] types { get; set; }
        }

        public class Navigation_Points
        {
            public Location1 location { get; set; }
        }

        public class Location1
        {
            public float latitude { get; set; }
            public float longitude { get; set; }
        }

    }
}
