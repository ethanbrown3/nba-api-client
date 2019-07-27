using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace NbaStatsClient
{
    public class NbaApiClient
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient(string baseUrl="https://api.sportradar.us")
        {
            ApiClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
