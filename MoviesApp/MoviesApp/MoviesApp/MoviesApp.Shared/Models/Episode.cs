using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesApp.Models
{
    [JsonObject]
    public class Episode
    {
        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "Year")]
        public string Year { get; set; }

        [JsonProperty(PropertyName = "Rated")]
        public string Rated { get; set; }

        [JsonProperty(PropertyName = "Released")]
        public string Released { get; set; }

        [JsonProperty(PropertyName = "Season")]
        public string SeasonNumber { get; set; }

        [JsonProperty(PropertyName = "Episode")]
        public string EpisodeNumber { get; set; }

        [JsonProperty(PropertyName = "Runtime")]
        public string Runtime { get; set; }

        [JsonProperty(PropertyName = "Genre")]
        public string Genre { get; set; }

        [JsonProperty(PropertyName = "Director")]
        public string Director { get; set; }

        [JsonProperty(PropertyName = "Writer")]
        public string Writer { get; set; }

        [JsonProperty(PropertyName = "Actors")]
        public string Actors { get; set; }

        [JsonProperty(PropertyName = "Plot")]
        public string Plot { get; set; }

        [JsonProperty(PropertyName = "Language")]
        public string Language { get; set; }

        [JsonProperty(PropertyName = "Country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "Awards")]
        public string Awards { get; set; }

        [JsonProperty(PropertyName = "Poster")]
        public string Poster { get; set; }

        [JsonProperty(PropertyName = "Metascore")]
        public string Metascore { get; set; }

        [JsonProperty(PropertyName = "imdbRating")]
        public string imdbRating { get; set; }

        [JsonProperty(PropertyName = "imdbVotes")]
        public string imdbVotes { get; set; }

        [JsonProperty(PropertyName = "imdbID")]
        public string imdbID { get; set; }

        [JsonProperty(PropertyName = "seriesID")]
        public string seriesID { get; set; }

        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "Response")]
        public string Response { get; set; }
    }
}
