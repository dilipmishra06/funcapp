using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Fl.Azure.Calculator.Model.Entities;


namespace Fl.Azure.Calculator.Model.Configuration
{
    public class BalanceSheetEntityTypeConfiguration : StagingEntityTypeConfiguration, IEntityTypeConfiguration<BalanceSheet>
    {
        public void Configure(EntityTypeBuilder<BalanceSheet> builder)
        {
            builder.HasKey(t => t.ID).IsClustered(false);
            builder.HasIndex(t => new { t.SatelliteRunID, t.Scenario, t.PartitionID }).IsClustered();

            builder.Property(t => t.Scenario).IsRequired();
            builder.Property(t => t.Scenario).HasColumnType("nvarchar").HasMaxLength(64);

            ConfigureStagingProperties(builder);
        }
    }
}
