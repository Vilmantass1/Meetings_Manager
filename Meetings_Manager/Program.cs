using FluentAssertions.Common;
using Meetings_Manager;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(app => app.AddJsonFile("appsettings.json"))
    .ConfigureServices((host, services) =>
    {
        var config = host.Configuration;   


        services.AddScoped<IExecutor, Executor>();
    })
    .Build();

await host.Services.GetRequiredService<IExecutor>().Run();
