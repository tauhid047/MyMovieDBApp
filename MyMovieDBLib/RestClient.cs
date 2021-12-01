using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MyMovieDBLib
{
    internal class RestClient : IDisposable
    {
        internal Uri BaseUrl { get; }
        internal List<KeyValuePair<string, string>> DefaultQueryString { get; }
        internal HttpClient HttpClient { get; private set; }
        public RestClient(Uri baseUrl)
        {
            BaseUrl = baseUrl;
            DefaultQueryString = new List<KeyValuePair<string, string>>();
        }
        public void AddDefaultQueryString(string key, string value)
        {
            DefaultQueryString.Add(new KeyValuePair<string, string>(key, value));
        }
        public void Dispose()
        {
            HttpClient?.Dispose();
        }
    }
}
