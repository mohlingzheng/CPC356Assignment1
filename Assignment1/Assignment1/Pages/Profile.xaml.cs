using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment1.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
            DateTime dt = DateTime.Now;
            DateTime dateCreated = new DateTime(2022, 11, 1);
            var daysC = dt - dateCreated;
            daysCreated.Text = "Created " + (Convert.ToInt32(daysC.TotalDays)).ToString() + " days";
        }

        private async void LinkToInstagram(object sender, EventArgs args)
        {
            string uri = "https://www.instagram.com/moh_l_z/?hl=en";
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

        private async void LinkToFacebook(object sender, EventArgs args)
        {
            string uri = "https://www.facebook.com/moh.lingzheng.9?mibextid=ZbWKwL";
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
    }
}