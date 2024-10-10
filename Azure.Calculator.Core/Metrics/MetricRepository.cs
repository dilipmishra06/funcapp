namespace Fl.Azure.Calculator.Core
{
    public class MetricRepository : IMetricRepository
    {
        private readonly Dictionary<string, IMetric> _metrics = new();

        public MetricRepository()
        {
            RegisterMetrics();
        }

        public Dictionary<string, IMetric> Metrics => _metrics;

        private void RegisterMetrics()
        {
            _metrics.Add(Metric.LCR_EUQ_Surplus, new LCREUQSurplus());
        }
    }
}
