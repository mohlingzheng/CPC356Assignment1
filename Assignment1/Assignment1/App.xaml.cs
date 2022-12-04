using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment1
{
    public partial class App : Application
    {
        string dbPath => FileAccessHelper.GetLocalFilePath("record.db3");
        
        public static AppsRepository GameRepo { get; private set; }
        public App()
        {
            InitializeComponent();

            GameRepo = new AppsRepository(dbPath);

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
