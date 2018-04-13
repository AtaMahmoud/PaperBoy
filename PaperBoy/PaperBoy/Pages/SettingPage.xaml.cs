using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaperBoy.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PaperBoy.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingPage : ContentPage
	{
        public UserInformation currentUser { get; set; }
        public SettingPage ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            InitializaeSetting();
            base.OnAppearing();
        }

        private void InitializaeSetting()
        {
            this.currentUser = new UserInformation()
            {
                DisplayName= "Ata Mahmoud",
                BioContent= "Egyptian Computer Scienece Student and Software Engingeer"
            };
            this.BindingContext = currentUser;
            articleCounterSlider.Value = 10;
            categoryPicker.SelectedIndex = 1;
        }
    }
}