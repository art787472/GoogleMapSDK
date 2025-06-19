using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoogleMapSDK.Core.Component.GoogleMapComponent.Model;
using GoogleMapSDK.Core.Components.AutoCompleteTextBox.Base;

namespace GoogleMapSDK.Core.Contract
{
    public interface AutoCompleteTextBoxBase
    {
        string DisplayMember {  get; set; }
        string ValueMember { get; set; }
        BasePresenter Presenter { get; set; }

        Action<object, Place> PlaceSelected { get; set; }
        void Initialize();
        void UpdateListBox();

        void this_KeyUp(object sender, KeyEventArgs e);

        void AutoCompleteFinish<T>(List<T> queries);
        void GetPlactDetailFinish<T>(T place);

    }
}
