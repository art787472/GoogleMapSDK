using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET.WindowsPresentation;

namespace GoogleMapSDK.UI.WPF.Components.GoogleMapComponent.Overlays
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
                overlay.Add(marker);
                gMap.Markers.Clear();

                gMap.Markers.Add(marker);
                
            }

            public override void Add(object m, string id)
            {
                var overlay = this.GetOverlay(id);
                var marker = (GMapMarker)m;
                overlay.Add(marker);
                gMap.Markers.Add(marker);
            }

            public override void AddRange(object[] m)
            {
                var overlay = this.GetOverlay("marker", true);
                var markers = m.Select(x => (GMapMarker)x);
                foreach (var marker in markers)
                {
                    overlay.Add(marker);
                }

                gMap.Markers.Clear();
                foreach (var marker in markers)
                {
                    gMap.Markers.Add(marker);
                    
                }
                
            }

            public override void AddRange(object[] m, string id)
            {
                throw new NotImplementedException();
            }
        }
    }

