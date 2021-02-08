using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Capstone.Models.LocationAPI
{
    public class ZipCodeApi
    {
        private static readonly string apiKey = ConfigurationManager.AppSettings["zipApiKey"];
        public LocationResponse findNearZip(string zip, double dist)
        {
            var url = $"https://www.zipcodeapi.com/rest/{apiKey}/radius.json/{zip}/{dist}/miles";
            var httpclient = new HttpClient();
            var response = httpclient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            var responseJson = response.Content.ReadAsStringAsync().Result;
            var locationResponse = JsonConvert.DeserializeObject<LocationResponse>(responseJson);
            return locationResponse;
        }
    }
}