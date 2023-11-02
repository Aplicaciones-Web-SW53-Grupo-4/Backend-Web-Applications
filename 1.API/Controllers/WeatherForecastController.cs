using Microsoft.AspNetCore.Mvc;

namespace _1.API.Controllers
{
    /// <summary>
    /// Controller for fetching weather forecast data.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        // Array of different weather summaries
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        /// <summary>
        /// Constructor to initialize the logger for WeatherForecastController.
        /// </summary>
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Retrieves a list of weather forecasts.
        /// </summary>
        /// <remarks>Returns an array of WeatherForecast objects.</remarks>
        /// <returns>An array of WeatherForecast objects.</returns>
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            // Generate a list of weather forecasts
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    // Set the date to the next five days
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    // Generate random temperature values
                    TemperatureC = Random.Shared.Next(-20, 55),
                    // Select a random summary from the predefined list
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }
}