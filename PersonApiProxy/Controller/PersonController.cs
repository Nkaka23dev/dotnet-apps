using Microsoft.AspNetCore.Mvc;
using ServiceReference;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase, IDisposable
{
    private readonly BenefitServiceClient _soapClient;

    public PersonController()
    {
        // Initialize SOAP client with generated endpoint configuration
        _soapClient = new BenefitServiceClient(BenefitServiceClient.EndpointConfiguration.BasicHttpBinding_IBenefitService);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var people = await _soapClient.GetAllBenefitsAsync();
        return Ok(people);
    }

    // [HttpGet("{id}")]
    // public async Task<IActionResult> Get(int id)
    // {
    //     var person = await _soapClient.Get
    //     if (person == null)
    //         return NotFound();
    //     return Ok(person);
    // }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] BenefitContract benefit)
    {
        var addedPerson = await _soapClient.CreateBenefitAsync(benefit);
        if (addedPerson == null)
            return BadRequest("Person could not be added.");
        return Ok("Created");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateBenefit benefit)
    {
        var updatedPerson = await _soapClient.UpdateBenefitAsync(id, benefit);
        if (updatedPerson == null)
            return NotFound();

        return Ok(updatedPerson);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _soapClient.DeleteBenefitAsync(id);
        return NoContent();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
