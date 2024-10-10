
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Fl.Azure.Calculator.Model.Configuration;

internal class MetricResultConfiguration : IEntityTypeConfiguration<MetricResult>
{
    public void Configure(EntityTypeBuilder<MetricResult> builder)
    {
        builder.HasNoKey();

        builder.ToView("MetricResult");

        builder.Property(x => x.TotalAmount).HasPrecision(28, 9);
    }
}
