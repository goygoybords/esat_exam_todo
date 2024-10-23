using MediatR;
using Todo.Application.Common.Interfaces;
using Todo.Domain;

namespace Todo.Application.Requests.Companies.Commands.CreateCompan;

public class CreateCompanyCommandHandler(ITodoContext todoContext) : IRequestHandler<CreateCompanyCommand, Unit>
{
    private readonly ITodoContext _todoContext = todoContext;

    public async Task<Unit> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = new Company
        {
            CompanyName = request.CompanyName,
            Address = request.Address
        };

        _todoContext.Companies.Add(company);
        await _todoContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}