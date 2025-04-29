using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Models.ResponseModels
{
    public class PlaceDetailResponseModel
    {

        
            public object[] html_attributions { get; set; }
            public Result result { get; set; }
            public string status { get; set; }
        

        public class Result
        {
            public string formatted_phone_number { get; set; }
            public string name { get; set; }
            public float rating { get; set; }
        }

    }
}
