using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GeneralApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool-Diego", "Mild", "Warm", "Balmy", "Hot-Rattis", "Sweltering", "Scorching"
        ];
        private readonly EnvironmentConfig _config;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptions<EnvironmentConfig> options)
        {
            _config = options.Value;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public Wrapper Get()
        {
            Wrapper wrapper = new()
            {
                Environment = _config.Name,
                WeatherForecastList = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
            .ToArray()
            };

            return wrapper;
        }
    }
}
