using Fl.Azure.Calculator.External.Connectivity.Probe.Interfaces;
using Fl.Azure.Calculator.External.PathFinder.Configuration;
using Fl.Azure.Calculator.External.PathFinder.Interfaces;
using Fl.Azure.Calculator.External.PathFinder;


namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPathFinder(this IServiceCollection services, Action<PathFinderOptions> configureAction)
        {
            return services
                .Configure(configureAction)
                .AddLogging()
                .AddScoped<IDailyCashflowRepository, DailyCashflowRepository>()
                .AddScoped<IValidateConnection, DailyCashflowRepository>();
        }
    }
}
