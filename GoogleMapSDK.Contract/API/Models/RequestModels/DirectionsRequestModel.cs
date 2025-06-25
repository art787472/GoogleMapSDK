using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using GoogleMapSDK.Contract.API.Enums;

namespace GoogleMapSDK.Contract.API.Models.RequestModels
{
    public class DirectionsRequestModel : BaseRequestModel
    {
        public string Origin{ get; set;}
        public string Destination { get; set; }
        public bool Alternatives { get; set; }
        public TrafficMode Mode { get; set; }
        public string Waypoint { get; set; } //TODO: 解決waypoint的問題
        
    }
}
