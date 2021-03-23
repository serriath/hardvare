using Hardvare.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hardvare.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IAuthorRepository _authorRepository;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IAuthorRepository authorRepository)
        {
            _logger = logger;
            _authorRepository = authorRepository;
        }

        [HttpGet("GetNewThings")]
        public Task<IEnumerable<WeatherForecast>> GetNewThings()
        {
            var rng = new Random();

            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });

            return Task.FromResult(result);
        }

        [HttpGet("GetMessage")]
        public Task<string> GetMessage()
        {
            var message = _authorRepository.GetMessage();

            return Task.FromResult(message);
        }
    }
}
