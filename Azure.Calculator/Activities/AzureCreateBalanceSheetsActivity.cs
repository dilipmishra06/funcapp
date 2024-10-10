using Microsoft.Azure.Functions.Worker;
using Fl.Azure.Calculator.Core;
using Fl.Azure.Calculator.Process.Interfaces;

namespace Fl.Azure.Calculator
{
    public class AzureCreateBalanceSheetsActivity
    {
        private readonly ICreateBalanceSheetLogic _createBalanceSheetLogic;

        public AzureCreateBalanceSheetsActivity(ICreateBalanceSheetLogic createBalanceSheetLogic)
        {
            _createBalanceSheetLogic = createBalanceSheetLogic;
        }

        [Function(nameof(AzureCreateBalanceSheetsActivity))]
        public async Task ExecuteAsync([ActivityTrigger] BalanceSheetIdentifier balanceSheetIdentifier)
        {
            await _createBalanceSheetLogic.ExecuteAsync(balanceSheetIdentifier);
        }
    }
}
