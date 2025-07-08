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
using Microsoft.Extensions.Configuration;
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
        public Request request { get; set; } 
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


        //public GoogleMapContext(string token, IDirectionAPI directionAPI, IGeoCodeAPI geoCodeAPI, IPlaceAPI placeAPI, IRoutesAPI routesAPI)
        //{

        //    Token = token;
        //    request.Token = Token;
        //    _contextInstance = this;

        //    request.AddSetting(settings);
        //    AddHeaders(request);

        //    this.geoCodeAPI = geoCodeAPI;
        //    this.directionAPI = directionAPI;
        //    this.placesAPI = placeAPI;
        //    this.routesAPI = routesAPI;
        //}

        public GoogleMapContext(Request request,IDirectionAPI directionAPI, IGeoCodeAPI geoCodeAPI, IPlaceAPI placeAPI, IRoutesAPI routesAPI, IConfiguration configuration)
        {

            //Token = configuration["apiKey"];
            //request.Token = Token;
            _contextInstance = this;

            request.AddSetting(settings);
            //AddHeaders(request);

            this.request = request;
            this.geoCodeAPI = geoCodeAPI;
            this.directionAPI = directionAPI;
            this.placesAPI = placeAPI;
            this.routesAPI = routesAPI;
        }

        public GoogleMapContext()
        {
            this.Token = ConfigurationManager.AppSettings["apiKey"];
            request.Token = Token;
            _contextInstance = this;

            request.AddSetting(settings);
            AddHeaders(request);
            
        }

        public IGeoCodeAPI geoCodeAPI { get; set; }

        public IDirectionAPI directionAPI { get; set; }
        public IPlaceAPI placesAPI { get; set; }
        public IRoutesAPI routesAPI { get; set; }



        private void AddHeaders(Request request)
        {
            request.AddHeader("X-Goog-Api-Key", Token);
            request.AddHeader("X-Goog-FieldMask", "*");
        }

        
    }
}
