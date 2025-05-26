using Microsoft.AspNetCore.Mvc;
using ServiceReference; 

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase, IDisposable
{
    private readonly PersonClient _soapClient;

    public PersonController()
    {
        // Initialize SOAP client with generated endpoint configuration
        _soapClient = new PersonClient(PersonClient.EndpointConfiguration.BasicHttpBinding_IPerson);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var people = await _soapClient.GetAllAsync();
        return Ok(people);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var person = await _soapClient.GetByIdAsync(id);
        if (person == null)
            return NotFound();
        return Ok(person);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Person person)
    {
        var addedPerson = await _soapClient.AddAsync(person);
        if (addedPerson == null)
            return BadRequest("Person could not be added.");
        return CreatedAtAction(nameof(Get), new { id = addedPerson.Id }, addedPerson);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Person person)
    {
        if (id != person.Id)
            return BadRequest("ID mismatch.");

        var updatedPerson = await _soapClient.UpdateAsync(id, person);
        if (updatedPerson == null)
            return NotFound();

        return Ok(updatedPerson);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _soapClient.DeleteAsync(id);
        if (!success)
            return NotFound();
        return NoContent();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
