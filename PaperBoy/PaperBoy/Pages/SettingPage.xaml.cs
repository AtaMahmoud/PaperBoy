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
	public partial class SettingPage : ContentPage
	{
		public SettingPage ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            //InitializaeSetting();
            base.OnAppearing();
        }
        
        //private void InitializaeSetting()
        //{
        //    displayNameEntry.Text = "Ata Mahmoud";
        //    bioEditor.Text = "Egyptian Computer Scienece Student and Software Engingeer";
        //    articleCounterSlider.Value = 10;
        //    categoryPicker.SelectedIndex = 1;
        //}
    }
}