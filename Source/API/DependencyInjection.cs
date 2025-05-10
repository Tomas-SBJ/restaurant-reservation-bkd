using API.Validators.Users;
using Application;
using FluentValidation;

namespace API;

public static class DependencyInjection
{
    public static void AddApi(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateUserRequestValidator>();
        
        services.AddBase();

        services.AddControllers();
        services.AddMemoryCache();
        services.AddAuthentication();
        services.AddAuthorization();
    }
}