using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.Contract.Models;
using GoogleMapSDK.Contract;

using static GoogleMapSDK.Contract.ComponentContract.AutoCompleteContract;

namespace GoogleMapSDK.UI.Winform.Components.HistoryAutoComplete.Presenter
{
    public class HistoryAutoCompletePresenter : BasePresenter
    {
        private AutoCompleteTextBoxBase _view;
        private List<Place> placeHistory = new List<Place>
        {
            new Place() { Name = "台北"},
            new Place() { Name = "台中"},
            new Place() { Name = "台南"},
            new Place() { Name = "高雄"}
        };

        public HistoryAutoCompletePresenter(AutoCompleteTextBoxBase view)
        {
            this._view = view;
        }
        public AutoCompleteTextBoxBase View { get => _view; set => value = _view; }



        public void GetDataSource(string query)
        {
            var places = placeHistory.Where(x => x.Name.Contains(query)).ToList();
            _view.AutoCompleteFinish(places);
        }

        public void GetPlaceDetail(string placeID)
        {
            throw new NotImplementedException();
        }
    }
}
