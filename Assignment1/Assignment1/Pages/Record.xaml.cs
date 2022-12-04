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
            List<Records> people = App.GameRepo.GetAllGame();
            gameList.ItemsSource = people;
        }

        public async void AddNewButtonClick(object sender, EventArgs args)
        {
            await PopupNavigation.Instance.PushAsync(new FormPage());
        }

        public async void OnGetButtonClicked(object sender, EventArgs args)
        {
            List<Records> people = App.GameRepo.GetAllGame();
            gameList.ItemsSource = people;
        }

        public async void OnDeleteButtonClicked(object sender, EventArgs args)
        {
            string target = ((MenuItem)sender).CommandParameter.ToString();
            bool ans = await DisplayAlert("Are you sure you want to delete it?", "", "Yes", "No");
            if (ans)
            {
                App.GameRepo.DeleteGame(target);
            }
        }

    }
}