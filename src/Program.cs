using service_template.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddForwardedHeadersSupport()
    .AddInfrastructure(builder.Configuration)
    .AddApplication()
    .AddSwaggerDocumentation()
    .AddControllers();

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