using Fl.Azure.Calculator.Model.Entities;

namespace Fl.Azure.Calculator.Core
{
    public interface IScenario
    {
        IQueryable<Staging> Execute(IQueryable<Staging> staging);
    }
}
