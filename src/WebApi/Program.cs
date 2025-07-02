using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProxiFiltros.Application.Interfaces;
using ProxiFiltros.Application.Services;
using ProxiFiltros.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient<IPrecalificacionSoapClient, PrecalificacionSoapClient>(client =>
{
    client.BaseAddress = new System.Uri("http://example.com/soap");
});
builder.Services.AddScoped<IPrecalificacionService, PrecalificacionService>();

var app = builder.Build();

app.MapControllers();

app.Run();
