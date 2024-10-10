using Fl.Azure.Calculator.Core;

namespace Fl.Azure.Calculator.Process.Interfaces;

public interface ILoadStagingLogic
{
    Task<LoadStagingResult> ExecuteAsync(LoadStagingOptions options);
}
