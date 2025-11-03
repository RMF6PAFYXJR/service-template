using service_template.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services
    .AddForwardedHeadersSupport()
    .AddAppServices(configuration)
    .AddSwaggerDocumentation();

var app = builder.Build();

app
    .UseForwardedHeaders()
    .ApplyMigrations()
    .UseGlobalMiddlewares()
    .UseSwaggerDocumentation();

app
    .MapHealthEndpoints()
    .MapControllers();

app.Run();