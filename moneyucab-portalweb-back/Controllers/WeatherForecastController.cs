using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using moneyucab_portalweb_back.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace moneyucab_portalweb_back.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable</*WeatherForecast*/Saldo> Get()
        {
            /*var rng = new Random();*/
            return Enumerable.Range(1, 1).Select(index => new /*WeatherForecast*/ Saldo
            {
                /*Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]*/
                saldoEnCuenta = 32
            })
            .ToArray();
        }
    }
}
