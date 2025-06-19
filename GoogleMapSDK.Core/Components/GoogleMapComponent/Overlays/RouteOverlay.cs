using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET.WindowsForms;

namespace GoogleMapSDK.Core.Component.GoogleMapComponent.Overlays
{
    public class RouteOverlay : AOverlay
    {


        public RouteOverlay() { }
        public RouteOverlay(GMapControl gmapControl)
        {
            this.gMap = gmapControl;
        }
        public override void Add(object m)
        {
            var overlay = this.GetOverlay("route", true);

            var route = (GMapRoute)m;

            overlay.Routes.Add(route);
            this.gMap.Overlays.Add(overlay);
        }

        public override void Add(object m, string id)
        {
            var overlay = this.GetOverlay(id);
            var route = (GMapRoute)m;
            overlay.Routes.Add(route);
            this.gMap.Overlays.Add(overlay);
        }

        public override void AddRange(object[] m)
        {
            throw new NotImplementedException();
        }

        public override void AddRange(object[] m, string id)
        {
            throw new NotImplementedException();
        }
    }
}
