using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PaperBoy.Droid;
using PaperBoy.Droid.DependencyServices;
using PaperBoy.Interfaces;
using Xamarin.Forms;

[assembly:Dependency(typeof(PlatformLabel))]
namespace PaperBoy.Droid.DependencyServices
{
    public class PlatformLabel : IPlatformLabel
    {
        public PlatformLabel()
        {

        }
        public static void Init() { }
        public string GetLabel()
        {
            return "Android";
        }

        public string GetLabel(string additionalLabel)
        {
            return $"{additionalLabel} Android";
        }

        public string GetLabel(string additionalLabel, bool addOsVersion)
        {
            string label = (addOsVersion) ? label = $"{additionalLabel} Android {GetOsVersion()}" : $"{additionalLabel} Android";
            return label;
        }
        private string GetOsVersion()
        {
            return Build.VERSION.Release;
        }
    }
}