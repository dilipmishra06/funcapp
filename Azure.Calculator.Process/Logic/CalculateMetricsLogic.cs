using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Fl.Azure.Calculator.Process.Interfaces;
using Fl.Azure.Calculator.Core;
using Fl.Azure.Calculator.Model.Repositories;
using Fl.Azure.Calculator.Model.Entities;
using Fl.Azure.Calculator.Model;

namespace Fl.Azure.Calculator.Process.Logic;

internal class CalculateMetricsLogic : ICalculateMetricsLogic
{
    private readonly ISatelliteRepository _satelliteRepository;
    private readonly IMetricRepository _metricRepository;
    private readonly IMetricAggregationRepository _metricAggregationRepository;
    private readonly ILogger<CalculateMetricsLogic> _logger;

    public CalculateMetricsLogic(
        ISatelliteRepository satelliteRepository,
        IMetricRepository metricRepository,
        IMetricAggregationRepository metricAggregationRepository,
        ILogger<CalculateMetricsLogic> logger)
    {
        _satelliteRepository = satelliteRepository;
        _metricRepository = metricRepository;
        _metricAggregationRepository = metricAggregationRepository;
        _logger = logger;
    }

    public Task<CalculationResult> ExecuteAsync(CalculationInput calculationInput)
    {
        if (_metricRepository.Metrics == null || !_metricRepository.Metrics.ContainsKey(calculationInput.Metric))
            throw new ArgumentException($"Metric ({calculationInput.Metric}) not found");

        if (_metricAggregationRepository.MetricAggregations == null ||
            !_metricAggregationRepository.MetricAggregations.ContainsKey(calculationInput.MetricAggregation))
            throw new ArgumentException($"Metric Aggregation ({calculationInput.MetricAggregation}) not found");

        return ExecuteAsyncInternal(calculationInput);
    }

    private async Task<CalculationResult> ExecuteAsyncInternal(CalculationInput calculationInput)
    {
        _logger.LogInformation("Start Calculate Metrics");
        var statusInfo = calculationInput.ToStatusInfo();
        await _satelliteRepository.SaveStatus(Module.Calculation, $"Start calculate Metrics {statusInfo}", statusInfo);

        var metricResults = await CalculateMetrics(calculationInput);
        var metricAggregationCount = await CalculateMetricAggregations(calculationInput, metricResults);

        _logger.LogInformation("End Calculate Metrics");
        await _satelliteRepository.SaveStatus(Module.Calculation, $"End calculate Metrics {statusInfo}", statusInfo);

        return new CalculationResult
        {
            MetricCount = metricResults.Count,
            MetricAggregationCount = metricAggregationCount,
        };
    }

    private async Task<List<CashflowMetricResult>> CalculateMetrics(CalculationInput calculationInput)
    {
        var balanceSheets = await _satelliteRepository.LoadBalanceSheets(calculationInput.BalanceSheetIdentifier.SatelliteRunID,
            calculationInput.BalanceSheetIdentifier.PartitionID,
            calculationInput.BalanceSheetIdentifier.Scenario);

        _logger.LogInformation("Loaded {Count} balance sheets", balanceSheets.Count);

        IMetric metric = _metricRepository.Metrics[calculationInput.Metric];

        var cashflowResults = balanceSheets.Select(metric.Execute).ToList();

        _logger.LogInformation("Saving {Count} cashflow metric results", cashflowResults.Count);

        await _satelliteRepository.SaveCashflowMetricResults(cashflowResults);

        return cashflowResults;
    }

    private async Task<int> CalculateMetricAggregations(CalculationInput calculationInput, List<CashflowMetricResult> metricResults)
    {
        IMetricAggregation metricAggregation = _metricAggregationRepository.MetricAggregations[calculationInput.MetricAggregation];

        var metricAggregationResults = metricAggregation.Execute(metricResults).ToList();

        _logger.LogInformation("Saving {Count} metric aggregation results", metricAggregationResults.Count);

        await _satelliteRepository.SaveMetricAggregationResults(metricAggregationResults);

        return metricAggregationResults.Count;
    }
}
