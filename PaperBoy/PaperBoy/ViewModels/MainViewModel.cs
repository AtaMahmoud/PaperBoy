using PaperBoy.Common;
using PaperBoy.Models.News;
using PaperBoy.Models;
using PaperBoy.Models.Trending;
using PaperBoy.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PaperBoy.ViewModels
{
    public class MainViewModel:ObservableBase
    {
        private ObservableCollection<NewsInformation> _worldNews;
        public ObservableCollection<NewsInformation> WorldNews
        {
            get => _worldNews;
            set { SetProperty(ref this._worldNews, value); }
        }

        private ObservableCollection<NewsInformation> _technologyNews;
        public ObservableCollection<NewsInformation> TechnologyNews
        {
            get => _technologyNews;
            set { SetProperty(ref this._technologyNews,value); }
        }

        private ObservableCollection<NewsInformation> _trendingNews;
        public ObservableCollection<NewsInformation>TrendingNews
        {
            get => _trendingNews;
            set { SetProperty(ref this._trendingNews,value); }
        }

        private UserInformation _currentUser;
        public UserInformation CurrentUser
        {
            get => _currentUser;
            set { SetProperty(ref this._currentUser,value); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set { SetProperty(ref this._isBusy, value); }
        }

        private string _platformLabel;
        public string PlatformLabel
        {
            get => _platformLabel;
            set { SetProperty(ref this._platformLabel,value); }
        }

        private string _extendedPlatformLabel;
        public string ExtendedPlatformLabel
        {
            get => _extendedPlatformLabel;
            set { SetProperty(ref this._extendedPlatformLabel, value); }
        }
        public MainViewModel()
        {
            WorldNews = new ObservableCollection<NewsInformation>();
            TechnologyNews = new ObservableCollection<NewsInformation>();
            TrendingNews = new ObservableCollection<NewsInformation>();

            CurrentUser = new UserInformation()
            {
                DisplayName = "Ata Mahmoud",
                BioContent = "Egyptian Computer scienece student and Xamarin developer"
            };
        }

        public async void RefreshNewsAsync()
        {
            this.IsBusy = true;

            await RefreshWorldNewsAsync();
            await RefreshTechnologyNewsAsync();
            await RefreshTrendingNewsAsync();

            this.IsBusy = false;
        }

        public async Task RefreshTrendingNewsAsync()
        {
            TrendingNews.Clear();

            var trendingNews = await NewsHelper.GetTrendingAsync();
            
            foreach (var item in trendingNews)
            {
                TrendingNews.Add(item);
            }
        }

        public async Task RefreshTechnologyNewsAsync()
        {
            TechnologyNews.Clear();

            var technologyNews = await NewsHelper.GetByCategoryAsync(NewsCategoryType.ScienceAndTechnology);

            foreach (var item in technologyNews)
            {
                TechnologyNews.Add(item);
            }
        }

        public async Task RefreshWorldNewsAsync()
        {
            WorldNews.Clear();

            var worldNews = await NewsHelper.GetByCategoryAsync(NewsCategoryType.World);

            foreach (var item in worldNews)
            {
                WorldNews.Add(item);
            }
        }
    }
}
