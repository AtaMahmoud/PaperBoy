using PaperBoy.Pages;
using PaperBoy.Models.News;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PaperBoy.Common.Commands
{
    public class NavigateToSettingsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void RaiseCamExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        public void Execute(object parameter)
        {
            NavigateAsync();
        }

        private async void NavigateAsync()
        {
            await App.MainNavigation.PushAsync(new Pages.SettingPage(),true);
        }
    }

    public class RefreshNewsCommand : ICommand
    {
        private bool _isBusy=false;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !_isBusy;
        }
        public void RaiseCanChange()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        public void Execute(object parameter)
        {
            RefreshNewsAsync((string)parameter);
        }
        public async void RefreshNewsAsync(string newsType)
        {
            this._isBusy = true;
            RaiseCanChange();
            App.viewModel.IsBusy = true;

            switch(newsType)
            {
                case "World":
                    await App.viewModel.RefreshWorldNewsAsync();
                    break;
                case "Trending":
                    await App.viewModel.RefreshTrendingNewsAsync();
                    break;
                case "Technology":
                    await App.viewModel.RefreshTechnologyNewsAsync();
                    break;
            }
            this._isBusy = false;
            RaiseCanChange();
            App.viewModel.IsBusy = false;
        }
    }

    public class NavigateToDetailCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Execute(object parameter)
        {
            NavigateToDetailAsync(parameter as NewsInformation);
        }

        private async void NavigateToDetailAsync(NewsInformation article)
        {
            await App.MainNavigation.PushAsync(new ItemDetailPage(article));
        }
    }
}
