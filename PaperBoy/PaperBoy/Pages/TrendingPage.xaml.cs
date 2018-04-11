using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PaperBoy.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TrendingPage : ContentPage
	{
		public TrendingPage ()
		{
			InitializeComponent ();
            
        }
        protected override void OnAppearing()
        {
            LoadNewsAsync();
            base.OnAppearing();
        }

        private async void LoadNewsAsync()
        {
            newsListView.IsRefreshing = true;
            var news = await Helpers.NewsHelper.GetTrendingAsync();
            BindingContext = news;
            newsListView.IsRefreshing = false;
        }
    }
}