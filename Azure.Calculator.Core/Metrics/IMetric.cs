using Fl.Azure.Calculator.Model.Entities;

namespace Fl.Azure.Calculator.Core
{
    public interface IMetric
    {
        string Name { get; }

        string Currency {  get; }

        CashflowMetricResult Execute(BalanceSheet balanceSheet);
    }
}
