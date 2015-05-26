using MoviesApp.Common;
using MoviesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MoviesApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IndexPage : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        public CollectionViewModel ViewModel { get; set; }
        public IndexPage()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            this.NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            if (ViewModel == null)
            {
                ViewModel = new CollectionViewModel();
                await ViewModel.ReadDataFromWebAsync();

                ProgressRing.Visibility = Visibility.Collapsed;
                var temp = ViewModel.DictionaryOfEpisodes;
                for (int i = 1; i < 7; i++)
                {
                    AddHubSections(temp, i);
                }
                Hub1.Visibility = Visibility.Visible;
            }
            else
            { } 
        }

        private void AddHubSections(Dictionary<Tuple<int, int>, Movie> temp, int i)
        {
            List<Movie> tempList = new List<Movie>();
            foreach (var episode in temp)
            {
                if (episode.Key.Item1 == i)
                {
                    tempList.Add(episode.Value);
                }
            }
            Hub1.Sections.Add(new HubSection()
                {
                    Header = "Season: " + tempList[0].Season,
                    DataContext = tempList,
                    Tag = tempList[0].Season,
                    HeaderTemplate = Resources["DefaultHeaderTemplate"] as DataTemplate,
                    ContentTemplate = Resources["DefaultContentTemplate"] as DataTemplate
                });
            //HubSection_1.Header = "Season: " + tempList[0].Season;
            //HubSection_1.DataContext = tempList;
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var episode = ((Movie)e.ClickedItem);
            if (!Frame.Navigate(typeof(ItemPage), episode))
            {
                throw new Exception("NavigationFailedExceptionMessage");
            }
        }
    }
}
