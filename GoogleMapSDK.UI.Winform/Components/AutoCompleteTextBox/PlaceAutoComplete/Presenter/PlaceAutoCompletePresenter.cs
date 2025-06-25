using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoogleMapSDK.API.Context;

using GoogleMapSDK.Contract.API;
using GoogleMapSDK.Contract.API.Models.RequestModels;
using GoogleMapSDK.Contract.Models;

using static GoogleMapSDK.Contract.ComponentContract.AutoCompleteContract;

namespace GoogleMapSDK.UI.Winform.Components.PlaceAutoComplete.Presenter
{
    public class PlaceAutoCompletePresenter : BasePresenter
    {
        private IGoogleMapContext context;
        private AutoCompleteTextBoxBase _view;
        public PlaceAutoCompletePresenter(AutoCompleteTextBoxBase placeDetailView) 
        {
            _view = placeDetailView;
            context = GoogleMapContext.Instance;
        }


        public AutoCompleteTextBoxBase View { get => _view; set => _view = value; }

        public async void AutoComplete(string query)
        {
            var model = new QueryAutoCompleteRequestModel
            {
                Input = query
            };
            var response = await context.placesAPI.QueryAutoComplete(model);
            View.AutoCompleteFinish(response.predictions.ToList());
        }

        public async void GetDataSource(string query)
        {
            var model = new QueryAutoCompleteRequestModel
            {
                Input = query
            };
            var response = await context.placesAPI.QueryAutoComplete(model);
            View.AutoCompleteFinish(response.predictions.ToList());
        }

        public async void GetPlaceDetail(string placeID)
        {
            var placeDetailModel = new PlaceDetailRequestModel()
            {
                Place_Id = placeID
               
            };
            var res = await context.placesAPI.PlaceDetailAsync(placeDetailModel);

            var place = new Place()
            {
                Name = res.result.name,
                Location = new Location(res.result.geometry.location.lat, res.result.geometry.location.lng)

            };
            this.View.GetPlactDetailFinish(place);
        }
    }
}
