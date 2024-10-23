using Todo.Domain;

namespace Todo.Application.Common.Interfaces;

public interface ICompanyServices
{
    Task<IEnumerable<Company>> GetCompaniesListAsync(CancellationToken cancellationToken);
    Task<Company> GetCompanyByIdAsync(int id, CancellationToken cancellationToken);
    Task<Company> AddCompanyAsync(Company comapny, CancellationToken cancellationToken);
    Task<Company> UpdateCompanyAsync(int id, Company company, CancellationToken cancellationToken);
}
