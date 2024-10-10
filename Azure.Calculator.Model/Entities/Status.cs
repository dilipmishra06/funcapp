using Microsoft.EntityFrameworkCore;
using Fl.Azure.Calculator.Model.Configuration;

namespace Fl.Azure.Calculator.Model.Entities
{
    [EntityTypeConfiguration(typeof(StatusEntityTypeConfiguration))]
    public class Status
    {
        public long ID { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Initiator { get; set; } = string.Empty;

        public string? SatelliteRunID { get; set; }

        public string? Scenario { get; set; }

        public string? Metric {  get; set; }

        public string? AggregationMetric { get; set; }

        public int? PartitionID { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
