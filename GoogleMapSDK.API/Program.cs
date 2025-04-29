using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.API.APIs;
using GoogleMapSDK.API.Context;
using GoogleMapSDK.API.Models.RequestModels;
using GoogleMapSDK.API.Models.ResponseModels;

namespace GoogleMapSDK.API
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            GoogleMapContext context = new GoogleMapContext("AIzaSyAOGStQaoYkBHNeqfXBNaX4_uHc34n8Z_k");

            //var requestModel = new DirectionsRequestModel()
            //{
            //    param = new Dictionary<string, string>()
            //    {
            //        { "origin", "台北101" },
            //        { "destination", "台北車站" },
            //        { "mode", "driving" }
            //    }
            //};

            //var response = await context.directionAPI.GetDirectionsAsync(requestModel);

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
            //    Photo_Id = "ChIJcUElzOzMQQwRLuV30nMUEUM"
            //};

            //var photoResponse = await context.placesAPI.PlacePhoto(photoModel);

            var routesModel = new RoutesRequestModel();
            
            var routesResponse = await context.routesAPI.RoutesAsync(routesModel);
        }
    }
}
