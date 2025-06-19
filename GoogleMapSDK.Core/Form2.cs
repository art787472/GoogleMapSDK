using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.MapProviders;
using GMap.NET;
using GoogleMapSDK.Core.Components.PlaceAutoComplete;
using GoogleMapSDK.Core.Components.HistoryAutoComplete;

using GoogleMapSDK.Core.Contract;

namespace GoogleMapSDK.Core
{
    public partial class Form2 : Form
    {
        private AutoCompleteTextBoxBase placeAutoCompleteTextBox;
        private AutoCompleteTextBoxBase historyAutoCompleteTextBox;
        public Form2(IEnumerable<AutoCompleteTextBoxBase> autoTextBoxes)
        {
            InitializeComponent();

            var TaipeiStation = new PointLatLng(25.0475613, 121.5173399);
            this.googleMap1.Position = TaipeiStation;
            this.googleMap1.AddMarker(new Component.GoogleMapComponent.Model.Place
            {
                Name = "台北車站",
                Location = new Component.GoogleMapComponent.Model.Location(25.0475613, 121.5173399)
            });


            this.placeAutoCompleteTextBox = autoTextBoxes.FirstOrDefault(x => x.GetType() == typeof(PlaceAutoComplelteTextBox));
            //this.placeAutoCompleteTextBox.PlaceSelected += PlaceSelected;
            this.Controls.Add((Control)this.placeAutoCompleteTextBox);

            this.historyAutoCompleteTextBox = autoTextBoxes.FirstOrDefault(x => x.GetType() == typeof(HistoryAutoCompleteTextBox));
            
            this.Controls.Add((Control)this.historyAutoCompleteTextBox);
            //0.初始化地圖
            //1.DI注入取得AutoComplete
            //2.根據輸入內容呼叫 AutoCompleteRequest
            //3.根據Response內容將資料傳入AutoComplete DataSource
            //4.監聽並取得當下使用者所選擇的Place Item
            //5.將Place ITem 轉換成GMap可以吃的類型格式進行Marker渲染


            //gmap.SetCenter = new Location(lat,lng);

            //placeAutoComplete.PlaceSelected += placeAutoComplete_PlaceSelected
            //public void PlaceSelected(object sender,PlaceInfo info){
            //   gmap.SetCenter = new Location(info.lat,info.lng);
            //   gmap.AddMarker(info);
            //}

            //gmap.PlanRoutes(PlaceInfo start,PlaceInfo end);
            //gmap.PlanRoutes(PlaceInfo start,PlaceInfo end,waypoints);
        }

        public void PlaceSelected(object sender, Component.GoogleMapComponent.Model.Place place)
        {
            Console.WriteLine(place.Name);
            this.googleMap1.MovePosition(place.Location);
            this.googleMap1.AddMarker(place);
        }
    }
}
