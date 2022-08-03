using BreadApp.Api.ErrorHandling;
using BreadApp.Application;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

ConfigureDependencies(builder);

var app = builder.Build();

ConfigureApp(app);

app.Run();






static void ConfigureDependencies(WebApplicationBuilder builder)
{
    builder.Services.AddBreadAppInfrastructureServices(builder.Configuration);
    builder.Services.AddBreadAppApplicationServices();

    // Custom ProblemDetails for the /error endpoint
    builder.Services.AddSingleton<ProblemDetailsFactory, BreadAppProblemDetailsFactory>();

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}


static void ConfigureApp(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.UseExceptionHandler("/error");
    app.MapControllers();
}