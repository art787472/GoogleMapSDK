using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.API.APIs;
using Request = HttpRequest.HttpRequest;

namespace GoogleMapSDK.API.Context
{
    public class GoogleMapContext
    {
        
        public Request request { get; set; } = new Request();
        public string Token { get; set; }

        public GoogleMapContext( string token)
        {
            Token = token;
            request.Token = Token;
            

            geoCodeAPI = new GeoCodeAPI(request);
            directionAPI = new DirectionsAPI(request);
            placesAPI = new PlacesAPI(request);
            routesAPI = new RoutesAPI(request);
        }

        public GeoCodeAPI geoCodeAPI { get; set; }

        public DirectionsAPI directionAPI { get; set; }
        public PlacesAPI placesAPI { get; set; }
        public RoutesAPI routesAPI { get; set; }
    }
}
