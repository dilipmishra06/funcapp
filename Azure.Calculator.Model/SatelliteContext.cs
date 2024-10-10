using Fl.Azure.Calculator.Model.Entities;
using Fl.Azure.Calculator.Model;
using Microsoft.EntityFrameworkCore;

namespace Fl.Azure.Calculator.Model;

internal class SatelliteContext : DbContext

{
    
    public SatelliteContext(DbContextOptions<SatelliteContext> options) : base(options) { }
    public DbSet<Status> Status { get; set; }
    public DbSet<Staging> Staging { get; set; }
    public DbSet<BalanceSheet> BalanceSheet { get; set; }
    public DbSet<CashflowMetricResult> CashflowMetricResult { get; set; }
    public DbSet<MetricAggregationResult> MetricAggregationResult { get; set; }
    public DbSet<MetricResult> MetricResult { get; set; }

}
