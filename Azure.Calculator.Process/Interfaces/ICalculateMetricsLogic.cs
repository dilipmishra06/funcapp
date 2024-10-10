using Fl.Azure.Calculator.Core;
namespace Fl.Azure.Calculator.Process.Interfaces;

public interface ICalculateMetricsLogic
{
    Task<CalculationResult> ExecuteAsync(CalculationInput calculationInput);
}
