using Microsoft.EntityFrameworkCore;
using Todo.Application.Common.Interfaces;
using Todo.Domain;

namespace Todo.Persistence;

public class TodoDBContext : DbContext, ITodoContext
{
    public TodoDBContext()
    {

    }

    public TodoDBContext(DbContextOptions<TodoDBContext> options)
    : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("ProductVersion", "1.1.1-servicing");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoDBContext).Assembly);
    }
}
