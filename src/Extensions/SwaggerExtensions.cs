using Microsoft.OpenApi.Models;

namespace service_template.Extensions;

public static class SwaggerExtensions
{
    /// <summary>
    /// Provides configuration methods for Swagger documentation and UI.
    /// Registers and configures Swagger generator and security schemes.
    /// </summary>
    /// <param name="services">The application's <see cref="IServiceCollection"/>.</param>
    /// <returns>The same <see cref="IServiceCollection"/> for fluent chaining.</returns>
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "MyService API",
                Version = "v1"
            });

            var apiKeyScheme = new OpenApiSecurityScheme
            {
                Description = "Enter API key below:",
                Name = "X-API-KEY",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "ApiKeyScheme"
            };

            c.AddSecurityDefinition("ApiKey", apiKeyScheme);

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "ApiKey"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        return app;
    }
}