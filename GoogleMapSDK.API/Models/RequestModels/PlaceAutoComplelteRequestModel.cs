using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;

namespace GoogleMapSDK.API.Models.RequestModels
{
    public class PlaceAutoComplelteRequestModel
    {
        public string Input { get; set; }
        public string Location { get; set; }
        public string Radius { get; set; }
        public string Types { get; set; }

    }
}
