using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Fl.Azure.Calculator.Model.Entities;

namespace Fl.Azure.Calculator.Model.Configuration;

public class MetricAggregationResultEntityTypeConfiguration : IEntityTypeConfiguration<MetricAggregationResult>
{
    public void Configure(EntityTypeBuilder<MetricAggregationResult> builder)
    {
        builder.HasKey(t => t.ID).IsClustered(false);
        builder.HasIndex(t => new { t.SatelliteRunID, t.Scenario, t.PartitionID }).IsClustered();

        builder.Property(t => t.SatelliteRunID).IsRequired();
        builder.Property(t => t.SatelliteRunID).HasColumnType("nvarchar").HasMaxLength(64);

        builder.Property(t => t.Scenario).IsRequired();
        builder.Property(t => t.Scenario).HasColumnType("nvarchar").HasMaxLength(64);

        builder.Property(t => t.SatelliteRunDate).IsRequired();

        builder.Property(t => t.CloseOfBusinessDate).IsRequired();
        builder.Property(t => t.CloseOfBusinessDate).HasColumnType("nvarchar").HasMaxLength(8);

        builder.Property(t => t.HQLAInflowOutflowOtherName).IsRequired();
        builder.Property(t => t.HQLAInflowOutflowOtherName).HasColumnType("nvarchar").HasMaxLength(8);

        builder.Property(t => t.MetricName).IsRequired();
        builder.Property(t => t.MetricName).HasColumnType("nvarchar").HasMaxLength(64);

        builder.Property(t => t.Currency).IsRequired();
        builder.Property(t => t.Currency).HasColumnType("nvarchar").HasMaxLength(4);

        builder.Property(t => t.Amount).IsRequired();
        builder.Property(t => t.Amount).HasColumnType("decimal").HasPrecision(28, 9);

    }
}
