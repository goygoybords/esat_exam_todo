using MediatR;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Common.Interfaces;

namespace Todo.Application.Requests.Companies.Queries.GetCompanies;

public class GetCompaniesQueryHandler(ITodoContext todoContext) : IRequestHandler<GetCompaniesQuery, CompanyVm>
{
    private readonly ITodoContext _todoContext = todoContext;

    public async Task<CompanyVm> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
    {
        var companies = await _todoContext.Companies.Select(o => new CompanyDto(o.Id, o.CompanyName, o.Address)).ToListAsync(cancellationToken);

        return new CompanyVm(companies);
    }
}
