using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaperBoy.Common.Commands;
using PaperBoy.Models;
using PaperBoy.Models.News;
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
            this.BindingContext = App.viewModel;
            base.OnAppearing();
        }
        public void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            new NavigateToDetailCommand().Execute(e.Item as NewsInformation);
        }
    }
}