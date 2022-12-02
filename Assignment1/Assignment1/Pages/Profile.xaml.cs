using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            daysCreated.Text = (Convert.ToInt32(daysC.TotalDays)).ToString() + " days";
        }
    }
}