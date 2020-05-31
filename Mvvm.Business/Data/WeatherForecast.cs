using System;
using System.ComponentModel;


namespace Mvvm.Business.Data
{
    public class WeatherForecast
    {
        [DisplayName("Date")]
        public DateTime Date { get; set; }

        [DisplayName("Temp. (C)")]
        public int TemperatureC { get; set; }

        [DisplayName("Temp. (F)")]
        public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);

        [DisplayName("Summary")]
        public string Summary { get; set; }
    }
}