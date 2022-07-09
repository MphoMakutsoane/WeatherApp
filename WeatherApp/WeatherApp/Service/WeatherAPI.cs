
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using System.Net.Http;
using WeatherApp.Service;
using WeatherApp.Models;

namespace WeatherApp.Service
{
    public class WeatherAPI
    {
        public async Task<OpenWeatherData> GetDailyOpenWeather()
        {

            var data = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (data != PermissionStatus.Granted)
            {
                var newdata = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }

            var location = await Geolocation.GetLocationAsync();
            var latitude = location.Latitude;
            var longitude = location.Longitude;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            string apiURL = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&units=metric&appid=1155f59193ae652637edd91ca8f435dc";
            var response = await client.GetStringAsync(apiURL);

            var weather = JsonConvert.DeserializeObject<OpenWeatherData>(response);
            return weather;
        }
    }
}
