using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using GoogleMapSDK.Contract.Models;
using GoogleMapSDK.UI.WPF.Components.GoogleMapComponent.Overlays;
using static GoogleMapSDK.Contract.ComponentContract.GoogleMapContract;
using Location = GoogleMapSDK.Contract.Models.Location;

namespace GoogleMapSDK.UI.WPF.Components.GoogleMapComponent.Control
{
    public class GoogleMap : UserControl,  IGoogleMap
    {
        private AOverlay MarkerOverlay = OverLayFactory.Create(OverlayType.Marker);
        private GMapControl gMapControl1 = new GMapControl();
        private AOverlay RouteOverlay = OverLayFactory.Create(OverlayType.Route);

        public GoogleMap()
        {
            InitializeComponent();
            MarkerOverlay.gMap = this.gMapControl1;
            RouteOverlay.gMap = this.gMapControl1;
        }
        public void AddMarker(Place place)
        {
            GMapMarker marker = new GMapMarker(new PointLatLng(place.Location.Lat, place.Location.Lng));
            marker.Shape = new Image
            {
                Width = 20,
                Height = 20,
                Source = new BitmapImage(new System.Uri(@"D:\c_sharp\GoogleMapSDK\GoogleMapSDK.UI.WPF\marker\red.png"))
            };


            marker.Tag = place;
            MarkerOverlay.Add(marker);
        }

        public void AddMarker(Place place, string overlayId)
        {
            GMapMarker marker = new GMapMarker(new PointLatLng(place.Location.Lat, place.Location.Lng));
            marker.Shape = new Image
            {
                Width = 20,
                Height = 20,
                Source = new BitmapImage(new System.Uri(@"D:\c_sharp\GoogleMapSDK\GoogleMapSDK.UI.WPF\marker\red.png"))
            };


            marker.Tag = place;
            MarkerOverlay.Add(marker, overlayId);
        }

        public void AddMarkers(List<Place> places)
        {
            
            foreach (Place place in places)
            {
                AddMarker(place);
            }
            
        }

        public void AddMarkers(List<Place> places, bool enableTooltip = true)
        {
            foreach (Place place in places)
            {
                AddMarker(place);
            }
        }

        public void AddRoutes(List<Place> places)
        {
            GMapRoute route = new GMapRoute(places.Select(x => new PointLatLng(x.Location.Lat, x.Location.Lng)));
            RouteOverlay.Add(route);
        }

        public void MovePosition(Location location)
        {
            this.gMapControl1.Position = new PointLatLng(location.Lat, location.Lng);
        }

        public void MovePosition(double lat, double lng)
        {
            this.gMapControl1.Position = new PointLatLng(lat, lng);
        }

        public void RemoveMarker(Place place)
        {
            throw new NotImplementedException();
        }

        public void RemoveRoutes(MapRoute route)
        {
            throw new NotImplementedException();
        }

        private void InitializeComponent()
        {
            this.gMapControl1 = new GMapControl();
            
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            //this.gMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            //this.gMapControl1.GrayScaleMode = false;
            //this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemory = 5;
            //this.gMapControl1.Location = new System.Drawing.Point(0, 0);
            //this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 20;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            //this.gMapControl1.NegativeMode = false;
            //this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            //this.gMapControl1.RoutesEnabled = true;
            //this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            //this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            //this.gMapControl1.Size = new System.Drawing.Size(150, 150);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            // 
            // GoogleMap
            // 
            this.AddChild(this.gMapControl1);
            this.Name = "GoogleMap";
            //this.ResumeLayout(false);
            this.gMapControl1.MapProvider = GoogleMapProvider.Instance;

            this.gMapControl1.Zoom = 16;

        }
    }
}
