
using Fl.Azure.Calculator.External.Connectivity.Enums;
namespace Fl.Azure.Calculator.External.Connectivity.Probe.Interfaces;

public interface IProbeResult
{
    public ProbeStatus Status { get; }
    public string Name {  get; }
    public Exception? Exception { get; }



}
