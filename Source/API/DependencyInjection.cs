using API.Validators.Users;
using FluentValidation;

namespace API;

public static class DependencyInjection
{
    public static void AddApi(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateUserRequestValidator>();
    }
}