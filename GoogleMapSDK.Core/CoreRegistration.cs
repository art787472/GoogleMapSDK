using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.Core.Presenters;
using IOCDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using GoogleMapSDK.Contract;
using static GoogleMapSDK.Contract.ComponentContract.AutoCompleteContract;
using System.Collections.ObjectModel;
using System.Reflection;
using GoogleMapSDK.API;
using Microsoft.Extensions.Configuration;

namespace GoogleMapSDK.Core
{
    public static class CoreRegistration
    {
        public static void AddGoogleMapSDKRegistration(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddAPIRegistration(configuration);
            service.AddSingleton<BasePresenter, PlaceAutoCompletePresenter>();
            service.AddSingleton<BasePresenter, HistoryAutoCompletePresenter>();
        }
    }
}
