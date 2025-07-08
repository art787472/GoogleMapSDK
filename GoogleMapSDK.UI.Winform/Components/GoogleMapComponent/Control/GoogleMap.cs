using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GoogleMapSDK.Contract.API;
using GoogleMapSDK.Contract.Models;

using GoogleMapSDK.Core.Component.GoogleMapComponent.Overlays;
using static GoogleMapSDK.Contract.ComponentContract.GoogleMapContract;
using Location = GoogleMapSDK.Contract.Models.Location;


namespace GoogleMapSDK.Core.GoogleMapComponent.GoogleMapComponent.Control
{
    public class GoogleMap : UserControl, IGoogleMap
    {
        
        private AOverlay MarkerOverlay = OverLayFactory.Create(OverlayType.Marker);
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private AOverlay RouteOverlay = OverLayFactory.Create(OverlayType.Route);

        public GoogleMap()
        {
            InitializeComponent();
            this.gMapControl1.MapProvider = GoogleMapProvider.Instance;
            MarkerOverlay.gMap = this.gMapControl1;
            RouteOverlay.gMap = this.gMapControl1;
            this.gMapControl1.MinZoom = 10;
            this.gMapControl1.MaxZoom = 20;
            this.gMapControl1.Zoom = 16;
            this.gMapControl1.DragButton = System.Windows.Forms.MouseButtons.Left;
            this.gMapControl1.MouseWheelZoomEnabled = true;
        }

        public void AddMarker(Place place)
        {
            GMapMarker m = new GMarkerGoogle(new PointLatLng(place.Location.Lat, place.Location.Lng), GMarkerGoogleType.red);
            m.ToolTipText = place.Name;
            m.ToolTip.Fill = new SolidBrush(Color.FromArgb(100, Color.Black));
            m.ToolTip.Foreground = Brushes.White;
            m.ToolTip.TextPadding = new Size(20, 50);
            m.Tag = place;
            MarkerOverlay.Add(m);

        }

        public void AddMarker(Place place, string overlayId)
        {
            GMapMarker m = new GMarkerGoogle(new PointLatLng(place.Location.Lat, place.Location.Lng), GMarkerGoogleType.red);
            m.ToolTipText = place.Name;
            m.ToolTip.Fill = new SolidBrush(Color.FromArgb(100, Color.Black));
            m.ToolTip.Foreground = Brushes.White;
            m.ToolTip.TextPadding = new Size(20, 50);
            m.Tag = place;
            MarkerOverlay.Add(m, overlayId);
        }

        public void RemoveMarker(Place place)
        {

        }

        public void AddMarkers(List<Place> places)
        {
            var markers = new List<GMapMarker>();
            foreach (Place place in places)
            {
                GMapMarker m = new GMarkerGoogle(new PointLatLng(place.Location.Lat, place.Location.Lng), GMarkerGoogleType.red);
                m.ToolTipText = place.Name;
                m.ToolTip.Fill = new SolidBrush(Color.FromArgb(100, Color.Black));
                m.ToolTip.Foreground = Brushes.White;
                m.ToolTip.TextPadding = new Size(20, 50);
                m.Tag = place;
                markers.Add(m);
            }
            MarkerOverlay.AddRange(markers.ToArray());
        }

        public void AddMarkers(List<Place> places, bool enableTooltip = true)
        {
            foreach (Place place in places)
            {
                GMapMarker m = new GMarkerGoogle(new PointLatLng(place.Location.Lat, place.Location.Lng), GMarkerGoogleType.red);
                if (enableTooltip)
                {
                    m.ToolTipText = place.Name;
                    m.ToolTip.Fill = new SolidBrush(Color.FromArgb(100, Color.Black));
                    m.ToolTip.Foreground = Brushes.White;
                    m.ToolTip.TextPadding = new Size(20, 50);

                }
                m.Tag = place;
                MarkerOverlay.Add(m);

            }


        }

        public void AddMarkers(List<Place> places, List<GMapToolTip> toolTips)
        {
            for (int i = 0; i < places.Count; i++)
            {
                var place = places[i];
                GMapMarker m = new GMarkerGoogle(new PointLatLng(place.Location.Lat, place.Location.Lng), GMarkerGoogleType.red);
                m.ToolTip = toolTips[i];
                m.Tag = place;
                MarkerOverlay.Add(m);
            }
        }

        public void MovePosition(Location location)
        {
            this.gMapControl1.Zoom = 20;
            this.gMapControl1.Position = new PointLatLng(location.Lat, location.Lng);
        }

        public void MovePosition(double lat, double lng)
        {

            this.gMapControl1.Position = new PointLatLng(lat, lng);
        }

        public void AddRoutes(List<Place> places)
        {
            var points = places.Select(x => new PointLatLng(x.Location.Lat, x.Location.Lng));
            GMapRoute route = new GMapRoute(points, "route");
            RouteOverlay.Add(route);
        }

        public void RemoveRoutes(MapRoute route)
        {

        }

        private void InitializeComponent()
        {
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(0, 0);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(150, 150);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            // 
            // GoogleMap
            // 
            this.Controls.Add(this.gMapControl1);
            this.Name = "GoogleMap";
            this.ResumeLayout(false);

        }
    }
}
