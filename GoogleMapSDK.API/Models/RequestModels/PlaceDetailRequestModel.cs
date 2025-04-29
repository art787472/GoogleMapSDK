using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Models.RequestModels
{
    public class PlaceDetailRequestModel : ARequestModel
    {
        public string PlaceId
        {
            get
            {
                return param["place_id"];
            }
            set
            {
                param["place_id"] = value;
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
    }
}
