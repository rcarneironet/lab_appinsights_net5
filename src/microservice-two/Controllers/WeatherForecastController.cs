using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace microservice_two.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("weather")]
        public OkResult Get()
        {
            _logger.LogInformation("Call WeatherForecast - Get()");
            return Ok();
        }

        [HttpGet("forceerror")]
        public IActionResult ForceError()
        {
            _logger.LogError("Error forced!");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
