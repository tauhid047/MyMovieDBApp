using Microsoft.AspNetCore.Mvc;
using MyMovieDBLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MyMovieDBApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<string> GetAsync()
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage();

            requestMessage.Method = HttpMethod.Get;
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = "https";
            uriBuilder.Host = TheMovieDBAPIConstants.Url;
            uriBuilder.Path = "movie/47964";
            uriBuilder.Query = "api_key=" + TheMovieDBAPIConstants.Key;

            requestMessage.RequestUri = uriBuilder.Uri;

            HttpClient client = new HttpClient();
            CancellationToken cancellationToken = default;
            HttpResponseMessage resp = await client.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);
            string result = resp.Content.ReadAsStringAsync().Result;
            return result;
        }
    }
}
