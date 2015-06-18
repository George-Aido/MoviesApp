using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesApp.Models
{
    [JsonObject]
    public class RootObject
    {
        [JsonProperty(PropertyName = "Season")]
        public List<Season> SeasonList { get; set; }
    }
}
