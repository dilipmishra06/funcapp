using Fl.Azure.Calculator.Core;
using Fl.Azure.Calculator.Process.Interfaces;
using Fl.Azure.Calculator.Process.Logic;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProcessLogic(this IServiceCollection services)
        {
            services.AddScoped<ILoadStagingLogic, LoadStagingLogic>();
            services.AddScoped<ICreateBalanceSheetLogic, CreateBalanceSheetLogic>();
            services.AddScoped<ICalculateMetricsLogic, CalculateMetricsLogic>();

            services.AddTransient<IScenarioRepository, ScenarioRepository>();
            services.AddTransient<IMetricRepository, MetricRepository>();
            services.AddTransient<IMetricAggregationRepository, MetricAggregationRepository>();

            return services;
        }
    }
}
