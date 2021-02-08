using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Models.LocationAPI
{
    public class LocationResponseItem
    {
        public string zip_code { get; set; }
        public double distance { get; set; }
        public string city { get; set; }
        public string state { get; set; }
    }
}