using Newtonsoft.Json;

namespace MyMovieDBApp.TheMovieDBModel
{
    public class Genre
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
