using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Azure.Calculator.Model.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BalanceSheet",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scenario = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PathFinderRunID = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    SatelliteRunID = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PartitionID = table.Column<int>(type: "int", nullable: false),
                    SatelliteRunDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SourceSystemName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CloseOfBusinessDate = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CashflowID = table.Column<decimal>(type: "decimal(20,8)", precision: 20, scale: 8, nullable: false),
                    TradeID = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    TradeLegID = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    SatelliteCashflowMaturityDate = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ForwardStarterFlag = table.Column<bool>(type: "bit", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ReportingFolderCode = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    InstrumentCode = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    CounterpartyCode = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CounterpartyName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CounterpartyClass = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    CounterpartyType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ReportingEntityCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CashflowBalanceOriginalCurrencyAmount = table.Column<decimal>(type: "decimal(28,9)", precision: 28, scale: 9, nullable: false),
                    FXRate = table.Column<decimal>(type: "decimal(28,0)", precision: 28, scale: 0, nullable: false),
                    CashflowBalanceEUQAmount = table.Column<decimal>(type: "decimal(28,9)", precision: 28, scale: 9, nullable: false),
                    FlowCategoryName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    HQLAInflowOutflowOtherName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    LCRTenorApplicableFlag = table.Column<bool>(type: "bit", nullable: false),
                    EBAAccountName = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    EBAAccountCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    EBAWeight = table.Column<decimal>(type: "decimal(7,4)", precision: 7, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalanceSheet", x => x.ID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "CashflowMetricResult",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SatelliteRunID = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Scenario = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PartitionID = table.Column<int>(type: "int", nullable: false),
                    CashFlowID = table.Column<decimal>(type: "decimal(20,0)", precision: 20, scale: 0, nullable: false),
                    SatelliteRunDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CloseOfBusinessDate = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    HQLAInflowOutflowOtherName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CashFlowLCREUQAmount = table.Column<decimal>(type: "decimal(28,9)", precision: 28, scale: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashflowMetricResult", x => x.ID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "MetricAggregationResult",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SatelliteRunID = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Scenario = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PartitionID = table.Column<int>(type: "int", nullable: false),
                    SatelliteRunDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CloseOfBusinessDate = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    HQLAInflowOutflowOtherName = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    MetricName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(28,9)", precision: 28, scale: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetricAggregationResult", x => x.ID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Staging",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PathFinderRunID = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    SatelliteRunID = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PartitionID = table.Column<int>(type: "int", nullable: false),
                    SatelliteRunDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SourceSystemName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CloseOfBusinessDate = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CashflowID = table.Column<decimal>(type: "decimal(20,8)", precision: 20, scale: 8, nullable: false),
                    TradeID = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    TradeLegID = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    SatelliteCashflowMaturityDate = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ForwardStarterFlag = table.Column<bool>(type: "bit", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ReportingFolderCode = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    InstrumentCode = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    CounterpartyCode = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CounterpartyName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CounterpartyClass = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    CounterpartyType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ReportingEntityCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CashflowBalanceOriginalCurrencyAmount = table.Column<decimal>(type: "decimal(28,9)", precision: 28, scale: 9, nullable: false),
                    FXRate = table.Column<decimal>(type: "decimal(28,0)", precision: 28, scale: 0, nullable: false),
                    CashflowBalanceEUQAmount = table.Column<decimal>(type: "decimal(28,9)", precision: 28, scale: 9, nullable: false),
                    FlowCategoryName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    HQLAInflowOutflowOtherName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    LCRTenorApplicableFlag = table.Column<bool>(type: "bit", nullable: false),
                    EBAAccountName = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    EBAAccountCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    EBAWeight = table.Column<decimal>(type: "decimal(7,4)", precision: 7, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staging", x => x.ID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Initiator = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    SatelliteRunID = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Scenario = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Metric = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    AggregationMetric = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    PartitionID = table.Column<int>(type: "int", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BalanceSheet_SatelliteRunID_Scenario_PartitionID",
                table: "BalanceSheet",
                columns: new[] { "SatelliteRunID", "Scenario", "PartitionID" })
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_CashflowMetricResult_SatelliteRunID_Scenario_PartitionID",
                table: "CashflowMetricResult",
                columns: new[] { "SatelliteRunID", "Scenario", "PartitionID" })
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_MetricAggregationResult_SatelliteRunID_Scenario_PartitionID",
                table: "MetricAggregationResult",
                columns: new[] { "SatelliteRunID", "Scenario", "PartitionID" })
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_Staging_SatelliteRunID_PartitionID",
                table: "Staging",
                columns: new[] { "SatelliteRunID", "PartitionID" })
                .Annotation("SqlServer:Clustered", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BalanceSheet");

            migrationBuilder.DropTable(
                name: "CashflowMetricResult");

            migrationBuilder.DropTable(
                name: "MetricAggregationResult");

            migrationBuilder.DropTable(
                name: "Staging");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
