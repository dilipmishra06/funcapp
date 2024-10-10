using Fl.Azure.Calculator.Model;

namespace Fl.Azure.Calculator.Core;

public record BalanceSheetIdentifier(string SatelliteRunID, string Scenario, int PartitionID )
{

    public StatusInfo ToStatusInfo() =>
        new StatusInfo(
            SatelliteRunID,
            Scenario,
            PartitionID,
            null,
            null);
}
