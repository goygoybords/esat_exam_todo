using MediatR;

namespace Todo.Application.Requests.Companies.Queries.GetCompanies;

public class GetCompaniesQuery : IRequest<CompanyVm>;
