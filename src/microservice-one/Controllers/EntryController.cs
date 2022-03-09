using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;

namespace microservice_one.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntryController : ControllerBase
    {
        private readonly ILogger<EntryController> _logger;
        public EntryController(ILogger<EntryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public OkResult Get()
        {
            _logger.LogInformation("Call EntryController - Get()");
            var httpClient = new HttpClient();

            try
            {
                //string uri = "https://localhost:44387/WeatherForecast/weather";
                string uri = "https://csa-servicetwo.azurewebsites.net/WeatherForecast/weather";
                httpClient.GetAsync(uri);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error calling _service.GetWeather() on EntryController" + ex?.Message);
                throw new Exception("Error calling _service.GetWeather() on EntryController");
            }
            finally
            {
                httpClient.Dispose();
            }
            return Ok();
        }
    }
}
