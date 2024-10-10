namespace Fl.Azure.Calculator.Core
{
    public class ScenarioRepository: IScenarioRepository
    {
        private readonly Dictionary<string, IScenario> _scenarios = new();
        public ScenarioRepository()
        {
            RegisterScenarios();
        }

        public Dictionary<string, IScenario> Scenarios => _scenarios;

        private void RegisterScenarios()
        {
            _scenarios.Add(Scenario.Actual, new Actual());
        }

    }
}
