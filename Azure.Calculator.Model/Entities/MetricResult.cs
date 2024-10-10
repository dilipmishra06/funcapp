using Microsoft.EntityFrameworkCore;
using Fl.Azure.Calculator.Model.Configuration;

namespace Fl.Azure.Calculator.Model;

[EntityTypeConfiguration(typeof(MetricResultConfiguration))]
public class MetricResult
{
    public string SatelliteRunID { get; set; } = string.Empty;

    public DateTime? SatelliteRunDate { get; set; }

    public string Scenario { get; set; } = string.Empty;

    public string CloseOfBusinessDate { get; set; } = string.Empty;

    public string MetricName { get; set; } = string.Empty;

    public string Currency { get; set; } = string.Empty;

    public decimal TotalAmount { get; set; }
}
