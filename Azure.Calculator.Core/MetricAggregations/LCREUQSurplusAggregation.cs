using Fl.Azure.Calculator.Model.Entities;

namespace Fl.Azure.Calculator.Core
{
    public class LCREUQSurplusAggregation : IMetricAggregation
    {
        public string MetricName { get => "LCR EUQ Surplus"; }

        public string Currency { get => "EUQ"; }

        public IEnumerable<MetricAggregationResult> Execute(IEnumerable<CashflowMetricResult> metricResults)
        {
            if (!metricResults.Any())
                return [];

            return metricResults.GroupBy(m => m.HQLAInflowOutflowOtherName)
                .OrderBy(group => group.Key)
                .Select(group => new MetricAggregationResult
                {
                    SatelliteRunID = metricResults.First().SatelliteRunID,
                    Scenario = metricResults.First().Scenario,
                    PartitionID = metricResults.First().PartitionID,
                    SatelliteRunDate = metricResults.First().SatelliteRunDate,
                    CloseOfBusinessDate = metricResults.First().CloseOfBusinessDate,
                    Currency = Currency,
                    MetricName = MetricName,
                    HQLAInflowOutflowOtherName = group.Key,
                    Amount = group.Sum(m => m.CashFlowLCREUQAmount)
                });
        }
    }
}
