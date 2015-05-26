using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.ViewModels
{
    public class CollectionViewModel : ViewModelBase
    {
        private Dictionary<Tuple<int, int>, Movie> _dictionaryOfEpisodes;

        public Dictionary<Tuple<int, int>, Movie>  DictionaryOfEpisodes
        {
            get { return _dictionaryOfEpisodes; }
            set
            {
                if (value != _dictionaryOfEpisodes)
                {
                    _dictionaryOfEpisodes = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public CollectionViewModel()
        {
            this.DictionaryOfEpisodes = new Dictionary<Tuple<int, int>, Movie>();
        }

        public async Task ReadDataFromWebAsync()
        {
            var client = new HttpClient();
            for (int i = 1; i < 7; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    var respone = await client.GetAsync(new Uri(string.Format("http://www.omdbapi.com/?t=Game%20of%20Thrones&Season={0}&Episode={1}", i, j)));
                    string _result = await respone.Content.ReadAsStringAsync();
                    var movie = JsonConvert.DeserializeObject<Movie>(_result);

                    //this.DictionaryOfEpisodes.Add(String.Format("Episode:{0}",j), movie);
                    this.DictionaryOfEpisodes.Add(new Tuple<int, int>(Convert.ToInt16(movie.Season), Convert.ToInt16(movie.Episode)), movie);
                }
            }
        }
    }
}
