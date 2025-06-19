using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Models.RequestModels
{
    public class TextSearchRequestModel : BaseRequestModel
    {
        public string Query { get; set; }
    }
}
