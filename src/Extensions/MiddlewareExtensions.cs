using service_template.Middlewares;

namespace service_template.Extensions;

public static class MiddlewareExtensions
{
    /// <summary>
    /// Provides an entry point to register and configure all global middlewares.
    /// Adds all global middlewares used across the service (e.g. exception handling, logging, auth).
    /// </summary>
    /// <param name="app">The current <see cref="IApplicationBuilder"/> instance.</param>
    /// <returns>The same <see cref="IApplicationBuilder"/> instance for fluent chaining.</returns>
    /// <remarks>
    /// Add additional middleware calls here as your application grows.
    /// </remarks>
    public static IApplicationBuilder UseGlobalMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<ApiKeyMiddleware>();
        
        return app;
    }
}