using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Fl.Azure.Calculator.Model.Entities;

namespace Fl.Azure.Calculator.Model.Configuration
{
    public class StatusEntityTypeConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(t => t.ID);

            builder.Property(t => t.TimeStamp).IsRequired();

            builder.Property(t => t.Initiator).IsRequired();
            builder.Property(t => t.Initiator).HasColumnType("nvarchar").HasMaxLength(64);

            builder.Property(t => t.SatelliteRunID).HasColumnType("nvarchar").HasMaxLength(64);
            builder.Property(t => t.Scenario).HasColumnType("nvarchar").HasMaxLength(64);
            builder.Property(t => t.Metric).HasColumnType("nvarchar").HasMaxLength(64);
            builder.Property(t => t.AggregationMetric).HasColumnType("nvarchar").HasMaxLength(64);

            builder.Property(t => t.Message).IsRequired();
            builder.Property(t => t.Message).HasColumnType("nvarchar").HasMaxLength(1024);
        }
    }
}
