namespace GeneralApi
{
    public class Wrapper
    {
        public string Environment { get; set; }
        public IEnumerable<WeatherForecast> WeatherForecastList { get; set; }
    }
}
