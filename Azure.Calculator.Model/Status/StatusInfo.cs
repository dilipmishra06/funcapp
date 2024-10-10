namespace  Fl.Azure.Calculator.Model;

public record StatusInfo(string? SatelliteRunID, string? Scenario, int? PartitionID, string? Metric, string? MetricAggregation)
{
    public override string ToString() => $"SatelliteRunID {SatelliteRunID} Scenario {Scenario} PartitionID {PartitionID} Metric {Metric} Metrgregation {MetricAggregation}";
}
