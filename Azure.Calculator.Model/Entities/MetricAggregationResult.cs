using Fl.Azure.Calculator.Model.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Fl.Azure.Calculator.Model.Entities
{
    [EntityTypeConfiguration(typeof(MetricAggregationResultEntityTypeConfiguration))]
    public class MetricAggregationResult
    {
        public long ID { get; set; }

        public string SatelliteRunID { get; set; } = string.Empty;

        public string Scenario { get; set; } = string.Empty;

        public int PartitionID { get; set; }

        public DateTime SatelliteRunDate { get; set; } = DateTime.UtcNow;

        public string CloseOfBusinessDate { get; set; } = string.Empty;

        public string HQLAInflowOutflowOtherName { get; set; } = string.Empty;

        public string MetricName { get; set; } = string.Empty;

        public string Currency { get; set; } = string.Empty;

        public decimal Amount { get; set; }
    }
}
