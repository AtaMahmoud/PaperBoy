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
	public partial class WorldPage : ContentPage
	{
		public WorldPage ()
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
            listViewTest.IsRefreshing = true;
            var news = await Helpers.NewsHelper.GetTrendingAsync();
            listViewTest.ItemsSource = news;
            listViewTest.IsRefreshing = false;
        }
    }
}