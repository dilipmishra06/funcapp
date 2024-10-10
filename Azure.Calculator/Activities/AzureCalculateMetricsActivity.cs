using Microsoft.Azure.Functions.Worker;
using Fl.Azure.Calculator.Core;
using Fl.Azure.Calculator.Process.Interfaces;

namespace Fl.Azure.Calculator
{
    public class AzureCalculateMetricsActivity
    {

        private readonly ICalculateMetricsLogic _calculateMetricsLogic;

        public AzureCalculateMetricsActivity(ICalculateMetricsLogic calculateMetricsLogic)
        {
            _calculateMetricsLogic = calculateMetricsLogic;
        }

        [Function(nameof(AzureCalculateMetricsActivity))]
        public async Task<CalculationResult> ExecuteAsync([ActivityTrigger] CalculationInput calculationInput)
        {
            return await _calculateMetricsLogic.ExecuteAsync(calculationInput);
        }
    }
}
