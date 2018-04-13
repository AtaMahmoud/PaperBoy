﻿using System;
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
            this.BindingContext = App.viewModel.CurrentUser;
            articleCounterSlider.Value = 10;
            categoryPicker.SelectedIndex = 1;
        }
    }
}