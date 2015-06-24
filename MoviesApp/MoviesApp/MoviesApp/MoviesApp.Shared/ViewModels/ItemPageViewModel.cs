using MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesApp.ViewModels
{
    public class ItemPageViewModel : ViewModelBase
    {
        private Episode episode;

        public Episode Episode
        {
            get { return episode; }
            set 
            {
                if (value != episode)
                {
                    episode = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public event EventHandler PlayRequested;

        private void Play()
        {
            if (PlayRequested != null)
            {
                this.PlayRequested(this, EventArgs.Empty);
            }
        }

        //MediaElement player;
        //Episode tempEpisode;
    }
}
