using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Request = HttpRequest.HttpRequest;
using System.Web;
using GoogleMapSDK.API.Models.RequestModels;
using GoogleMapSDK.API.Models.ResponseModels;

namespace GoogleMapSDK.API.APIs
{
    public class DirectionsAPI
    {
        private readonly Request _request;

        public DirectionsAPI(Request request)
        {
            _request = request;
        }

        public Task<DirectionsResponseModel> GetDirectionsAsync(DirectionsRequestModel model)
        {
            var baseUrl = $"https://maps.googleapis.com/maps/api/directions/json";

            var param = model.param;
            param["key"] = _request.Token;




            return _request.GetAsync<DirectionsResponseModel>(baseUrl, model.param);
        }
    }
}
