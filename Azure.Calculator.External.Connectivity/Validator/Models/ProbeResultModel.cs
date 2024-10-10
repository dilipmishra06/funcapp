using Fl.Azure.Calculator.External.Connectivity.Enums;
using Fl.Azure.Calculator.External.Connectivity.Probe.Interfaces;
using System.ServiceModel;

namespace Fl.Azure.Calculator.External.Connectivity.Validator.Models;

public class ProbeResultModel(IProbeResult probeResult)
{
    public string Name => probeResult.Name;
    public ProbeStatus Status => probeResult.Status;

    public ExceptionDetail? Exception => probeResult.Exception != null ? new ExceptionDetail(probeResult.Exception) : null;
}
