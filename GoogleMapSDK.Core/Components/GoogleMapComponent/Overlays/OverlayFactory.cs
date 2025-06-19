using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.Component.GoogleMapComponent.Overlays
{
    class OverLayFactory
    {

        public static AOverlay Create(OverlayType type)
        {
            AOverlay overlay = null;
            switch (type)
            {

                case OverlayType.Marker:
                    overlay = new MarkerOverlay();
                    break;
                case OverlayType.Route:
                    overlay = new RouteOverlay();
                    break;
            }
            return overlay;
        }


    }
}
