using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.API.Models.RequestModels
{
    public class NearBySearchRequestModel : BaseRequestModel
    {
        public string Keyword { get; set; }
        public string Location { get; set; }
        

        public string Radius { get; set; }

        public string Type { get; set; }

        

    }
}
