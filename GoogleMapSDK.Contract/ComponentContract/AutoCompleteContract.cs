using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GoogleMapSDK.Contract.Models;

namespace GoogleMapSDK.Contract.ComponentContract
{
    public class AutoCompleteContract
    {
        public interface AutoCompleteTextBoxBase
        {
            string DisplayMember { get; set; }
            string ValueMember { get; set; }
            BasePresenter Presenter { get; set; }

            //TODO: 這裡感覺不應該寫死放Place,未來會需要思考如何移除
            Action<object, Place> PlaceSelected { get; set; }
            void Initialize();
            void UpdateListBox();

            void this_KeyUp(object sender, KeyEventArgs e);

            void AutoCompleteFinish<T>(List<T> queries);
            void GetPlactDetailFinish<T>(T place);

        }

        public interface BasePresenter
        {
            AutoCompleteTextBoxBase View { get; set; }
            void GetDataSource(string query);

            void GetPlaceDetail(string placeID);

        }
    }
}
