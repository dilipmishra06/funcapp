

namespace Fl.Azure.Calculator.Core

{
    public interface IMetricAggregationRepository
    {
        Dictionary<string, IMetricAggregation> MetricAggregations { get; }
    }
}
