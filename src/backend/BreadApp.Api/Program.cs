using BreadApp.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBreadAppInfrastructureServices(builder.Configuration);
builder.Services.AddBreadAppApplicationServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
