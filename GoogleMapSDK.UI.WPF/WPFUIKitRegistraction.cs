using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.API.Context;
using GoogleMapSDK.Contract.API;
using GoogleMapSDK.Core.Presenters;
using GoogleMapSDK.UI.WPF.Components.AutoCompleteTextBox.PlaceAutoComplete;
using GoogleMapSDK.UI.WPF.Components.GoogleMapComponent.Control;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static GoogleMapSDK.Contract.ComponentContract.AutoCompleteContract;
using static GoogleMapSDK.Contract.ComponentContract.GoogleMapContract;

namespace GoogleMapSDK.UI.WPF
{
    public static class WPFUIKitRegistraction
    {
        public static void AddWPFIKitRegistraction(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddSingleton<IGoogleMap, GoogleMap>();
            service.AddSingleton<AutoCompleteTextBoxBase, PlaceAutoCompleteTextBox>();
            service.AddSingleton<BasePresenter, PlaceAutoCompletePresenter>();

        }
    }
}
