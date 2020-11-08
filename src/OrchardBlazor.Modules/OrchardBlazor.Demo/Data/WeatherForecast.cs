using System;

// Carl Says: The Data Folder is used in the default template to store this model
//      as well as WeatherForecastService, a Singleton service you can call to 
//      access weather data.
//      TIP: In a Blazor Webassembly application the client uses an HttpClient
//          to call an API controller

namespace OrchardBlazor.Demo.Data
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
