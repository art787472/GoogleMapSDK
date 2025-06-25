using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.API.Models.RequestModels
{
    public class QueryAutoCompleteRequestModel : BaseRequestModel
    {
        public string Input {  get; set; }
    }
}
