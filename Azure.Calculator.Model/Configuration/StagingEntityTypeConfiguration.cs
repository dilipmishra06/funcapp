using Fl.Azure.Calculator.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Fl.Azure.Calculator.Model.Configuration
{
    public class StagingEntityTypeConfiguration : IEntityTypeConfiguration<Staging>
    {
        public void Configure(EntityTypeBuilder<Staging> builder)
        {
            builder.HasKey(t => t.ID).IsClustered(false);
            builder.HasIndex(t => new { t.SatelliteRunID, t.PartitionID }).IsClustered();

            ConfigureStagingProperties(builder);
        }

        protected static void ConfigureStagingProperties<T>(EntityTypeBuilder<T> builder)
            where T : Staging
        {
            builder.Property(t => t.PathFinderRunID).IsRequired();
            builder.Property(t => t.PathFinderRunID).HasColumnType("nvarchar").HasMaxLength(64);

            builder.Property(t => t.SatelliteRunID).IsRequired();
            builder.Property(t => t.SatelliteRunID).HasColumnType("nvarchar").HasMaxLength(64);

            builder.Property(t => t.SatelliteRunDate).IsRequired();

            builder.Property(t => t.SourceSystemName).IsRequired();
            builder.Property(t => t.SourceSystemName).HasColumnType("nvarchar").HasMaxLength(64);

            builder.Property(t => t.CloseOfBusinessDate).IsRequired();
            builder.Property(t => t.CloseOfBusinessDate).HasColumnType("nvarchar").HasMaxLength(64);

            builder.Property(t => t.CashflowID).IsRequired();
            builder.Property(t => t.CashflowID).HasColumnType("decimal").HasPrecision(20, 8);

            builder.Property(t => t.TradeID).IsRequired();
            builder.Property(t => t.TradeID).HasColumnType("nvarchar").HasMaxLength(64);

            builder.Property(t => t.TradeLegID).IsRequired();
            builder.Property(t => t.TradeLegID).HasColumnType("nvarchar").HasMaxLength(64);

            builder.Property(t => t.SatelliteCashflowMaturityDate).IsRequired();
            builder.Property(t => t.SatelliteCashflowMaturityDate).HasColumnType("nvarchar").HasMaxLength(64);

            builder.Property(t => t.ForwardStarterFlag).IsRequired();

            builder.Property(t => t.CurrencyCode).IsRequired();
            builder.Property(t => t.CurrencyCode).HasColumnType("nvarchar").HasMaxLength(4);

            builder.Property(t => t.ProductCode).HasColumnType("nvarchar").HasMaxLength(64);

            builder.Property(t => t.ReportingFolderCode).IsRequired();
            builder.Property(t => t.ReportingFolderCode).HasColumnType("nvarchar").HasMaxLength(64);

            builder.Property(t => t.InstrumentCode).HasColumnType("nvarchar").HasMaxLength(64);

            builder.Property(t => t.CounterpartyCode).IsRequired();
            builder.Property(t => t.CounterpartyCode).HasColumnType("nvarchar").HasMaxLength(64);

            builder.Property(t => t.CounterpartyName).HasColumnType("nvarchar").HasMaxLength(256);

            builder.Property(t => t.CounterpartyClass).HasColumnType("nvarchar").HasMaxLength(64);

            builder.Property(t => t.CounterpartyType).HasColumnType("nvarchar").HasMaxLength(64);
            builder.Property(t => t.ReportingEntityCode).HasColumnType("nvarchar").HasMaxLength(16);

            builder.Property(t => t.CashflowBalanceOriginalCurrencyAmount).IsRequired();
            builder.Property(t => t.CashflowBalanceOriginalCurrencyAmount).HasColumnType("decimal").HasPrecision(28, 9);

            builder.Property(t => t.FXRate).IsRequired();
            builder.Property(t => t.FXRate).HasColumnType("decimal").HasPrecision(28, 0);

            builder.Property(t => t.CashflowBalanceEUQAmount).IsRequired();
            builder.Property(t => t.CashflowBalanceEUQAmount).HasColumnType("decimal").HasPrecision(28, 9);

            builder.Property(t => t.FlowCategoryName).IsRequired();
            builder.Property(t => t.FlowCategoryName).HasColumnType("varchar").HasMaxLength(128);

            builder.Property(t => t.HQLAInflowOutflowOtherName).IsRequired();
            builder.Property(t => t.HQLAInflowOutflowOtherName).HasColumnType("nvarchar").HasMaxLength(128);

            builder.Property(t => t.LCRTenorApplicableFlag).IsRequired();

            builder.Property(t => t.EBAAccountName).HasColumnType("nvarchar").HasMaxLength(12);

            builder.Property(t => t.EBAAccountCode).HasColumnType("nvarchar").HasMaxLength(16);

            builder.Property(t => t.EBAWeight).IsRequired();
            builder.Property(t => t.EBAWeight).HasColumnType("decimal").HasPrecision(7,4);
        }
    }
}
