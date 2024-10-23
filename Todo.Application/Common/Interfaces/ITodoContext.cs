using Microsoft.EntityFrameworkCore;
using Todo.Domain;

namespace Todo.Application.Common.Interfaces;

public interface ITodoContext
{
    DbSet<Person> Persons { get; set; }
    DbSet<Company> Companies { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}