using ME_LlamadaApi.Model;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;
using System;
using System.Net.Http;
using System.Net.WebSockets;



namespace ME_LlamadaApi;

public partial class MainPage : ContentPage
{



    public MainPage()
    {
        InitializeComponent();
    }



    private void OnGetWeatherClicked_ME(object sender, EventArgs e)
    {
        string latitud = lat.Text;
        string longitud = lon.Text;
        using (var client = new HttpClient())
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?lat=" + latitud + "&lon=" + longitud + "&appid=c1301c7a5061ebfee5be304e14583dcd";



            var response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                var weatherData = JsonConvert.DeserializeObject<ClimaME>(content);
                weatherLabel.Text = weatherData.weather[0].description;
                Pais.Text = weatherData.sys.country;
                Ciudad.Text = weatherData.name;
            }
        }
    }
}

