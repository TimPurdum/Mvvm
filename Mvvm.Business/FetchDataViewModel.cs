using Mvvm.Business.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace Mvvm.Business
{
    public class FetchDataViewModel : BaseViewModel
    {
        public FetchDataViewModel(WeatherForecastService forecastService)
        {
            _forecastService = forecastService;
            Title = "Weather forecast";
            Description = "This component demonstrates fetching data from a service.";
        }


        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }


        public string Description
        {
            get => _description;
            set => SetField(ref _description, value);
        }


        public IEnumerable<WeatherForecast> Forecasts
        {
            get => _forecasts; 
            set => SetField(ref _forecasts, value);
        }
        
        
        public List<string> ForecastHeaders => typeof(WeatherForecast).GetProperties().Select(p => 
            p.GetCustomAttribute<DisplayNameAttribute>(false)
            ?.DisplayName ?? p.Name).ToList();


        public async Task GetForecastAsync(DateTime now)
        {
            Forecasts = await _forecastService.GetForecastAsync(now);
        }


        private readonly WeatherForecastService _forecastService;
        private string _description;
        private string _title;
        private IEnumerable<WeatherForecast> _forecasts;
    }
}