using Application.Services.Users.Create;
using Infra;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static void AddBase(this IServiceCollection services)
    {
        services.AddInfrastructure();
        
        services.AddServices();
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICreateUser, CreateUser>();
    }
}
