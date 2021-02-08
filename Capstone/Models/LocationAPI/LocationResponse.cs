using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Models.LocationAPI
{
    public class LocationResponse
    {
        public IEnumerable<LocationResponseItem> zip_codes { get; set; }

    }
}