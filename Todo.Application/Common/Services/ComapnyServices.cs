using Microsoft.EntityFrameworkCore;
using Todo.Application.Common.Interfaces;
using Todo.Domain;

namespace Todo.Application.Common.Services;

public class CompanyServices(ITodoContext todoContext) : ICompanyServices
{
    private readonly ITodoContext _todoContext = todoContext;

    public async Task<IEnumerable<Company>> GetCompaniesListAsync(CancellationToken cancellationToken)
    {
        var companies = await _todoContext.Companies.ToListAsync(cancellationToken);

        return companies;
    }

    public async Task<Company> GetCompanyByIdAsync(int id, CancellationToken cancellationToken)
    {
        var company = await _todoContext.Companies.Where(o => o.Id == id).FirstOrDefaultAsync(cancellationToken);

        if(company == null)
            return null;

        return company;
    }

    public async Task<Company> AddCompanyAsync(Company company, CancellationToken cancellationToken)
    {
        _todoContext.Companies.Add(company);

        await _todoContext.SaveChangesAsync(cancellationToken);

        return company;
    }

    public async Task<Company> UpdateCompanyAsync(int id, Company company, CancellationToken cancellationToken)
    {
        var existingCompanies = await _todoContext.Companies.Where(o => o.Id == id).FirstOrDefaultAsync(cancellationToken);
        if (existingCompanies == null)
        {
            return null;
        }

        existingCompanies.CompanyName = company.CompanyName;
        existingCompanies.Address = company.Address;

        await _todoContext.SaveChangesAsync(cancellationToken);
        return company;
    }
}