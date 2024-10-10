using Fl.Azure.Calculator.External.Connectivity.Validator;
using Fl.Azure.Calculator.External.Connectivity.Validator.Interfaces;


namespace Microsoft.Extensions.DependencyInjection;

public static class ConnectivityServiceCollectionExtensions
{
    public static IServiceCollection AddConnectionValidator(this IServiceCollection services)
    {
        return services.AddScoped<IConnectionValidator, ConnectionValidator>();
    }

}
