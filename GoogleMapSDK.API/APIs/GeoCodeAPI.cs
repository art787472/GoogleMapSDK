using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.Contract.API;
using GoogleMapSDK.Contract.API.Models.RequestModels;
using GoogleMapSDK.Contract.API.Models.ResponseModels;
using Request = HttpRequest.HttpRequest;

namespace GoogleMapSDK.API.APIs
{
    public class GeoCodeAPI : IGeoCodeAPI
    {
        private readonly Request _request;

        public GeoCodeAPI(Request request)
        {
            _request = request;
        }

        public async Task<GeoCodeResponseModel> GetGeoCodeAsync(GeoCodeRequestModel model)
        {
            var baseUrl = $"https://maps.googleapis.com/maps/api/geocode/json";
            var response = await _request.GetAsync<GeoCodeResponseModel>(baseUrl + model.ToUri());
            return response;
        }
    }
}
