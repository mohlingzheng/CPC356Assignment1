using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Pages;
using Xamarin.Forms;


namespace Assignment1
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Children.Add(new Profile());
            this.Children.Add(new Record());
            this.Children.Add(new Weather());
        }
    }
}
