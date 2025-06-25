using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.API
{
    public interface IGoogleMapContext
    {
        IGeoCodeAPI geoCodeAPI { get; set; }

        IDirectionAPI directionAPI { get; set; }
        IPlaceAPI placesAPI { get; set; }
        IRoutesAPI routesAPI { get; set; }
    }
}
