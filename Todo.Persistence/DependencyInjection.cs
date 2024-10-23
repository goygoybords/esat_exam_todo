using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Common.Interfaces;

namespace Todo.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceLayer(this IServiceCollection services)
    {
        services.AddDbContext<TodoDBContext>(opts => opts.UseInMemoryDatabase("Todo"));
        services.AddScoped<ITodoContext>(provider => provider.GetService<TodoDBContext>());

        return services;
    }
}
