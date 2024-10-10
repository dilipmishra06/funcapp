using Microsoft.Azure.Functions.Worker;
using Microsoft.DurableTask;
using Microsoft.Extensions.Logging;
using Fl.Azure.Calculator.Core;
using Fl.Azure.Calculator.Models;

namespace Fl.Azure.Calculator
{
    public class AzureCalculatorOrchestrator
    {
        [Function(nameof(AzureCalculatorOrchestrator))]
        public async Task<OrchestrationResult> RunOrchestrator(
            [OrchestrationTrigger] TaskOrchestrationContext context)
        {
            ILogger logger = context.CreateReplaySafeLogger<AzureCalculatorOrchestrator>();
            logger.LogInformation("Orchestrator woke up!");




            var orchestrationOptions = context.GetInput<OrchestrationOptions>();
            var loadStagingOptions = new LoadStagingOptions(CloseOfBusinessDate: orchestrationOptions?.TargetCloseOfBusinessDate);

            var loadStagingResult = await context.CallActivityAsync<LoadStagingResult>(nameof(AzureLoadStagingActivity), loadStagingOptions);
            
            var calculationResults = IsStagingSuccessful(loadStagingResult)
                ? await ProcessBalanceSheets(context, logger, loadStagingResult.MaxPartitionId!.Value, loadStagingResult.SatelliteRunId!)
                : [];

            logger.LogInformation("Satellite run '{SatelliteRunId}' completed successfully", loadStagingResult.SatelliteRunId);

            return CreateOrchestrationResult(loadStagingResult, calculationResults);

            static bool IsStagingSuccessful(LoadStagingResult stagingResult)
            => stagingResult.MaxPartitionId is > 0
            && stagingResult.SatelliteRunId is not null;

        }
        private static async Task<IReadOnlyCollection<CalculationResult>> ProcessBalanceSheets(TaskOrchestrationContext context, ILogger logger, int partitions, string satelliteRunId)
        {
            var balanceSheetIdentifiers = Enumerable
                .Range(1, partitions)
                .Select(partitionId => new BalanceSheetIdentifier(satelliteRunId, Scenario.Actual, partitionId))
                .ToList();

            logger.LogInformation("Number of partitions: {PartitionCount}", balanceSheetIdentifiers.Count);

            var balanceSheetTasks = balanceSheetIdentifiers
                .Select(balanceSheetIdentifier => context.CallActivityAsync<string>(nameof(AzureCreateBalanceSheetsActivity), balanceSheetIdentifier));

            await Task.WhenAll(balanceSheetTasks);

            var calculationTasks = balanceSheetIdentifiers
                .Select(balanceSheetIdentifier => new CalculationInput(balanceSheetIdentifier, Metric.LCR_EUQ_Surplus, MetricAggregation.LCR_EUQ_Surplus_Aggregation))
                .Select(calculationInput => context.CallActivityAsync<CalculationResult>(nameof(AzureCalculateMetricsActivity), calculationInput));

            var calculationResults = await Task.WhenAll(calculationTasks);

            return calculationResults;
        }

        private static OrchestrationResult CreateOrchestrationResult(LoadStagingResult loadStagingResult, IReadOnlyCollection<CalculationResult> calculationResults)
            => new()
            {
                HasCalculatedMetrics = calculationResults.Count != 0,
                SatelliteRunId = loadStagingResult.SatelliteRunId,
                PartitionCount = loadStagingResult.MaxPartitionId,
                StagingRecordCount = loadStagingResult.RecordCount,
                MetricResultCount = calculationResults.Sum(x => x.MetricCount),
                MetricAggregationResultCount = calculationResults.Sum(x => x.MetricAggregationCount),
            };
    }
}
