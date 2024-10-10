using Fl.Azure.Calculator.External.Connectivity.Enums;

namespace Fl.Azure.Calculator.External.Connectivity.Validator.Models;

public class ProbeResultSummaryModel(ProbeResultModel[] results)
{
    public IReadOnlyCollection<ProbeResultModel> Results => results.AsReadOnly();
    public bool IsSuccess => Results.All(x=> x.Status == ProbeStatus.Success);

    public ProbeStatus Status => IsSuccess ? ProbeStatus.Success : ProbeStatus.Failed;
}
