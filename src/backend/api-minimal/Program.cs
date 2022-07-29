using BreadApp.Application;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder);
ConfigureEndpoints(builder);

var app = builder.Build();
ConfigureApp(app);

var scope = app.Services.CreateScope();
app.MapPost("/auth/register", (RegisterRequest registerRequest) => scope.ServiceProvider.GetRequiredService<RegisterEndpoint>().Execute(registerRequest));
app.MapPost("/auth/login", (LoginRequest loginRequest) => scope.ServiceProvider.GetRequiredService<LoginEndpoint>().Execute(loginRequest));
// TODO try FastEndpoints library

app.Run();




static void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddBreadAppInfrastructureServices(builder.Configuration);
    builder.Services.AddBreadAppApplicationServices();
}


static void ConfigureEndpoints(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<RegisterEndpoint>();
    builder.Services.AddScoped<LoginEndpoint>();
}


static void ConfigureApp(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
}