using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.API.Models.RequestModels;
using GoogleMapSDK.API.Models.ResponseModels;
using Request = HttpRequest.HttpRequest;

namespace GoogleMapSDK.API.APIs
{
    public class RoutesAPI
    {
        private readonly Request _request;

        public RoutesAPI(Request request)
        {
            _request = request;
        }

        public async Task<RoutesResponseModel> RoutesAsync(RoutesRequestModel model)
        {
            var baseUrl = $"https://routes.googleapis.com/directions/v2:computeRoutes";
            
            return await _request.PostAsync<RoutesResponseModel>(baseUrl, model);
        }
    }
}
