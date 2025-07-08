using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.Contract;
using GoogleMapSDK.Contract.Models;
using static GoogleMapSDK.Contract.ComponentContract.AutoCompleteContract;
using IOCDependencyInjection;
using GoogleMapSDK.UI.Winform.Components.BaseAutoCompleteTextBox;
using GoogleMapSDK.Core.Presenters;

namespace GoogleMapSDK.UI.Winform.Components.HistoryAutoComplete
{
    public class HistoryAutoCompleteTextBox : BaseAutoCompleteBox<Place, Place>
    {
        private BasePresenter _historyPresenter;
        public BasePresenter historyPresenter { get => _historyPresenter; set => _historyPresenter = value; }

        public HistoryAutoCompleteTextBox(IMVPFactory factory) : base()
        {
            this._historyPresenter = factory.Create<AutoCompleteTextBoxBase, BasePresenter>((AutoCompleteTextBoxBase)this, typeof(HistoryAutoCompletePresenter));
            this.DisplayMember = "Name";
        }
        private Action<object, Place> _placeSelected;
        public override Action<object, Place> PlaceSelected { get => _placeSelected; set => _placeSelected = value; }
        public override void GetPlactDetailFinish<T>(T place)
        {
            object tmep = place;
            
        }

        public override void AutoCompleteFinish<T>(List<T> queries)
        {
            List<Place> places = new List<Place>();
            foreach (var query in queries)
            {
                object temp = query;
                places.Add((Place)temp);

            }
            this.DataSource = places;
        }

        protected override void GetCompleteSource()
        {
            this._historyPresenter.GetDataSource(this.Text);
        }

        protected override Place GetSelectItem(Place selectedItem)
        {
            return selectedItem;
        }
    }
}
