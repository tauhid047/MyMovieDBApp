using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieDBLib
{
    public class MyMovieDBClient : IDisposable
    {
        private RestClient _client;
        public string ApiKey { get; private set; }

        public MyMovieDBClient(string baseUrl, string apiKey, bool useSsl = true)
        {
            Initialize(baseUrl, useSsl, apiKey);
        }

        private void Initialize(string baseUrl, bool useSsl, string apiKey)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new ArgumentException("baseUrl");

            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("apiKey");

            ApiKey = apiKey;

            if (baseUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
                baseUrl = baseUrl.Substring("http://".Length);
            else if (baseUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                baseUrl = baseUrl.Substring("https://".Length);

            string httpScheme = useSsl ? "https" : "http";
            _client = new RestClient(new Uri(string.Format("{0}://{1}/", httpScheme, baseUrl)));
            _client.AddDefaultQueryString("api_key", apiKey);
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
