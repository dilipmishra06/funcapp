using Fl.Azure.Calculator.Core;
using Fl.Azure.Calculator.Process.Interfaces;
using Microsoft.Extensions.Logging;
using Mapster;
using Fl.Azure.Calculator.Model;
using Fl.Azure.Calculator.Model.Entities;
using Fl.Azure.Calculator.Model.Repositories;

namespace Fl.Azure.Calculator.Process.Logic;

internal class CreateBalanceSheetLogic : ICreateBalanceSheetLogic
{
    private readonly ISatelliteRepository _satelliteRepository;
    private readonly IScenarioRepository _scenarioRepository;
    private readonly ILogger _logger;

    public CreateBalanceSheetLogic(ISatelliteRepository satelliteRepository, IScenarioRepository scenarioRepository, ILogger<CreateBalanceSheetLogic> logger)
    {
        _satelliteRepository = satelliteRepository;
        _scenarioRepository = scenarioRepository;
        _logger = logger;
    }

    public async Task ExecuteAsync(BalanceSheetIdentifier balanceSheetIdentifier)
    {
        _logger.LogInformation("Start Create BalanceSheet");

        var statusInfo = balanceSheetIdentifier.ToStatusInfo();
        await _satelliteRepository.SaveStatus(Module.BalanceSheet, "Start Create BalanceSheet", statusInfo);

        var staging = await _satelliteRepository.LoadStaging(balanceSheetIdentifier.SatelliteRunID, balanceSheetIdentifier.PartitionID);
        _logger.LogInformation("Loaded {Count} staging records", staging.Count);

        var balanceSheets = GenerateBalanceSheets(staging, balanceSheetIdentifier.Scenario);

        _logger.LogInformation("Saving balance sheets");
        await _satelliteRepository.SaveBalanceSheets(balanceSheets);

        _logger.LogInformation("End Create BalanceSheet");
        await _satelliteRepository.SaveStatus(Module.BalanceSheet, "End Create BalanceSheet", statusInfo);
    }

    private IEnumerable<BalanceSheet> GenerateBalanceSheets(IEnumerable<Staging> staging, string scenarioName)
    {
        var scenario = _scenarioRepository.Scenarios[scenarioName];
        foreach (var item in scenario.Execute(staging.AsQueryable()).ProjectToType<BalanceSheet>())
        {
            item.Scenario = scenarioName;
            yield return item;
        }
    }
}