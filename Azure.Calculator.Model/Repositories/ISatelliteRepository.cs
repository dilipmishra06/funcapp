using Fl.Azure.Calculator.Model.Entities;

namespace Fl.Azure.Calculator.Model.Repositories
{
    public interface ISatelliteRepository
    {
        Task<Status?> GetLatestStatus(string closeOfBusinessDate);

        Task<IReadOnlyCollection<BalanceSheet>> LoadBalanceSheets(string satelliteRunId, int partitionId, string scenario);

        Task<IReadOnlyCollection<Staging>> LoadStaging(string satelliteRunId, int partitionId);

        Task SaveBalanceSheets(IEnumerable<BalanceSheet> balanceSheetRecords);

        Task SaveCashflowMetricResults(IEnumerable<CashflowMetricResult> cashflowMetricResults);

        Task SaveMetricAggregationResults(IEnumerable<MetricAggregationResult> metricAggregationResults);

        Task SaveStaging(IEnumerable<Staging> stagingRecords);

        Task SaveStatus(Module module, string message, StatusInfo statusInfo);
    }
}
