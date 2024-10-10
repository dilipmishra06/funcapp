using Microsoft.ApplicationInsights.WorkerService;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.ApplicationInsights;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureAppConfiguration(builder =>
    {
        builder
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .AddUserSecrets<Program>();
    })
    .ConfigureServices((host, services) =>
    {
        
        services.AddProcessLogic();
        services.AddSatelliteRepository(host.Configuration.GetConnectionString("SatelliteConnectionString") ?? string.Empty) ;
        services.AddPathFinder(opt =>
        {
            host.Configuration.GetSection("ConnectionStrings").Bind(opt);
            host.Configuration.GetSection("PathFinder").Bind(opt);
        });

        services.AddConnectionValidator();

        // Application Insights logging
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.Configure<LoggerFilterOptions>(options =>
        {
            var appInsightsLoggerFilterRule = options.Rules.FirstOrDefault(rule => rule.ProviderName == typeof(ApplicationInsightsLoggerProvider).FullName);
            if (appInsightsLoggerFilterRule is not null)
            {
                options.Rules.Remove(appInsightsLoggerFilterRule);
            }
        });
        services.Configure<ApplicationInsightsServiceOptions>(options =>
        {
            // Explicitly disable sampling, setting in host.json does not seem to have effect
            options.EnableAdaptiveSampling = false;
        });
    })
    .ConfigureLogging((host, builder) =>
    {
        builder.AddConfiguration(host.Configuration.GetSection("logging"));
        builder.AddFilter("Fl.Azure", LogLevel.Debug);
        builder.AddFilter("Microsoft.EntityFrameworkCore", LogLevel.Warning);
    })
    .Build();

host.Run();
