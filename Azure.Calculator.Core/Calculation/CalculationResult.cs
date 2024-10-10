
namespace Fl.Azure.Calculator.Core;

public record CalculationResult
{
    public int MetricCount { get; init; } = 0;
    public int MetricAggregationCount { get; init; } = 0;
}
