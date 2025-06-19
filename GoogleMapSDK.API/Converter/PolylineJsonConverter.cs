using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using GoogleMapSDK.API.Models;
using GoogleMapSDK.API.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static GoogleMapSDK.API.Models.ResponseModels.DirectionsResponseModel;

namespace GoogleMapSDK.API.Converter
{
    public class PolylineJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if(objectType == typeof(List<LatLng>))
                return true;
            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);
            string points = obj["points"]?.Value<string>() ?? string.Empty;
            var lngLats = PolylineDecoder.Decode(points);
            return lngLats;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
