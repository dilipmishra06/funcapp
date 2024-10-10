using Fl.Azure.Calculator.Model.Configuration;
using Microsoft.EntityFrameworkCore;
using Mapster;


namespace Fl.Azure.Calculator.Model.Entities
{
    [EntityTypeConfiguration(typeof(StagingEntityTypeConfiguration))]
    public class Staging
    {
        [AdaptIgnore]
        public long ID { get; set; }

        public string PathFinderRunID { get; set; } = string.Empty;

        public string SatelliteRunID { get; set; } = string.Empty;

        public int PartitionID { get; set; }

        public DateTime SatelliteRunDate { get; set; } = DateTime.UtcNow;

        public string SourceSystemName { get; set; } = string.Empty;

        public string CloseOfBusinessDate { get; set; } = string.Empty;

        public decimal CashflowID { get; set; }

        public string TradeID { get; set; } = string.Empty;

        public string TradeLegID { get; set; } = string.Empty;

        public string SatelliteCashflowMaturityDate { get; set; } = string.Empty;

        public bool ForwardStarterFlag { get; set; }

        public string CurrencyCode { get; set; } = string.Empty;

        public string? ProductCode { get; set; }

        public string ReportingFolderCode { get; set; } = string.Empty;

        public string? InstrumentCode { get; set; } 

        public string CounterpartyCode { get; set; } = string.Empty;

        public string? CounterpartyName { get; set; } 

        public string? CounterpartyClass { get; set; }

        public string? CounterpartyType { get; set; }

        public string? ReportingEntityCode { get; set; } 

        public decimal CashflowBalanceOriginalCurrencyAmount { get; set; }

        public decimal FXRate { get; set; }

        public decimal CashflowBalanceEUQAmount { get; set; }

        public string FlowCategoryName { get; set; } = string.Empty;

        public string HQLAInflowOutflowOtherName { get; set; } = string.Empty;

        public bool LCRTenorApplicableFlag { get; set; }

        public string? EBAAccountName { get; set; } = string.Empty;

        public string? EBAAccountCode { get; set; } = string.Empty;

        public decimal EBAWeight { get; set; }

        public BalanceSheet ToBalanceSheet() => this.Adapt<BalanceSheet>();
    }
}
