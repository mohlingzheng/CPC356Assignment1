using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Assignment1.Pages;
using Rg.Plugins.Popup.Services;

namespace Assignment1.Pages
{
    [DesignTimeVisible(true)]
    public partial class Record : ContentPage
    {
        public Record()
        {
            InitializeComponent();
        }

        public async void OnGetButtonClicked(object sender, EventArgs args)
        {
            //statusMessage.Text = "";
            List<Records> people = App.GameRepo.GetAllGame();
            gameList.ItemsSource = people;
        }

        public async void OnDeleteButtonClicked(object sender, EventArgs args)
        {
            //statusMessage.Text = "";
            App.GameRepo.DeleteGame();
        }
    }
}