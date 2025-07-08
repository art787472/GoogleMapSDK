using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.Contract.Models;


namespace GoogleMapSDK.Contract.API.Utility
{
    public static class PolylineDecoder
    {
        public static IEnumerable<LatLng> Decode(string value)
        {
            //decode algorithm adapted from saboor awan via codeproject:
            //http://www.codeproject.com/Tips/312248/Google-Maps-Direction-API-V3-Polyline-Decoder
            //note the Code Project Open License at http://www.codeproject.com/info/cpol10.aspx

            if (value == null || value == "") return new List<LatLng>(0);

            char[] polylinechars = value.ToCharArray();
            int index = 0;

            int currentLat = 0;
            int currentLng = 0;
            int next5bits;
            int sum;
            int shifter;

            List<LatLng> poly = new List<LatLng>();

            while (index < polylinechars.Length)
            {
                // calculate next latitude
                sum = 0;
                shifter = 0;
                do
                {
                    next5bits = (int)polylinechars[index++] - 63;
                    sum |= (next5bits & 31) << shifter;
                    shifter += 5;
                } while (next5bits >= 32 && index < polylinechars.Length);

                if (index >= polylinechars.Length)
                    break;

                currentLat += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                //calculate next longitude
                sum = 0;
                shifter = 0;
                do
                {
                    next5bits = (int)polylinechars[index++] - 63;
                    sum |= (next5bits & 31) << shifter;
                    shifter += 5;
                } while (next5bits >= 32 && index < polylinechars.Length);

                if (index >= polylinechars.Length && next5bits >= 32)
                    break;

                currentLng += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);
                LatLng point = new LatLng(
                    latitude: Convert.ToDouble(currentLat) / 100000.0,
                    longitude: Convert.ToDouble(currentLng) / 100000.0
                );
                poly.Add(point);
            }

            return poly;
        }
    }
}
