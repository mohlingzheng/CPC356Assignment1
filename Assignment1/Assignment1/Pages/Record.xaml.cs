using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Assignment1.Pages;

namespace Assignment1.Pages
{
    [DesignTimeVisible(true)]
    public partial class Record : ContentPage
    {
        public Record()
        {
            InitializeComponent();
        }

        public async void Button_Clicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";
            App.GameRepo.AddNewGame(newName.Text, newType.Text, newYear.Text, newVersion.Text);
            statusMessage.Text = App.GameRepo.StatusMessage;
        }

        public async void OnGetButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";
            List<Records> people = App.GameRepo.GetAllGame();
            gameList.ItemsSource = people;
        }

        public async void OnDeleteButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";
            App.GameRepo.DeleteGame();
        }
    }
}