using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Utility
{
    public static class Extension
    {
        public static Dictionary<string, string> ToDictionary(this object ob)
        {
            var dictionary = new Dictionary<string, string>();
            var properties = ob.GetType().GetProperties();
            foreach (var property in properties)
            {
                
                var value = property.GetValue(ob);
                if (value != null)
                {
                    dictionary.Add(property.Name.ToLower(), value.ToString());
                }
            }
            return dictionary;
        }
    }
}
