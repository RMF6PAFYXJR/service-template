using service_template.Application.UseCases;

namespace service_template.Web.Extensions;

public static class ApplicationExtensions
{
    /// <summary>
    /// Registers all application-level use cases and business logic handlers.
    /// </summary>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateUserUseCase>();
        // services.AddScoped<AnotherUseCase>();
        return services;
    }
}