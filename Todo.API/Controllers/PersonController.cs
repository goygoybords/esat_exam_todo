using Microsoft.AspNetCore.Mvc;
using Todo.Application.Common.Interfaces;
using Todo.Domain;

namespace Todo.API.Controllers;

public class PersonController(IPersonServices personServices) : ControllerBase
{
    private readonly IPersonServices _personServices = personServices;

    /// <summary>
    /// GET Person List
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var result = await _personServices.GetPersonListAsync(cancellationToken);
        return Ok(result);
    }

    
    /// <summary>
    /// GET Person by id
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
    {
        var result = await _personServices.GetPersonByIdAsync(id, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Create a Person
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Person person, CancellationToken cancellationToken)
    {
        var result = await _personServices.AddPersonAsync(person, cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Update Person information
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Person person, CancellationToken cancellationToken)
    {
        var result = await _personServices.UpdatePersonAsync(id, person, cancellationToken);

        return Ok(result);
    }
}