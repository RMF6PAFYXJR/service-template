using Serilog;

namespace service_template.Middlewares;

public class ApiKeyMiddleware(RequestDelegate next, IConfiguration config)
{
    private readonly string? _apiKey = config["Swagger:ApiKey"];


    public async Task InvokeAsync(HttpContext context)
    {

        var path = context.Request.Path.Value?.ToLowerInvariant() ?? string.Empty;
        if (IsSwaggerOrHealthCheck(path))
        {
            await next(context);
            return;
        }

        context.Request.Headers.TryGetValue("X-API-KEY", out var value);
        Console.WriteLine("X-API-KEY: " + value);
        if (value != _apiKey)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Invalid or missing API key");
            return;
        }

        await next(context);
    }

    private static bool IsSwaggerOrHealthCheck(string path)
    {
        return path.StartsWith("/swagger") || path.StartsWith("/health");
    }
}