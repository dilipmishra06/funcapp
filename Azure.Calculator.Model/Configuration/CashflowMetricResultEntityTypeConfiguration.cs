using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Fl.Azure.Calculator.Model.Entities;

namespace Fl.Azure.Calculator.Model.Configuration
{
    public class CashflowMetricResultEntityTypeConfiguration : IEntityTypeConfiguration<CashflowMetricResult>
    {
        public void Configure(EntityTypeBuilder<CashflowMetricResult> builder)
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

            builder.Property(t => t.CashFlowID).IsRequired();
            builder.Property(t => t.CashFlowID).HasColumnType("decimal").HasPrecision(20, 0);

            builder.Property(t => t.HQLAInflowOutflowOtherName).IsRequired();
            builder.Property(t => t.HQLAInflowOutflowOtherName).HasColumnType("nvarchar").HasMaxLength(64);

            builder.Property(t => t.CashFlowLCREUQAmount).IsRequired();
            builder.Property(t => t.CashFlowLCREUQAmount).HasColumnType("decimal").HasPrecision(28,9);
        }
    }
}
