using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.Contract.API.Models.RequestModels;
using GoogleMapSDK.Contract.API.Models.ResponseModels;


namespace GoogleMapSDK.Contract.API
{
    public interface IRoutesAPI
    {
        Task<RoutesResponseModel> RoutesAsync(RoutesRequestModel model);
    }
}
