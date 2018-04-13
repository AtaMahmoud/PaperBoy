using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaperBoy.ViewModels;
using Xamarin.Forms;

namespace PaperBoy
{
	public partial class App : Application
	{
        public static MainViewModel  viewModel{ get; set; }
        public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new PaperBoy.MainPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
