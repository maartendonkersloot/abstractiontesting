using abstractests.Domain;
using abstractests.Models;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Security.Cryptography;
using abstractests.Validators;
using abstractests.helpers;

namespace abstractests.Controllers
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

       

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([ModelBinder(typeof(MethodRequestBinder))][FromBody] RecordSetBase employee)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AAARecord, AAARecordDomain>();
                cfg.CreateMap<ARecord, ARecordDomain>();

                cfg.CreateMap<baseRecord, baseRecordDomain>().IncludeAllDerived();
                cfg.CreateMap<RecordSetBase, RecordSetBaseDomain>();
            });

            truevalidator validationRules = new truevalidator();
            var aads = validationRules.Validate(employee);


            var mapper = new Mapper(configuration);
            var dest = mapper.Map<RecordSetBase, RecordSetBaseDomain>(employee);
            

            try
            {
                if (employee == null)
                    return BadRequest();

                return StatusCode(StatusCodes.Status200OK, dest);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            


            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
