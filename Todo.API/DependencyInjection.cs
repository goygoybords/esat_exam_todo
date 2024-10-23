using Todo.Persistence;
using Todo.Application;

namespace Todo.API;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddTodoAppBuilder(this WebApplicationBuilder builder)
    {
        builder.Services.AddPersistenceLayer();
        builder.Services.AddApplicationLayer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();

        return builder;
    }
}