using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET.WindowsForms;

namespace GoogleMapSDK.Core.Component.GoogleMapComponent.Overlays
{
    public class MarkerOverlay : AOverlay
    {

        public MarkerOverlay() { }
        public MarkerOverlay(GMapControl gmapControl)
        {
            this.gMap = gmapControl;
        }




        public override void Add(object m)
        {
            var overlay = this.GetOverlay("marker");
            var marker = (GMapMarker)m;
            overlay.Markers.Add(marker);
            gMap.Overlays.Clear();
            gMap.Overlays.Add(overlay);
        }

        public override void Add(object m, string id)
        {
            var overlay = this.GetOverlay(id);
            var marker = (GMapMarker)m;
            overlay.Markers.Add((GMapMarker)m);
            gMap.Overlays.Add(overlay);
        }

        public override void AddRange(object[] m)
        {
            var overlay = this.GetOverlay("marker", true);
            var markers = m.Select(x => (GMapMarker)x);
            foreach (var marker in markers)
            {
                overlay.Markers.Add(marker);
            }

            gMap.Overlays.Clear();
            gMap.Overlays.Add(overlay);
        }

        public override void AddRange(object[] m, string id)
        {
            throw new NotImplementedException();
        }
    }
}
