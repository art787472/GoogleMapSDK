using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GoogleMapSDK.Contract.API.Utility;

namespace GoogleMapSDK.Contract.API.Models.RequestModels
{
    public class BaseRequestModel

    {
        string Token { get; set; }

        public Dictionary<string, string> GetParam(string apiKey)
        {
           
             
                var param = this.ToDictionary();
                param.Add("key", apiKey);
                param.Add("language", "zh-TW");
                return param;
            
        }

        public string ToUri (string apiKey)
        {
            var param = this.GetParam(apiKey);
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
