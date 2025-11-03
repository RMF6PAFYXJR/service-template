namespace service_template.Extensions;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

public static class HealthEndpointsExtensions
{
    /// <summary>
    /// Provides health-check endpoints for service monitoring and orchestration tools.
    /// Maps a simple health endpoint that responds with HTTP 200 OK.
    /// </summary>
    /// <param name="app">The current <see cref="IEndpointRouteBuilder"/> instance.</param>
    /// <returns>The same <see cref="IEndpointRouteBuilder"/> instance for fluent chaining.</returns>
    public static IEndpointRouteBuilder MapHealthEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/health", () => Results.Ok(new { status = "Healthy" }))
            .WithName("HealthCheck");

        return app;
    }
}