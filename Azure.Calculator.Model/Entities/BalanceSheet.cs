using Fl.Azure.Calculator.Model.Configuration;
using Microsoft.EntityFrameworkCore;


namespace Fl.Azure.Calculator.Model.Entities
{
    [EntityTypeConfiguration(typeof(BalanceSheetEntityTypeConfiguration))]
    public class BalanceSheet : Staging
    {
        public string Scenario { get; set; } = string.Empty;

        public CashflowMetricResult ToCashflowMetricResult() => new CashflowMetricResult
        {
            SatelliteRunID = SatelliteRunID,
            Scenario = Scenario,
            PartitionID = PartitionID,
            SatelliteRunDate = SatelliteRunDate,
            CloseOfBusinessDate = CloseOfBusinessDate,
            CashFlowID = CashflowID,
            HQLAInflowOutflowOtherName = HQLAInflowOutflowOtherName,
            CashFlowLCREUQAmount = 0.0M
        };
    }
}
