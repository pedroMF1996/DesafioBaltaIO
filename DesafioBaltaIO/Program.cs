using DesafioBaltaIO.Configurations;
using DesafioBaltaIO.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

builder.Services.AddApiConfiguration(builder.Configuration, builder.Environment);

var app = builder.Build();

app.UseApiConfiguration(app.Environment);

app.AddIbgeController();
app.AddAutenticacaoController();

app.Run();