using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using GMap.NET;
using GoogleMapSDK.Contract.API;
using GoogleMapSDK.Contract.API.Models.RequestModels;
using GoogleMapSDK.Contract.Models;
using GoogleMapSDK.Core.GoogleMapComponent.GoogleMapComponent.Control;
using GoogleMapSDK.UI.Winform.Components.HistoryAutoComplete;
using GoogleMapSDK.UI.Winform.Components.PlaceAutoComplete;
using GoogleMapSDK.UI.Winform.Test.Properties;
using Newtonsoft.Json.Linq;
using static GoogleMapSDK.Contract.ComponentContract.AutoCompleteContract;

namespace GoogleMapSDK.UI.Winform.Test
{
    public partial class Form1 : Form
    {
        private AutoCompleteTextBoxBase placeAutoCompleteTextBox;
        private AutoCompleteTextBoxBase historyAutoCompleteTextBox;
        private GoogleMap googleMap;
        private IGoogleMapContext _context;
        public Form1(IEnumerable<AutoCompleteTextBoxBase> autoTextBoxes, GoogleMap googleMap, IGoogleMapContext mapContext)
        {
            InitializeComponent();
          
            this.googleMap = googleMap;
            var TaipeiStation = new PointLatLng(25.0475613, 121.5173399);
            //this.googleMap.Position = TaipeiStation;
            this.googleMap.AddMarker(new Place
            {
                Name = "台北車站",
                Location = new Location(25.0475613, 121.5173399)
            });


            this.placeAutoCompleteTextBox = autoTextBoxes.FirstOrDefault(x => x.GetType() == typeof(PlaceAutoComplelteTextBox));
            this.placeAutoCompleteTextBox.PlaceSelected += PlaceSelected;
            this.Controls.Add((Control)this.placeAutoCompleteTextBox);

            this.historyAutoCompleteTextBox = autoTextBoxes.FirstOrDefault(x => x.GetType() == typeof(HistoryAutoCompleteTextBox));

            this._context = mapContext;
            //this.Controls.Add((Control)this.historyAutoCompleteTextBox);
        }

        public void PlaceSelected(object sender, Place place)
        {
            Console.WriteLine(place.Name);
            this.googleMap.MovePosition(place.Location);
            this.googleMap.AddMarker(place);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var routeRequest = new RoutesRequestModel();

            var response = await _context.routesAPI.RoutesAsync(routeRequest);
        }
    }
}
