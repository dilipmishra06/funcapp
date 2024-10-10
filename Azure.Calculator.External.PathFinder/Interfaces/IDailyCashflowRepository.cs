using Fl.Azure.Calculator.External.PathFinder.Models;

namespace Fl.Azure.Calculator.External.PathFinder.Interfaces;

public interface IDailyCashflowRepository
{
    Task<Control?> GetLatestMurexControl();
    Task<Control?> GetSpecificMurexControl(string closeOfBusinessDate);
    Task<IReadOnlyCollection<DailyCashflow>> GetDailyCashflows(Control control);
}
