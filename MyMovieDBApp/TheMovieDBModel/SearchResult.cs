using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyMovieDBApp.TheMovieDBModel
{
    public class SearchResult
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        //[JsonProperty("results")]
        //public List<T> Results { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
        
        [JsonProperty("results")]
        public IList<Results> Results { get; set; }
    }
}
