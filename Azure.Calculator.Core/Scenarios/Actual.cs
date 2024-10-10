using Fl.Azure.Calculator.Model.Entities;

namespace Fl.Azure.Calculator.Core
{
    public class Actual : IScenario
    {
        public IQueryable<Staging> Execute(IQueryable<Staging> staging)
        {
            return staging.Where(s => true)
                          .Select(s => s);
        }
    }
}
