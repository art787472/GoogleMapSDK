using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Models
{
    public class Place
    {
        public Location Location { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public float Rating { get; set; }
        public string Photo_Reference { get; set; }
    }
}
