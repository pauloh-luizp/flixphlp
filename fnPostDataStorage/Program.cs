using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static System.Collections.Immutable.ImmutableArray<T>;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
    })
    .Build();

IServiceCollection serviceCollection = Builder.Services.Configure<KestrelServerOptions>(static options =>
{
    options.Limits.MaxRequestBodySize = 104857600;
});


host.Run();