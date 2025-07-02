using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProxiFiltros.Application.Interfaces;
using ProxiFiltros.Application.Services;
using ProxiFiltros.Infrastructure.Services;
using System;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from .env if present
var envPath = Path.Combine(builder.Environment.ContentRootPath, ".env");
if (File.Exists(envPath))
{
    foreach (var line in File.ReadAllLines(envPath))
    {
        var trimmed = line.Trim();
        if (string.IsNullOrWhiteSpace(trimmed) || trimmed.StartsWith("#"))
            continue;
        var parts = trimmed.Split('=', 2);
        if (parts.Length == 2)
        {
            Environment.SetEnvironmentVariable(parts[0], parts[1]);
        }
    }
}

builder.Services.AddControllers();
builder.Services.AddHttpClient<IPrecalificacionSoapClient, PrecalificacionSoapClient>(client =>
{
    var baseUrl = Environment.GetEnvironmentVariable("WSExperian_Service") ?? "http://example.com/soap";
    client.BaseAddress = new Uri(baseUrl);
});
builder.Services.AddScoped<IPrecalificacionService, PrecalificacionService>();

var app = builder.Build();

app.MapControllers();

app.Run();
