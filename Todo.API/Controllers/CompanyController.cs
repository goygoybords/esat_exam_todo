using Microsoft.AspNetCore.Mvc;
using Todo.Application.Requests.Companies.Queries.GetCompanies;

namespace Todo.API.Controllers;

public class CompanyController : ApiBaseController
{
    /// <summary>
    /// GET company list
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var companies = await Mediator.Send(new GetCompaniesQuery(), cancellationToken);

        return Ok(companies);
    }    
}