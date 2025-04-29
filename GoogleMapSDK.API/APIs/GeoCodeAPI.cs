using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.API.Models.ResponseModels;
using Request = HttpRequest.HttpRequest;

namespace GoogleMapSDK.API.APIs
{
    public class GeoCodeAPI
    {
        private readonly Request _request;

        public GeoCodeAPI(Request request)
        {
            _request = request;
        }

        public async Task<GeoCodeResponseModel> GetGeoCodeAsync(string address)
        {
            var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={address}&key={_request.Token}";
            var response = await _request.GetAsync<GeoCodeResponseModel>(url);
            return response;
        }
    }
}
