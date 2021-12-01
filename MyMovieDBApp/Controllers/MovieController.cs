using Microsoft.AspNetCore.Mvc;
using MyMovieDBApp.Models;
using MyMovieDBApp.Service.Interface;
using MyMovieDBApp.TheMovieDBModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MyMovieDBApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ISearchHistory _searchHistory;

        public MovieController(ISearchHistory searchHistory)
        {
            _searchHistory = searchHistory;
        }

        [HttpGet("{movieId:int}")]
        public async Task<string> GetByIdAsync(int movieId)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage();

            requestMessage.Method = HttpMethod.Get;
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = "https";
            uriBuilder.Host = TheMovieDBAPIConstants.Url;
            uriBuilder.Path = "movie/" + movieId;

            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["api_key"] = TheMovieDBAPIConstants.Key;
            uriBuilder.Query = query.ToString();
            requestMessage.RequestUri = uriBuilder.Uri;

            HttpClient client = new HttpClient();
            CancellationToken cancellationToken = default;
            HttpResponseMessage resp = await client.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);
            string json = resp.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<IEnumerable<SearchResult>>(json);
            return json;
        }

        //api/movie/byName?movieName=naruto&userId=2
        [HttpGet("byName")]
        public async Task<string> GetByNameAsync(string movieName, int userId)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage();

            requestMessage.Method = HttpMethod.Get;
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = "https";
            uriBuilder.Host = TheMovieDBAPIConstants.Url;
            uriBuilder.Path = "search/movie";

            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["api_key"] = TheMovieDBAPIConstants.Key;
            query["query"] = movieName;
            uriBuilder.Query = query.ToString();
            requestMessage.RequestUri = uriBuilder.Uri;

            HttpClient client = new HttpClient();
            CancellationToken cancellationToken = default;
            HttpResponseMessage resp = await client.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);

            string json = resp.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<SearchResult>(json);

            SearchHistory history = new SearchHistory
            {
                UserId = userId,
                KeyWord = movieName
            };

            _searchHistory.CreateSearchHistory(history);

            return json;
        }

        //[HttpGet("{name}")]
        //public async Task<string> GetByNameAsync(string name)
        //{
        //    HttpRequestMessage requestMessage = new HttpRequestMessage();

        //    requestMessage.Method = HttpMethod.Get;
        //    UriBuilder uriBuilder = new UriBuilder();
        //    uriBuilder.Scheme = "https";
        //    uriBuilder.Host = TheMovieDBAPIConstants.Url;
        //    uriBuilder.Path = "search/movie";

        //    var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        //    query["api_key"] = TheMovieDBAPIConstants.Key;
        //    query["query"] = name;
        //    uriBuilder.Query = query.ToString();
        //    requestMessage.RequestUri = uriBuilder.Uri;

        //    HttpClient client = new HttpClient();
        //    CancellationToken cancellationToken = default;
        //    HttpResponseMessage resp = await client.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);
        //    string result = resp.Content.ReadAsStringAsync().Result;
        //    return result;
        //}
    }
}
