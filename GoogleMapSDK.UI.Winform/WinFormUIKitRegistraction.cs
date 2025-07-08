using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.Core.GoogleMapComponent.GoogleMapComponent.Control;

using GoogleMapSDK.UI.Winform.Components.HistoryAutoComplete;

using GoogleMapSDK.UI.Winform.Components.PlaceAutoComplete;
using Microsoft.Extensions.DependencyInjection;
using static GoogleMapSDK.Contract.ComponentContract.AutoCompleteContract;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using static GoogleMapSDK.Contract.ComponentContract.GoogleMapContract;

namespace GoogleMapSDK.UI.Winform
{
    public static class  WinFormUIKitRegistraction
    {
        public static void AddWinFormUIKitRegistraction(this IServiceCollection service,IConfiguration configuration)
        {
            service.AddTransient<IGoogleMap, GoogleMap>();
            service.AddTransient<AutoCompleteTextBoxBase, PlaceAutoComplelteTextBox>();
            service.AddTransient<AutoCompleteTextBoxBase, HistoryAutoCompleteTextBox>();

        }
    }
}
