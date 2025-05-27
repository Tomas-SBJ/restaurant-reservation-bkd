using Domain.Entities.Abstractions;
using Domain.Entities.Users;
using Infra.Contexts;
using Infra.Repositories;
using Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Infra;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositories();
        services.AddPostgreSql(configuration);
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseEntityRepository<>), typeof(BaseEntityRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
    }
    
    private static void AddPostgreSql(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddSingleton(_ => NpgsqlDataSource.Create(connectionString!));
        
        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseNpgsql(connectionString,
                action => action.MigrationsAssembly("Infra"));
        });
    }
}