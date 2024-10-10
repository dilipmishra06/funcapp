using Fl.Azure.Calculator.Model.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Fl.Azure.Calculator.Model.Entities
{
    [EntityTypeConfiguration(typeof(CashflowMetricResultEntityTypeConfiguration))]
    public class CashflowMetricResult
    {
        public long ID { get; set; }

        public string SatelliteRunID { get; set; } = string.Empty;

        public string Scenario { get; set; } = string.Empty;

        public int PartitionID { get; set; }

        public decimal CashFlowID { get; set; }

        public DateTime SatelliteRunDate { get; set; } = DateTime.Now;

        public string CloseOfBusinessDate { get; set; } = string.Empty;

        public string HQLAInflowOutflowOtherName { get; set; } = string.Empty;

        public decimal CashFlowLCREUQAmount { get; set; }
    }
}
