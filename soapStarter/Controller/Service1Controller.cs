using Microsoft.AspNetCore.Mvc;

namespace soapStarter.Controller;


[ApiController]
[Route("[controller]")]
public class Service1Controller(ILogger<Service1Controller> logger) : ControllerBase
{
  private static readonly string[] summaries = [
     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
 ];
  private readonly ILogger<Service1Controller> _logger = logger;


  [HttpPost]
  [Produces("application/xml")]
  public IEnumerable<WeatherForecast> Post()
  {
    return Enumerable.Range(1, 5).Select(index =>
    new WeatherForecast
    {
      Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
      TemperatureC = Random.Shared.Next(-20, 55),
      Summary = summaries[Random.Shared.Next(summaries.Length)]
    }).ToArray();
  }
}
