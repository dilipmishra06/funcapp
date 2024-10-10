namespace Fl.Azure.Calculator.External.PathFinder.Models;

public class DailyCashflow
{
    public string PathFinderRunID { get; set; } = string.Empty;

    public int PartitionID { get; set; }

    public string SourceSystemName { get; set; } = string.Empty;

    public string CloseOfBusinessDate { get; set; } = string.Empty;

    public decimal CashflowID { get; set; }

    public string TradeID { get; set; } = string.Empty;

    public string TradeLegID { get; set; } = string.Empty;

    public string SatelliteCashflowMaturityDate { get; set; } = string.Empty;

    public bool ForwardStarterFlag { get; set; }

    public string CurrencyCode { get; set; } = string.Empty;

    public string? ProductCode { get; set; } = string.Empty;

    public string ReportingFolderCode { get; set; } = string.Empty;

    public string? InstrumentCode { get; set; } = string.Empty;

    public string CounterpartyCode { get; set; } = string.Empty;

    public string? CounterpartyName { get; set; } = string.Empty;

    public string? CounterpartyClass { get; set; } = string.Empty;

    public string? CounterpartyType { get; set; } = string.Empty;

    public string? ReportingEntityCode { get; set; } = string.Empty;

    public decimal CashflowBalanceOriginalCurrencyAmount { get; set; }

    public decimal FXRate { get; set; }

    public decimal CashflowBalanceEUQAmount { get; set; }

    public string FlowCategoryName { get; set; } = string.Empty;

    public string HQLAInflowOutflowOtherName { get; set; } = string.Empty;

    public bool LCRTenorApplicableFlag { get; set; }

    public string? EBAAccountName { get; set; } = string.Empty;

    public string? EBAAccountCode { get; set; } = string.Empty;

    public decimal EBAWeight { get; set; }
}
