using Fl.Azure.Calculator.External.Connectivity.Probe.Interfaces;
using Fl.Azure.Calculator.Model;
using Fl.Azure.Calculator.Model.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSatelliteRepository(this IServiceCollection services, string satelliteConnectionString)
    {
        if (string.IsNullOrEmpty(satelliteConnectionString))
        {
            throw new ArgumentException("Connection string cannot be null or empty.", nameof(satelliteConnectionString));
        }
        return services.AddScoped<ISatelliteRepository, SatelliteRepository>()
            .AddScoped<IValidateConnection, SatelliteRepository>()
            .AddDbContext<SatelliteContext>(options =>
            {
                options.UseSqlServer(satelliteConnectionString);
            });
            
    }
   
}
