using Microsoft.AspNetCore.Mvc;
using MyMovieDBLib;
using System;
using System.Collections.Generic;
using System.Linq;
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
            string result = resp.Content.ReadAsStringAsync().Result;
            return result;
        }

        //api/movie/byName?movieName=naruto&userId=4CABA58F-F374-4362-838F-3075D345E1E6
        [HttpGet("byName")]
        public async Task<string> GetByNameAsync(string movieName, string userId)
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
            string result = resp.Content.ReadAsStringAsync().Result;
            return result;
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
