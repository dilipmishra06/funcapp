﻿// <auto-generated />
using System;
using Fl.Azure.Calculator.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Azure.Calculator.Model.Migrations
{
    [DbContext(typeof(SatelliteContext))]
    partial class SatelliteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fl.Azure.Calculator.Model.Entities.BalanceSheet", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<decimal>("CashflowBalanceEUQAmount")
                        .HasPrecision(28, 9)
                        .HasColumnType("decimal");

                    b.Property<decimal>("CashflowBalanceOriginalCurrencyAmount")
                        .HasPrecision(28, 9)
                        .HasColumnType("decimal");

                    b.Property<decimal>("CashflowID")
                        .HasPrecision(20, 8)
                        .HasColumnType("decimal");

                    b.Property<string>("CloseOfBusinessDate")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("CounterpartyClass")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("CounterpartyCode")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("CounterpartyName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar");

                    b.Property<string>("CounterpartyType")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar");

                    b.Property<string>("EBAAccountCode")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar");

                    b.Property<string>("EBAAccountName")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar");

                    b.Property<decimal>("EBAWeight")
                        .HasPrecision(7, 4)
                        .HasColumnType("decimal");

                    b.Property<decimal>("FXRate")
                        .HasPrecision(28)
                        .HasColumnType("decimal");

                    b.Property<string>("FlowCategoryName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar");

                    b.Property<bool>("ForwardStarterFlag")
                        .HasColumnType("bit");

                    b.Property<string>("HQLAInflowOutflowOtherName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar");

                    b.Property<string>("InstrumentCode")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<bool>("LCRTenorApplicableFlag")
                        .HasColumnType("bit");

                    b.Property<int>("PartitionID")
                        .HasColumnType("int");

                    b.Property<string>("PathFinderRunID")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("ProductCode")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("ReportingEntityCode")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar");

                    b.Property<string>("ReportingFolderCode")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("SatelliteCashflowMaturityDate")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<DateTime>("SatelliteRunDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SatelliteRunID")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Scenario")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("SourceSystemName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("TradeID")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("TradeLegID")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.HasKey("ID");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("ID"), false);

                    b.HasIndex("SatelliteRunID", "Scenario", "PartitionID");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("SatelliteRunID", "Scenario", "PartitionID"));

                    b.ToTable("BalanceSheet");
                });

            modelBuilder.Entity("Fl.Azure.Calculator.Model.Entities.CashflowMetricResult", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<decimal>("CashFlowID")
                        .HasPrecision(20)
                        .HasColumnType("decimal");

                    b.Property<decimal>("CashFlowLCREUQAmount")
                        .HasPrecision(28, 9)
                        .HasColumnType("decimal");

                    b.Property<string>("CloseOfBusinessDate")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar");

                    b.Property<string>("HQLAInflowOutflowOtherName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<int>("PartitionID")
                        .HasColumnType("int");

                    b.Property<DateTime>("SatelliteRunDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SatelliteRunID")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Scenario")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.HasKey("ID");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("ID"), false);

                    b.HasIndex("SatelliteRunID", "Scenario", "PartitionID");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("SatelliteRunID", "Scenario", "PartitionID"));

                    b.ToTable("CashflowMetricResult");
                });

            modelBuilder.Entity("Fl.Azure.Calculator.Model.Entities.MetricAggregationResult", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<decimal>("Amount")
                        .HasPrecision(28, 9)
                        .HasColumnType("decimal");

                    b.Property<string>("CloseOfBusinessDate")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar");

                    b.Property<string>("HQLAInflowOutflowOtherName")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar");

                    b.Property<string>("MetricName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<int>("PartitionID")
                        .HasColumnType("int");

                    b.Property<DateTime>("SatelliteRunDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SatelliteRunID")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Scenario")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.HasKey("ID");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("ID"), false);

                    b.HasIndex("SatelliteRunID", "Scenario", "PartitionID");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("SatelliteRunID", "Scenario", "PartitionID"));

                    b.ToTable("MetricAggregationResult");
                });

            modelBuilder.Entity("Fl.Azure.Calculator.Model.Entities.Staging", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<decimal>("CashflowBalanceEUQAmount")
                        .HasPrecision(28, 9)
                        .HasColumnType("decimal");

                    b.Property<decimal>("CashflowBalanceOriginalCurrencyAmount")
                        .HasPrecision(28, 9)
                        .HasColumnType("decimal");

                    b.Property<decimal>("CashflowID")
                        .HasPrecision(20, 8)
                        .HasColumnType("decimal");

                    b.Property<string>("CloseOfBusinessDate")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("CounterpartyClass")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("CounterpartyCode")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("CounterpartyName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar");

                    b.Property<string>("CounterpartyType")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar");

                    b.Property<string>("EBAAccountCode")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar");

                    b.Property<string>("EBAAccountName")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar");

                    b.Property<decimal>("EBAWeight")
                        .HasPrecision(7, 4)
                        .HasColumnType("decimal");

                    b.Property<decimal>("FXRate")
                        .HasPrecision(28)
                        .HasColumnType("decimal");

                    b.Property<string>("FlowCategoryName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar");

                    b.Property<bool>("ForwardStarterFlag")
                        .HasColumnType("bit");

                    b.Property<string>("HQLAInflowOutflowOtherName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar");

                    b.Property<string>("InstrumentCode")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<bool>("LCRTenorApplicableFlag")
                        .HasColumnType("bit");

                    b.Property<int>("PartitionID")
                        .HasColumnType("int");

                    b.Property<string>("PathFinderRunID")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("ProductCode")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("ReportingEntityCode")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar");

                    b.Property<string>("ReportingFolderCode")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("SatelliteCashflowMaturityDate")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<DateTime>("SatelliteRunDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SatelliteRunID")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("SourceSystemName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("TradeID")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("TradeLegID")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.HasKey("ID");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("ID"), false);

                    b.HasIndex("SatelliteRunID", "PartitionID");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("SatelliteRunID", "PartitionID"));

                    b.ToTable("Staging");
                });

            modelBuilder.Entity("Fl.Azure.Calculator.Model.Entities.Status", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("AggregationMetric")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Initiator")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Metric")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<int?>("PartitionID")
                        .HasColumnType("int");

                    b.Property<string>("SatelliteRunID")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Scenario")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Fl.Azure.Calculator.Model.MetricResult", b =>
                {
                    b.Property<string>("CloseOfBusinessDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetricName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SatelliteRunDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SatelliteRunID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scenario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalAmount")
                        .HasPrecision(28, 9)
                        .HasColumnType("decimal(28,9)");

                    b.ToTable((string)null);

                    b.ToView("MetricResult", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
