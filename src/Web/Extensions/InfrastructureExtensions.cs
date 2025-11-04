using Microsoft.EntityFrameworkCore;
using service_template.Domain.Interfaces;
using service_template.Infrastructure.Persistence;
using service_template.Infrastructure.Services;
using StackExchange.Redis;

namespace service_template.Web.Extensions;


public static class InfrastructureExtensions
{
    /// <summary>
    /// Configures and registers all core infrastructure dependencies for the application.
    /// </summary>
    /// <remarks>
    /// This includes:
    /// <list type="bullet">
    /// <item><description>PostgreSQL database context and EF Core setup</description></item>
    /// <item><description>Redis connection multiplexer for distributed caching</description></item>
    /// <item><description>Repository bindings (data access layer)</description></item>
    /// <item><description>Service bindings (email, logging, user domain logic)</description></item>
    /// </list>
    /// 
    /// Typically called in <c>Program.cs</c> during service registration:
    /// <code>
    /// builder.Services.AddInfrastructure(builder.Configuration);
    /// </code>
    /// </remarks>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(o =>
            o.UseNpgsql(config.GetConnectionString("Postgres")));
        
        services.AddSingleton<IConnectionMultiplexer>(sp =>
            ConnectionMultiplexer.Connect(config["Redis:ConnectionString"] ?? "localhost:6379"));


        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, ExampleUserService>();
        services.AddScoped<IEmailService, ExampleEmailService>();
        services.AddScoped<ILoggerService, ExampleLoggerService>();

        return services;
    }
}