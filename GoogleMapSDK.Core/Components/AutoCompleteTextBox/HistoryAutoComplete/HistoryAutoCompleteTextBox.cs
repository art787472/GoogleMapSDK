using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.Core.Component.GoogleMapComponent.Model;
using GoogleMapSDK.Core.Components.AutoCompleteTextBox.Base;
using GoogleMapSDK.Core.Components.BaseAutoCompleteTextBox;

using GoogleMapSDK.Core.Contract;
using IOCDependencyInjection;

namespace GoogleMapSDK.Core.Components.HistoryAutoComplete
{
    public class HistoryAutoCompleteTextBox : BaseAutoCompleteBox<Place, Place>
    {
        private BasePresenter _historyPresenter;
        public BasePresenter historyPresenter { get => _historyPresenter; set => _historyPresenter = value; }

        public HistoryAutoCompleteTextBox(IMVPFactory factory) : base()
        {
            this._historyPresenter = factory.Create<AutoCompleteTextBoxBase, BasePresenter>(this);
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
