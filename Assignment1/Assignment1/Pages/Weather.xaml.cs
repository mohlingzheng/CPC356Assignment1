using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Net.Http;


namespace Assignment1.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Weather : ContentPage
    {
        public Weather()
        {
            InitializeComponent();

            string datenow = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            lbldate.Text = datenow;

        }

        public class weather
        {
            public string Title
            {
                get;
                set;
            }
            public string Temperature
            {
                get;
                set;
            }
            public string Wind
            {
                get;
                set;
            }
            public string Humidity
            {
                get;
                set;
            }
            public string Visibility
            {
                get;
                set;
            }
            public string weathermain
            {
                get;
                set;
            }
            public string weatherdesc
            {
                get;
                set;
            }
            public string weathericon
            {
                get;
                set;
            }

            public weather()
            {
                this.Title = " ";
                this.Temperature = " ";
                this.Wind = " ";
                this.Humidity = " ";
                this.Visibility = " ";
                this.weathermain = " ";
                this.weatherdesc = " ";
                this.weathericon= " ";
            }
        }


        private async void btnGetWeather_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(entPinCode.Text))
            {
                weather weather = await GetWeather(entPinCode.Text);
                if (weather != null)
                {
                    txtLocation.Text = weather.Title;
                    txtTemperature.Text = weather.Temperature;
                    txtWind.Text = weather.Wind;
                    txtHumidity.Text = weather.Humidity;
                    txtweathermain.Text = weather.weathermain;
                    txtweatherdesc.Text = weather.weatherdesc;
                    imageSource.Source = weather.weathericon;
                    btnGetWeather.Text = "Search Again";
                }
            }
        }
        public static async Task<weather> GetWeather(string pinCode)
        {
            string key = "9b323a48d680fc62cb1dae00475c9381";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?zip=" + pinCode + ",my&appid=" + key + "&units=imperial";
            if (key != "9b323a48d680fc62cb1dae00475c9381")
            {
                throw new ArgumentException("Get you API key from openweathermap.org/appid and assign it in the 'key' variable.");
            }
            dynamic results = await getDataFromService(queryString).ConfigureAwait(false);
            if (results["weather"] != null)
            {
                weather weather = new weather();
                weather.Title = (string)results["name"];
                double temp = ((results["main"]["temp"] - 32) * 5 / 9);
                weather.Temperature = temp.ToString("#.#") + " ℃";
                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                weather.weathermain = (string)results.weather[0].main;
                weather.weatherdesc = (string)results.weather[0].description;
                weather.Wind = (string)results["wind"]["speed"] + " mph";
                weather.Humidity = (string)results["main"]["humidity"] + "%";
                weather.weathericon = "http://openweathermap.org/img/wn/" + (string)results.weather[0].icon + "@2x.png";
                return weather;
            }
            else
            {
                return null;
            }
        }

        public static async Task<dynamic> getDataFromService(string pQueryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(pQueryString);
            dynamic data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }
            return data;
        }



    }
}