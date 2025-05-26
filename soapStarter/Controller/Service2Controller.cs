using Microsoft.AspNetCore.Mvc;
using soapStarter.ConsumerTestScripts.SOAP;
using soapStarter.Model;
using soapStarter.SOAP.Controllers;
using soapStarter.SOAP.Model;

namespace soapStarter.Controller;

[SOAPController(SOAPVersion.V1_2)]
public class Service2Controller(
    ILogger<Service2Controller> logger,
    IWebHostEnvironment env) : SOAPControllerBase(logger, env)
{
    private static readonly string[] summaries = [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];
    private readonly ILogger<Service2Controller> _logger = logger;

    [HttpPost]
    public IActionResult Post(SOAP1_2RequestEnvelope env)
    {
        var res = CreateSOAPResponseEnvelope();
        res.Body.GetWeatherForecastResponse = new GetWeatherForecastResponse()
        {
            WeatherForecasts = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            }).ToArray()
        };
        return Ok(res);
    }
}
