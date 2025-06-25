using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.API.Models.RequestModels
{
    public class PlaceDetailRequestModel : BaseRequestModel
    {
        public string Place_Id {  get; set; }
        
        public string Fields {  get; set; }
        
    }
}
