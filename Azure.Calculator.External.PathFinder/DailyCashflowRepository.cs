using Fl.Azure.Calculator.External.PathFinder.Configuration;
using Fl.Azure.Calculator.External.PathFinder.Interfaces;
using Fl.Azure.Calculator.External.PathFinder.Models;
using Fl.Azure.Calculator.External.Connectivity.Probe.Interfaces;
using Fl.Azure.Calculator.External.Connectivity.Probe.Helpers;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Fl.Azure.Calculator.External.PathFinder;

internal class DailyCashflowRepository : IDailyCashflowRepository, IValidateConnection
{
    private readonly PathFinderOptions _options;
    private readonly ILogger _logger;

    public DailyCashflowRepository(IOptions<PathFinderOptions> options, ILogger<DailyCashflowRepository> logger)
    {
        _options = options.Value;
        _logger = logger;
    }

    public async Task<Control?> GetLatestMurexControl()
    {
        using var connection = GetRetryableSqlConnection(_options.ControlConnectionString);
        connection.Open();

        var control = await connection.QueryFirstOrDefaultAsync<Control>("""
            SELECT TOP 1 
                c.[Viewname],
                c.[CloseofBusinessDate],
                c.[PathfinderRunId]
            FROM [sat].[Control] as c
            WHERE c.Source = @Source
            ORDER BY c.DateProcessedDateTime desc
            """,
            new { Source = "Murex" });

        return control;
    }

    public async Task<Control?> GetSpecificMurexControl(string closeOfBusinessDate)
    {
        using var connection = GetRetryableSqlConnection(_options.ControlConnectionString);
        connection.Open();

        var control = await connection.QueryFirstOrDefaultAsync<Control>("""
            SELECT TOP 1 
                c.[Viewname],
                c.[CloseofBusinessDate],
                c.[PathfinderRunId]
            FROM [sat].[Control] as c
            WHERE c.Source = @Source
              AND c.CloseOfBusinessDate =@CloseOfBusinessDate
            ORDER BY c.DateProcessedDateTime desc
            """,
            new { Source = "Murex",
            CloseOfBusinessDate = closeOfBusinessDate,
            });

        return control;
    }

    public async Task<IReadOnlyCollection<DailyCashflow>> GetDailyCashflows(Control control)
    {
        using var connection = GetRetryableSqlConnection(_options.DataConnectionString);
        connection.Open();

        var closeOfBusinessDate = control.CloseOfBusinessDate;
        var pathFinderRunID = control.PathFinderRunID;

        var staging = await connection.QueryAsync<DailyCashflow>($"""
        SELECT *
        FROM [sat].[{control.Viewname}] as v
        WHERE v.CloseOfBusinessDate = @CloseOfBusinessDate
        AND v.PathFinderRunID = @PathFinderRunID
    """,
        new
        {
            CloseOfBusinessDate = closeOfBusinessDate,
            PathFinderRunID = pathFinderRunID,
        });

        return staging?.ToArray() ?? [];
    }

    private SqlConnection GetRetryableSqlConnection(string connectionString)
    {
        _logger.LogDebug("Using pathfinder connection: {connectionString}", connectionString);

        var options = new SqlRetryLogicOption
        {
            NumberOfTries = _options.RetryMaxCount,
            MaxTimeInterval = TimeSpan.FromSeconds(_options.RetryMaxDelayInSeconds),
            DeltaTime = TimeSpan.FromSeconds(_options.RetryInitialDelayInSeconds)
        };

        var provider = SqlConfigurableRetryFactory.CreateExponentialRetryProvider(options);
        provider.Retrying += (o, e) => _logger.Log(LogLevel.Information, "Connection to Pathfinder failed, retry #{RetryNumber} in {Delay}", e.RetryCount, e.Delay);

        return new SqlConnection(connectionString)
        {
            RetryLogicProvider = provider
        };
    }

    async Task<IProbeResult[]> IValidateConnection.ValidateConnection(CancellationToken cancellationToken)
    {
        return await Task.WhenAll(
            ValidateConnectionAsync("Pathfinder-Control", _options.ControlConnectionString),
            ValidateConnectionAsync("Pathfinder-Data", _options.DataConnectionString)
        );


        static async Task<IProbeResult> ValidateConnectionAsync(string name, string connectionString)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                _ = await connection.QueryFirstOrDefaultAsync<object>("SELECT 1");

                return ProbeResult.Pass(name);
            }
            catch (Exception ex)
            {
               
                return ProbeResult.Fail(name, ex);
            }
        }

    }
}

