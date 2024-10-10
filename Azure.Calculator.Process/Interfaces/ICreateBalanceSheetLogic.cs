using Fl.Azure.Calculator.Core;

namespace Fl.Azure.Calculator.Process.Interfaces;

public interface ICreateBalanceSheetLogic
{
    Task ExecuteAsync(BalanceSheetIdentifier balanceSheetIdentifier);
}
