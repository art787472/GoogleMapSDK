using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.API.APIs;
using GoogleMapSDK.API.Context;
using GoogleMapSDK.API.Converter;

using GoogleMapSDK.API.Utility;
using GoogleMapSDK.Contract.API.Enums;
using GoogleMapSDK.Contract.API.Models.RequestModels;
using Newtonsoft.Json;

namespace GoogleMapSDK.API
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            GoogleMapContext.AssignAllServices(new GoogleMapContext(ConfigurationManager.AppSettings["apiKey"]));

            var context = new GoogleMapContext(ConfigurationManager.AppSettings["apiKey"]);
            //var model = new GeoCodeRequestModel { Address = "台北101" };
            //var p = model.Param;


            //var geocode = await context.geoCodeAPI.GetGeoCodeAsync(new GeoCodeRequestModel { Address = "台北101" });


            var requestModel = new DirectionsRequestModel()
            {
                Origin = "台北101",
                Destination = "台北車站",
                Mode = TrafficMode.Driving 
                
            };

            
            var response = await context.directionAPI.GetDirectionsAsync(requestModel);

            //var findPlaceModel = new FindPlaceRequestModel()
            //{
            //    param = new Dictionary<string, string>()
            //    {
            //        { "input", "台北101" },
            //        { "inputtype", "textquery" },
            //        { "fields", "formatted_address%2Cname%2Crating%2Copening_hours%2Cgeometry" }
            //    }
            //};

            //var findPlaceResponse = await context.placesAPI.FindPlaceAsync(findPlaceModel);

            //var nearBySearchModel = new NearBySearchRequestModel()
            //{
            //    Location = "25.0478%2C121.5319",
            //    Radius = "1500",
            //    Keyword = "餐廳",

            //};

            //var nearBySearchResponse = await context.placesAPI.NearBySearchAsync(nearBySearchModel);


            //var photoModel = new PlacePhotoRequestModel()
            //{
            //    MaxWidth = 400,
            //    PlaceId = "ChIJcUElzOzMQQwRLuV30nMUEUM"
            //};

            //var photoResponse = await context.placesAPI.PlacePhoto(photoModel);


            var point = PolylineDecoder.Decode("{hxwCc{}dVW?EAU?G?I?mAAiAAq@?i@A_@?uD?_@Aa@Lm@?QAW?{@?kAAc@?oAAwBEa@?Q?I?]BI?");

            //var routesModel = new RoutesRequestModel();

            //var routesResponse = await context.routesAPI.RoutesAsync(routesModel);
        }
    }
}
