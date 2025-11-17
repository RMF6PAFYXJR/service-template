using Microsoft.AspNetCore.HttpOverrides;

namespace ServiceTemplate.Web.Extensions;


public static class ForwardedHeadersExtensions
{
    /// <summary>
    /// Adds support for X-Forwarded-* headers used by reverse proxies (e.g. Nginx, Traefik).
    /// Registers configuration for processing forwarded headers.
    /// </summary>
    /// <param name="services">The application's <see cref="IServiceCollection"/>.</param>
    /// <returns>The same <see cref="IServiceCollection"/> instance for fluent chaining.</returns>
    /// <remarks>
    /// Ensures the application correctly detects client IP and protocol
    /// when running behind reverse proxies.
    /// </remarks>
    public static IServiceCollection AddForwardedHeadersSupport(this IServiceCollection services)
    {
        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            options.KnownProxies.Clear();
            options.KnownIPNetworks.Clear();
        });
        return services;
    }
}