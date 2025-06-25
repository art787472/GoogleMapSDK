using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GoogleMapSDK.API.Utility;

namespace GoogleMapSDK.Contract.API.Models.RequestModels
{
    public class BaseRequestModel
    {
        public Dictionary<string, string> GetParam()
        {
           
             
                var param = this.ToDictionary();
                param.Add("key", ConfigurationManager.AppSettings["apiKey"]);
            param.Add("language", "zh-TW");
                return param;
            
        }

        public string ToUri ()
        {
            var param = this.GetParam();
            string uri = "?";
            foreach (var kv in param)
            {
                uri += $"{kv.Key}={kv.Value}&"; 
            }
            uri = uri.TrimEnd ('&');

            return uri;

        }
    }
}
