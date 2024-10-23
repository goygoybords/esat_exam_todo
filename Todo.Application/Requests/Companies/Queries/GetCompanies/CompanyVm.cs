namespace Todo.Application.Requests.Companies.Queries.GetCompanies;

public record CompanyVm(IEnumerable<CompanyDto> Companies)
{
    public int Count {
        get => Companies?.Count() ?? 0;
    }
}
