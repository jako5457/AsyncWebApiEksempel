using Client.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHttpClient("CarApi",c => c.BaseAddress = new Uri("https://localhost:7089"));
builder.Services.AddScoped<ICarApiClient, CarApiClient>();
builder.Services.AddHostedService<ClientService>();

var app = builder.Build();

await app.RunAsync();


