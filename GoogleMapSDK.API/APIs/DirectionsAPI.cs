using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Request = HttpRequest.HttpRequest;
using System.Web;

using GoogleMapSDK.Contract.API;
using GoogleMapSDK.Contract.API.Models.ResponseModels;
using GoogleMapSDK.Contract.API.Models.RequestModels;

namespace GoogleMapSDK.API.APIs
{
    public class DirectionsAPI : IDirectionAPI
    {
        private readonly Request _request;

        public DirectionsAPI(Request request)
        {
            _request = request;
        }

        public Task<DirectionsResponseModel> GetDirectionsAsync(DirectionsRequestModel model)
        {
            var baseUrl = $"https://maps.googleapis.com/maps/api/directions/json";
            return _request.GetAsync<DirectionsResponseModel>(baseUrl + model.ToUri(_request.Token));
        }
    }
}
