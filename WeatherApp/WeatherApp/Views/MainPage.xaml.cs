using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using Xamarin.Essentials;
using System.Net.Http;
using WeatherApp.Service;
using WeatherApp.Models;
using WeatherApp.ViewModel;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new WeatherViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var vm = BindingContext as WeatherViewModel;
            await vm.APIAsync();
        }

        
    }
}
