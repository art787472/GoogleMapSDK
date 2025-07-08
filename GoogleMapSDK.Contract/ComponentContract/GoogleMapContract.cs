using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GoogleMapSDK.Contract.Models;

namespace GoogleMapSDK.Contract.ComponentContract
{
    public class GoogleMapContract
    {
        public interface IGoogleMap
        {
            void AddMarker(Place place);
            void AddMarker(Place place, string overlayId);
            void RemoveMarker(Place place);
            void AddMarkers(List<Place> places);
            void AddMarkers(List<Place> places, bool enableTooltip = true);
            //void AddMarkers(List<Place> places, List<GMapToolTip> toolTips);
            void MovePosition(Location location);
            void MovePosition(double lat, double lng);
            void AddRoutes(List<Place> places);
            void RemoveRoutes(MapRoute route);
        }

        public interface IOverlay
        {
           void Add(object m);
            void Add(object m, string id);
            void AddRange(object[] m);
            void AddRange(object[] m, string id);
        }
    }
}
