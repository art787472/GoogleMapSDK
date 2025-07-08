using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.API.APIs;
using GoogleMapSDK.API.Context;
using GoogleMapSDK.Contract.API;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Request = HttpRequest.HttpRequest;
namespace GoogleMapSDK.API
{
    public static class APIRegistration
    {
        public static void AddAPIRegistration(this IServiceCollection collection,IConfiguration configuration)
        {
            
            collection.AddSingleton<Request>(x =>
            {
                var request = new Request();
                request.Token = configuration["apiKey"];
                return request;
            });
            collection.AddSingleton<IDirectionAPI, DirectionsAPI>();
            collection.AddSingleton<IGeoCodeAPI, GeoCodeAPI>();
            collection.AddSingleton<IPlaceAPI, PlacesAPI>();
            collection.AddSingleton<IRoutesAPI, RoutesAPI>();
            collection.AddSingleton<IGoogleMapContext, GoogleMapContext>();
            collection.AddSingleton<IConfiguration>(configuration);
            
        }
    }
}
