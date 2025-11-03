using Microsoft.EntityFrameworkCore;
using service_template.Data;
using service_template.Services;
using StackExchange.Redis;

namespace service_template.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Postgres")));

        
        services.AddSingleton<IConnectionMultiplexer>(sp =>
            ConnectionMultiplexer.Connect(configuration["Redis:ConnectionString"] ?? "localhost:6379"));

        
        services.AddScoped<IUserService, UserService>();
        
        
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        return services;
    }
}