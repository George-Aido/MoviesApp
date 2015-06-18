using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesApp.Models
{
    [JsonObject]
    public class Season
    {
        [JsonProperty (PropertyName = "Episode")]
        public List<Episode> Episodes { get; set; }
        [JsonProperty(PropertyName = "NumberOfSeason")]
        public int NumberOfSeason { get; set; }
    }
}
