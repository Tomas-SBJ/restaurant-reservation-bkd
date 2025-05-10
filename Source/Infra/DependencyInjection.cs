using Domain.Entities.Abstractions;
using Domain.Entities.Users;
using Infra.Data.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Infra;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddRepositories();
        services.AddPostgreSql();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseEntityRepository<>), typeof(BaseEntityRepository<>));
        services.AddScoped<IUserRepository, IUserRepository>();
    }
    
    private static void AddPostgreSql(this IServiceCollection services)
    {
    
    }
}