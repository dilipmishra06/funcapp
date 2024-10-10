using Fl.Azure.Calculator.Model.Entities;

namespace Fl.Azure.Calculator.Core
{
    public class LCREUQSurplus : IMetric
    {
        public string Name { get => "LCR EUQ Surplus"; }

        public string Currency { get => "EUQ"; }

        public CashflowMetricResult Execute(BalanceSheet balanceSheet)
        {
            var metricResult = balanceSheet.ToCashflowMetricResult();

            if (!balanceSheet.LCRTenorApplicableFlag || balanceSheet.EBAWeight == 0M)
                return metricResult;

            metricResult.CashFlowLCREUQAmount = balanceSheet.CashflowBalanceEUQAmount * balanceSheet.EBAWeight;
            return metricResult;
        }
    }
}
