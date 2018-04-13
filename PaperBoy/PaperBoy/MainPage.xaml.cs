using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;

namespace PaperBoy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : TabbedPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            CrossConnectivity.Current.ConnectivityChanged += OnConnectivityChannged;
            base.OnAppearing();
        }

        private void OnConnectivityChannged(object sender, ConnectivityChangedEventArgs e)
        {
            //TODO: Method Impilimentation
        }
       
        private async void OnSettingsClicked(object sender,EventArgs e)
        {
            await Navigation.PushAsync(new Pages.SettingPage());
        }
        private async void OnStyleTestClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.TestingPage());
        }
    }
}
