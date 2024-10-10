using Fl.Azure.Calculator.External.Connectivity.Enums;
using Fl.Azure.Calculator.External.Connectivity.Probe.Interfaces;

namespace Fl.Azure.Calculator.External.Connectivity.Probe.Helpers;

public record ProbeResult(string Name, ProbeStatus Status, Exception? Exception = null) : IProbeResult
{
    public static ProbeResult Pass(string name)
        => new(name,ProbeStatus.Success);
    public static ProbeResult Fail(string name, Exception exception)
        => new(name, ProbeStatus.Failed, Exception: exception);

}
