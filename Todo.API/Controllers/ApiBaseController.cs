using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Todo.API.Controllers;

[Route("api/[controller]")]
public class ApiBaseController : ControllerBase
{
    private IMediator _mediator;
    
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}