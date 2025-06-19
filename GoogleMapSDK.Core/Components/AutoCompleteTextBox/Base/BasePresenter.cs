using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.Core.Contract;

namespace GoogleMapSDK.Core.Components.AutoCompleteTextBox.Base
{
    public interface BasePresenter
    {
        AutoCompleteTextBoxBase View { get; set; }
        void GetDataSource(string query);

        void GetPlaceDetail(string placeID);
        
    }
}
