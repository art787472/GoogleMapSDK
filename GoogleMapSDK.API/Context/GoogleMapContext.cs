using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.API.APIs;
using GoogleMapSDK.API.Converter;
using GoogleMapSDK.Contract.API;
using Newtonsoft.Json;
using Request = HttpRequest.HttpRequest;

namespace GoogleMapSDK.API.Context
{
    public class GoogleMapContext : IGoogleMapContext
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter> { new PolylineJsonConverter() }
        };
        public Request request { get; set; } = new Request();
        public string Token { get; set; }

        private static GoogleMapContext _contextInstance;

        public static GoogleMapContext Instance
        {
            get
            {
                if(_contextInstance == null)
                    _contextInstance = new GoogleMapContext();
                return _contextInstance;
            }
        }

        public static void AssignAllServices(GoogleMapContext signingInstance)
        {
            _contextInstance = signingInstance;
        }


        public GoogleMapContext(string token)
        {
            Token = token;
            request.Token = Token;
            _contextInstance = this;

            request.AddSetting(settings);
            AddHeaders(request);
            InitilizeAPIs(request);
        }

        public GoogleMapContext()
        {
            this.Token = ConfigurationManager.AppSettings["apiKey"];
            request.Token = Token;
            _contextInstance = this;

            request.AddSetting(settings);
            AddHeaders(request);
            InitilizeAPIs(request);
        }

        public IGeoCodeAPI geoCodeAPI { get; set; }

        public IDirectionAPI directionAPI { get; set; }
        public IPlaceAPI placesAPI { get; set; }
        public IRoutesAPI routesAPI { get; set; }

        private void InitilizeAPIs(Request request)
        {
            geoCodeAPI = new GeoCodeAPI(request);
            directionAPI = new DirectionsAPI(request);
            placesAPI = new PlacesAPI(request);
            routesAPI = new RoutesAPI(request);
        }

        private void AddHeaders(Request request)
        {
            request.AddHeader("X-Goog-Api-Key", Token);
            request.AddHeader("X-Goog-FieldMask", "*");
        }

        
    }
}
