using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MoviesApp.Models
{
    [JsonObject]
    public class RootObject
    {
        [JsonProperty(PropertyName = "Season")]
        public ObservableCollection<Season> SeasonList { get; set; }
    }
}
