using MediatR;

namespace Todo.Application.Requests.Companies.Commands.CreateCompan;

public record CreateCompanyCommand(string CompanyName, string Address) : IRequest<Unit>;
