using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.Core.GoogleMapComponent.GMap.Control;
using GoogleMapSDK.UI.Winform.Components.HistoryAutoComplete.Presenter;
using GoogleMapSDK.UI.Winform.Components.HistoryAutoComplete;
using GoogleMapSDK.UI.Winform.Components.PlaceAutoComplete.Presenter;
using GoogleMapSDK.UI.Winform.Components.PlaceAutoComplete;
using Microsoft.Extensions.DependencyInjection;
using static GoogleMapSDK.Contract.ComponentContract.AutoCompleteContract;

namespace GoogleMapSDK.UI.Winform
{
    public static class  WinFormUIKitRegistraction
    {
        public static void AddWinFormUIKitRegistraction(this IServiceCollection service)
        {
            service.AddTransient<GoogleMap, GoogleMap>();
            service.AddTransient<AutoCompleteTextBoxBase, PlaceAutoComplelteTextBox>();
            service.AddTransient<AutoCompleteTextBoxBase, HistoryAutoCompleteTextBox>();
            service.AddTransient<BasePresenter, PlaceAutoCompletePresenter>();
            service.AddTransient<BasePresenter, HistoryAutoCompletePresenter>();
        }
    }
}
