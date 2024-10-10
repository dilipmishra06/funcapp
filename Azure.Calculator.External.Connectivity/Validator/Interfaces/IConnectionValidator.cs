using Fl.Azure.Calculator.External.Connectivity.Validator.Models;


namespace Fl.Azure.Calculator.External.Connectivity.Validator.Interfaces
{
    public interface IConnectionValidator
    {
        Task<ProbeResultSummaryModel> ValidateAsync(CancellationToken cancellationToken = default);
    }
}
