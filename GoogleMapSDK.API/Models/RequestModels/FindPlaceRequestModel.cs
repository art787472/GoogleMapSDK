using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Models.RequestModels
{
    public class FindPlaceRequestModel
    {
        public string Input
        {
            get
            {
                return param["input"];
            }
            set
            {
                param["input"] = value;
            }
        }
        public string InputType
        {
            get
            {
                return param["inputtype"];
            }
            set
            {
                param["inputtype"] = value;
            }
        }
        public string Fields
        {
            get
            {
                return param["fields"];
            }
            set
            {
                param["fields"] = value;
            }
        }
        public Dictionary<string, string> param { get; set; } = new Dictionary<string, string>();
    }
}
