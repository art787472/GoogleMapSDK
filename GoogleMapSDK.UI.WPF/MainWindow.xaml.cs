using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using PolylineDecoder = GoogleMapSDK.API.Utility.PolylineDecoder;
using GoogleMapSDK.Contract.API;
using GoogleMapSDK.Contract.API.Models.RequestModels;
using GoogleMapSDK.Contract.Models;
using static GMap.NET.Entity.OpenStreetMapGraphHopperGeocodeEntity;
using Location = GoogleMapSDK.Contract.Models.Location;
using static GoogleMapSDK.Contract.ComponentContract.GoogleMapContract;
using System.ComponentModel;
using static GoogleMapSDK.Contract.ComponentContract.AutoCompleteContract;


namespace GoogleMapSDK.UI.WPF
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        private IGoogleMapContext _mapContext;
        private IGoogleMap gmap;
        private AutoCompleteTextBoxBase _autocompleteTextBox;
        public MainWindow(IGoogleMapContext mapContext, IGoogleMap gooleMap, AutoCompleteTextBoxBase autoComplete)
        {
            InitializeComponent();
            this._mapContext = mapContext;
            this.gmap = gooleMap;
            this._autocompleteTextBox = autoComplete;
            Grid.SetRow((UserControl)gmap, 1); 
            Grid.SetRow((UserControl)_autocompleteTextBox, 0);
            //container.Children.Add((UserControl)gmap);
            container.Children.Add((UserControl)_autocompleteTextBox);
            
            Panel.SetZIndex((UserControl)gmap, 0);
            Panel.SetZIndex((UserControl)_autocompleteTextBox, 1);


        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

            //var TaipeiStation = new PointLatLng(25.0475613, 121.5173399);
            //var Taipei101 = new PointLatLng(25.0339, 121.5650);

            //GMapMarker marker = new GMapMarker(TaipeiStation);
            Place TaipeiStation = new Place() { Location = new Location(25.0475613, 121.5173399) };
            Place Taipei101 = new Place() { Location = new Location(25.0339, 121.5650) };
            gmap.MovePosition(25.0475613, 121.5173399);
            gmap.AddMarker(TaipeiStation);

            var routeRequest = new RoutesRequestModel();
            
            var response = await _mapContext.routesAPI.RoutesAsync(routeRequest);


            //GMapRoute route = new GMapRoute(new List<PointLatLng> { new PointLatLng(25.0475613, 121.5173399), Taipei101 })
            //{
            //    Tag = "route",
            //    Shape = new Path() { Stroke = Brushes.DarkRed, StrokeDashArray = new DoubleCollection() { 2, 1 }, StrokeThickness = 4 }//line无效，改用path
            //}
            //;

            //response.routes[0].polylineDetails
            
            var places = PolylineDecoder.Decode(response.routes[0].polyline.encodedPolyline);
            // don't forget to add the marker to the map
            gmap.AddRoutes(places.Select(x => {
                return new Place() { Location = new Location(x.latitude, x.longitude) };
            }).ToList());
            //gmap.AddRoutes(new List<Place> { TaipeiStation, Taipei101 });

        }

        
    }
}
