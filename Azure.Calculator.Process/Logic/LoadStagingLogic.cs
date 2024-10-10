using Mapster;
using Microsoft.Extensions.Logging;
using Fl.Azure.Calculator.External.PathFinder.Interfaces;
using Fl.Azure.Calculator.External.PathFinder.Models;
using Fl.Azure.Calculator.Model;
using Fl.Azure.Calculator.Model.Entities;
using Fl.Azure.Calculator.Model.Repositories;
using Fl.Azure.Calculator.Process.Interfaces;
using Fl.Azure.Calculator.Core;

namespace Fl.Azure.Calculator.Process.Logic;

internal class LoadStagingLogic : ILoadStagingLogic
{
    private readonly ISatelliteRepository _satelliteRepository;
    private readonly IDailyCashflowRepository _dailyCashflowRepository;
    private readonly ILogger _logger;

    public LoadStagingLogic(ISatelliteRepository satelliteRepository, IDailyCashflowRepository dailyCashflowRepository, ILogger<LoadStagingLogic> logger)
    {
        _satelliteRepository = satelliteRepository;
        _dailyCashflowRepository = dailyCashflowRepository;
        _logger = logger;
    }

    public async Task<LoadStagingResult> ExecuteAsync(LoadStagingOptions options)
    {
        var control = await GetPathFinderControlInfo(options.CloseOfBusinessDate);

        if (control is null)
            return new();

        _logger.LogInformation("Found control record: PathFinderRunId={PathFinderRunId}, ViewName={Viewname}, COBdate={CobDate}",
                               control.PathFinderRunID, control.Viewname, control.CloseOfBusinessDate);

        string satelliteRunID = await GetSatelliteRunID(control.CloseOfBusinessDate);
        _logger.LogInformation("Start Loading Staging");

        await _satelliteRepository.SaveStatus(Module.Staging, "Start Loading Staging",
                                              new StatusInfo(satelliteRunID, null, null, null, null));
        Console.WriteLine("sdsdsd");
        var staging = await GetPathFinderData(control, satelliteRunID);

        _logger.LogInformation("Retrieved {RecordCount} records from PathFinder", staging.Count);

        await _satelliteRepository.SaveStaging(staging);
        _logger.LogInformation("End Loading Staging");

        await _satelliteRepository.SaveStatus(Module.Staging, "End Loading Staging",
                                              new StatusInfo(satelliteRunID, null, null, null, null));

        var maxPartitionId = staging.Max(x => x.PartitionID as int?);
        Console.WriteLine(maxPartitionId.ToString());
        Console.WriteLine(satelliteRunID);
        Console.WriteLine(staging.Count.ToString());
        return new(satelliteRunID, maxPartitionId, staging.Count);
    }

    private async Task<Control?> GetPathFinderControlInfo(string? closeOfBusinessDate)
    {
        return closeOfBusinessDate is not null
            ? await _dailyCashflowRepository.GetSpecificMurexControl(closeOfBusinessDate)
            : await _dailyCashflowRepository.GetLatestMurexControl();
    }

    private async Task<IReadOnlyCollection<Staging>> GetPathFinderData(Control control, string satelliteRunID)
    {
        var dailyCashflows = await _dailyCashflowRepository.GetDailyCashflows(control);
        var now = DateTime.UtcNow;

        var stagingItems = dailyCashflows.AsQueryable().ProjectToType<Staging>().ToList();

        foreach (var item in stagingItems)
        {
            item.SatelliteRunDate = DateTime.UtcNow;
            item.SatelliteRunID = satelliteRunID;
        }

        return stagingItems.AsReadOnly();
    }

    private async Task<string> GetSatelliteRunID(string closeOfBusinessDate)
    {
        var lastSatelliteRun = await _satelliteRepository.GetLatestStatus(closeOfBusinessDate);
        Console.WriteLine("sdsdsd");
        return SatelliteRunIdCreator.Next(lastSatelliteRun?.SatelliteRunID, closeOfBusinessDate);
    }
}
