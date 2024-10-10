using Fl.Azure.Calculator.External.Connectivity.Probe.Interfaces;
using Fl.Azure.Calculator.External.Connectivity.Validator.Interfaces;
using Fl.Azure.Calculator.External.Connectivity.Validator.Models;

namespace Fl.Azure.Calculator.External.Connectivity.Validator;

internal class ConnectionValidator : IConnectionValidator 
{
    private readonly IEnumerable<IValidateConnection> _connections;

    public ConnectionValidator(IEnumerable<IValidateConnection> connections)
    {
        _connections = connections;
    }

    public async Task<ProbeResultSummaryModel> ValidateAsync(CancellationToken cancellationToken = default)
    {
        var results = await Task.WhenAll(_connections.Select(x=>x.ValidateConnection(cancellationToken)));
        var flattenedResults = results.SelectMany(x => x).Select(x => new ProbeResultModel(x)).ToArray();
        return new ProbeResultSummaryModel(flattenedResults);
    }

}
