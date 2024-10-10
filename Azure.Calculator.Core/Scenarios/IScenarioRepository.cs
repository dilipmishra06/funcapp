namespace Fl.Azure.Calculator.Core
{
    public interface IScenarioRepository
    {
        Dictionary<string, IScenario> Scenarios { get; }
    }
}
