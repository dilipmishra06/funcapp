namespace Fl.Azure.Calculator.Core
{
    public class MetricAggregationRepository : IMetricAggregationRepository
    {
        private readonly Dictionary<string, IMetricAggregation> _metricAggregations = new();

        public MetricAggregationRepository()
        {
            RegisterMetricAggregations();
        }

        public Dictionary<string, IMetricAggregation> MetricAggregations => _metricAggregations;

        private void RegisterMetricAggregations()
        {
            _metricAggregations.Add(MetricAggregation.LCR_EUQ_Surplus_Aggregation, new LCREUQSurplusAggregation());
        }
    }
}
