using Fl.Azure.Calculator.Model.Entities;

namespace Fl.Azure.Calculator.Core
{
    public interface IMetricAggregation
    {
        string MetricName { get; }
        public string Currency { get; }

        IEnumerable<MetricAggregationResult> Execute(IEnumerable<CashflowMetricResult> meticResults);
    }
}
