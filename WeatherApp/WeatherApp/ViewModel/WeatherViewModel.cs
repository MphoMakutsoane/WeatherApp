using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Service;

namespace WeatherApp.ViewModel
{
    public class WeatherViewModel
    {
        private IList<OpenWeatherData> _weatherList;

        public IList<OpenWeatherData> WeatherList
        {

            get
            {
                if (_weatherList == null)
                {
                    _weatherList = new ObservableCollection<OpenWeatherData>();
                }
                    return _weatherList;                     
                
            }
            set
            {
                _weatherList = value;
            }
        }

        public async Task APIAsync()
        {
            WeatherAPI weatherData = new WeatherAPI();
            var weather = await weatherData.GetDailyOpenWeather();
            WeatherList.Add(weather);
                 
        }
    }
}
