namespace Fl.Azure.Calculator.Models
{
    public record OrchestrationResult
    {
        public bool HasCalculatedMetrics { get; init; }
        public int? PartitionCount {  get; init; }
        public int? StagingRecordCount { get; init; }
        public int? MetricResultCount { get; init; }
        public int? MetricAggregationResultCount { get; init; }
        public string? SatelliteRunId { get; init; }

    }
}
