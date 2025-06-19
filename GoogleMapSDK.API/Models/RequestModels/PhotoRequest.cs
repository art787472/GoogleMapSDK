using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Models.RequestModels
{
    public class PhotoRequest : BaseRequestModel
    {
        public string Photo_reference {  get; set; }
        public int MaxWidth { get; set; }
    }
}
