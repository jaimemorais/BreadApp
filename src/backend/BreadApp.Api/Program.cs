using BreadApp.Api.ErrorHandling;
using BreadApp.Api.Mapping;
using BreadApp.Application;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

ConfigureDependencies(builder);

var app = builder.Build();

ConfigureApp(app);

app.Run();






static void ConfigureDependencies(WebApplicationBuilder builder)
{
    // Services
    builder.Services.AddBreadAppInfrastructureServices(builder.Configuration);
    builder.Services.AddBreadAppApplicationServices();

    // Api
    builder.Services.AddSingleton<ProblemDetailsFactory, BreadAppProblemDetailsFactory>();
    builder.Services.AddControllers();
    builder.Services.AddBreadAppObjectMappings();

    // Swagger
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