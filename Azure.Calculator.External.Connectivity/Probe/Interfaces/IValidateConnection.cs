namespace Fl.Azure.Calculator.External.Connectivity.Probe.Interfaces;

public interface IValidateConnection
{
    Task<IProbeResult[]> ValidateConnection(CancellationToken cancellationToken = default);
}
