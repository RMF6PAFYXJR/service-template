using Microsoft.EntityFrameworkCore;
using service_template.Data;

namespace service_template.Extensions;

public static class DatabaseMigrationExtensions
{
    /// <summary>
    /// Provides database migration support during application startup.
    /// Applies all pending EF Core migrations automatically on application start.
    /// </summary>
    /// <param name="app">The current <see cref="IApplicationBuilder"/> instance.</param>
    /// <returns>The same <see cref="IApplicationBuilder"/> instance for fluent chaining.</returns>
    /// <remarks>
    /// Use this only for development or containerized environments.
    /// In production, prefer running migrations manually for better control.
    /// </remarks>
    public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Database.Migrate();
        return app;
    }
}