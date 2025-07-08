using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET.WindowsPresentation;
using static GoogleMapSDK.Contract.ComponentContract.GoogleMapContract;

namespace GoogleMapSDK.UI.WPF.Components.GoogleMapComponent.Overlays
{
    public abstract class AOverlay : IOverlay
    {
        private static Dictionary<string, List<GMapMarker>> overlays = new Dictionary<string, List<GMapMarker>>();
        public GMapControl gMap;
        public abstract void  Add(object m);
        public abstract void Add(object m, string id);
        public abstract void AddRange(object[] m);
        public abstract void AddRange(object[] m, string id);

        protected List<GMapMarker> GetOverlay(string overLayId = "", bool clear = false)
        {
            overLayId = String.IsNullOrEmpty(overLayId) ? "default" : overLayId;

            if (overlays.TryGetValue(overLayId, out List<GMapMarker> overlay))
            {
                if (clear)
                {
                    overlay = new List<GMapMarker>();
                }
                return overlay;
            }
            List<GMapMarker> newOverlay = new List<GMapMarker>();
            overlays[overLayId] = newOverlay;
            return newOverlay;

        }

    }
}
