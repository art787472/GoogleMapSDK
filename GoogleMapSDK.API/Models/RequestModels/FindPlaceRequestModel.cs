using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Models.RequestModels
{
    public class FindPlaceRequestModel : BaseRequestModel
    {
        public string Input { get; set; }
        
        public string InputType { get; set; }
        
        public string Fields { get; set; }
        
    }
}
