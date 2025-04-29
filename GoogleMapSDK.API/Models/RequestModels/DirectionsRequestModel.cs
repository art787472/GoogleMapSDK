using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using GoogleMapSDK.API.Enums;

namespace GoogleMapSDK.API.Models.RequestModels
{
    public class DirectionsRequestModel
    {
        public string Origin
        {
            get
            {
                return param["origin"];
            }
            
            set
            {
                param["origin"] = value;
            }
        }
        public string Destination 
        { 
            get
            {
                return param["destination"];
            }
            set
            {
                param["destination"] = value;
            }
        }
        public bool Alternatives 
        {
            get
            {
                return bool.Parse(param["alternative"]);
            }
            set
            {
                param["alternative"] = value.ToString();
            }

        }
        public string Mode
        {
            get
            {
                return param["mode"];
            }
            set
            {
                param["mode"] = value;
            }

        }
        public string Waypoint
        {
            get
            {
                return param["waypoint"];
            }
            set
            {
                param["waypoint"] = value;
            }

        }

        public Dictionary<string, string> param = new Dictionary<string, string>
        {
            ["mode"] = "driving",
            
            ["alternatives"] = "true"
        };

       
    }
}
