using MoviesApp.Models;
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
        //private Dictionary<Tuple<int, int>, Movie> _dictionaryOfEpisodes;
        private List<Season> _seasonList;

        public List<Season> SeasonList
        {
            get { return _seasonList; }
            set 
            {
                if (value != _seasonList)
                {
                    _seasonList = value;
                    NotifyPropertyChanged();
                }
            }
        }

        
        public async Task ReadDataFromWebAsync()
        {
            var client = new HttpClient();

            var response = await client.GetAsync(new Uri("https://api.myjson.com/bins/32jsw"));
            switch ((int)(response.StatusCode))
            {
                case 200:
                    var stream = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<RootObject>(stream);
                    break;
                    //return result;
                case 498:
                    // invalid token
                    throw new Exception();
                //default:
                    //return null;
            }
        }

        //public async Task ReadDataFromWebAsync()
        //{
        //    var client = new HttpClient();
        //    for (int i = 1; i < 7; i++)
        //    {
        //        for (int j = 1; j < 11; j++)
        //        {
        //            var respone = await client.GetAsync(new Uri(string.Format("http://www.omdbapi.com/?t=Game%20of%20Thrones&Season={0}&Episode={1}", i, j)));
        //            string _result = await respone.Content.ReadAsStringAsync();
        //            var movie = JsonConvert.DeserializeObject<Movie>(_result);

        //            //this.DictionaryOfEpisodes.Add(String.Format("Episode:{0}",j), movie);
        //            this.DictionaryOfEpisodes.Add(new Tuple<int, int>(Convert.ToInt16(movie.Season), Convert.ToInt16(movie.Episode)), movie);
        //        }
        //    }
        //}
    }
}
