using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET.WindowsForms;
using static GoogleMapSDK.Contract.ComponentContract.GoogleMapContract;

namespace GoogleMapSDK.Core.Component.GoogleMapComponent.Overlays
{
    public abstract class AOverlay : IOverlay
    {
        private static Dictionary<string, GMapOverlay> overlays = new Dictionary<string, GMapOverlay>();
        public GMapControl gMap;
        public abstract void Add(object m);
        public abstract void Add(object m, string id);
        public abstract void AddRange(object[] m);
        public abstract void AddRange(object[] m, string id);

        protected GMapOverlay GetOverlay(string overLayId = "", bool clear = false)
        {
            overLayId = String.IsNullOrEmpty(overLayId) ? "default" : overLayId;

            if (overlays.TryGetValue(overLayId, out GMapOverlay overlay))
            {
                if (clear)
                {
                    overlay.Clear();
                }
                return overlay;
            }
            GMapOverlay newOverlay = new GMapOverlay(overLayId);
            overlays[overLayId] = newOverlay;
            return newOverlay;

        }
    }
}
