using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GoogleMapSDK.Core.Component.GoogleMapComponent.Model;
using GoogleMapSDK.Core.Component.GoogleMapComponent.Overlays;
using Location = GoogleMapSDK.Core.Component.GoogleMapComponent.Model.Location;

namespace GoogleMapSDK.Core.GoogleMapComponent.GMap.Control
{
    public class GoogleMap : GMapControl
    {
        
        private AOverlay MarkerOverlay = OverLayFactory.Create(OverlayType.Marker);
        private AOverlay RouteOverlay = OverLayFactory.Create(OverlayType.Route);

        public GoogleMap()
        {
            this.MapProvider = GoogleMapProvider.Instance;
            MarkerOverlay.gMap = this;
            RouteOverlay.gMap = this;
            this.MinZoom = 10;
            this.MaxZoom = 20;
            this.Zoom = 16;
            this.DragButton = System.Windows.Forms.MouseButtons.Left;
            this.MouseWheelZoomEnabled = true;
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
            this.Zoom = 20;
            this.Position = new PointLatLng(location.Lat, location.Lng);
        }

        public void MovePosition(double lat, double lng)
        {

            this.Position = new PointLatLng(lat, lng);
        }

        public void AddRoutes(GMapRoute route)
        {
            RouteOverlay.Add(route);
        }

        public void RemoveRoutes(GMapRoute route)
        {

        }
    }
}
