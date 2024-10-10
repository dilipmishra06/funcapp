using Fl.Azure.Calculator.Model;

namespace Fl.Azure.Calculator.Core;

public record CalculationInput(BalanceSheetIdentifier  BalanceSheetIdentifier, string Metric, string MetricAggregation)
{
    public StatusInfo ToStatusInfo() =>
        new StatusInfo(
            BalanceSheetIdentifier.SatelliteRunID,
            BalanceSheetIdentifier.Scenario,
            BalanceSheetIdentifier.PartitionID,
            Metric,
            MetricAggregation
            );
        
}
