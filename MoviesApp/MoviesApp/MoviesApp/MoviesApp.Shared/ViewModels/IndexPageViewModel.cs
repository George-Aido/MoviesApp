using MoviesApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using MoviesApp.Util;

namespace MoviesApp.ViewModels
{
    public class IndexPageViewModel : ViewModelBase
    {
        private RootObject _seasonList;

        public RootObject SeasonList
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

        public async Task Init()
        {
            this.SeasonList = await DoReadDataFromWebAsync();
        }

        public async Task<RootObject> DoReadDataFromWebAsync()
        {
            SeasonList = new RootObject();

            var client = new HttpClient();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var response = await client.GetAsync(new Uri("https://api.myjson.com/bins/32jsw"));
            Debug.WriteLine("Response in: {0} ", stopWatch.ElapsedMilliseconds);
            stopWatch.Stop();
            switch ((int)(response.StatusCode))
            {
                case 200:
                    var stream = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<RootObject>(stream);
                    return result;
                case 498:
                    throw new Exception();
                default:
                    return null;
            }
        }
    }
}
