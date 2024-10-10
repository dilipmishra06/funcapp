namespace Fl.Azure.Calculator.Core
{
    public interface IMetricRepository
    {
        Dictionary<string, IMetric> Metrics {get; }
    }
}
