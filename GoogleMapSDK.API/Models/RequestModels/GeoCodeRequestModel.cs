using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Models.RequestModels
{
    public class GeoCodeRequestModel : BaseRequestModel
    {
        public string Address { get; set; }
    }
}
