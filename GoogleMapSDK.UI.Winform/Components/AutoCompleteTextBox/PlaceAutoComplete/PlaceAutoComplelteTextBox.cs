﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoogleMapSDK.Contract;
using GoogleMapSDK.Contract.Models;
using static GoogleMapSDK.Contract.ComponentContract.AutoCompleteContract;
using IOCDependencyInjection;
using GoogleMapSDK.UI.Winform.Components.BaseAutoCompleteTextBox;
using GoogleMapSDK.Core.Presenters;
using static GoogleMapSDK.Contract.API.Models.ResponseModels.QueryAutoCompleteResponseModel;



namespace GoogleMapSDK.UI.Winform.Components.PlaceAutoComplete
{
    public class PlaceAutoComplelteTextBox : BaseAutoCompleteBox<Prediction,Place>
    {
        private BasePresenter _detailPresenter;
        private Place data;
        
        public PlaceAutoComplelteTextBox(IMVPFactory factory) : base()
        {
            this.SelectFinished += OnSelectFinished;
            this.detailPresenter = factory.Create<AutoCompleteTextBoxBase, BasePresenter>((AutoCompleteTextBoxBase)this, typeof(PlaceAutoCompletePresenter));
            this.DisplayMember = "description";
        }


        public BasePresenter detailPresenter { get => _detailPresenter; set => _detailPresenter = value; }

        private Action<object, Place> _placeSelected;
        public override Action<object, Place> PlaceSelected { get => _placeSelected; set => _placeSelected = value; }

        public void OnSelectFinished(object sender, object item)
        {

            var prediction = (Prediction)_listBox.SelectedValue;

            this.detailPresenter.GetPlaceDetail(prediction.place_id);
        }

        



        protected override void GetCompleteSource()
        {
            this.detailPresenter.GetDataSource(this.Text);
            
        }

        protected override Place GetSelectItem(Prediction selectedItem)
        {
            Prediction prediction = selectedItem;
            this.detailPresenter.GetPlaceDetail(prediction.place_id);
            return data;

        }



        public override void GetPlactDetailFinish<T>(T place)
        {
            object tmep = place;
            this._placeSelected?.Invoke(this, (Place)tmep);
            data = (Place)tmep;
        }

        public override void AutoCompleteFinish<T>(List<T> queries)
        {
            List<Prediction> places = new List<Prediction>();
            foreach (var query in queries)
            {
                object temp = query;
                places.Add((Prediction)temp);

            }
            this.DataSource = places;
        }

        //void GetPlactDetailFinish(Place place)
        //{
        //    this._placeSelected?.Invoke(this, place);
        //    data = place;
        //}

        //void AutoCompleteFinish(List<Prediction> queries)
        //{
        //    this.DataSource = queries;
        //}
    }
}
