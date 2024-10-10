using Microsoft.Azure.Functions.Worker;
using Fl.Azure.Calculator.Core;
using Fl.Azure.Calculator.Process.Interfaces;

namespace Fl.Azure.Calculator
{
    public class AzureLoadStagingActivity
    {
        private readonly ILoadStagingLogic _loadStagingLogic;

        public AzureLoadStagingActivity(ILoadStagingLogic loadStagingLogic)
        {
            _loadStagingLogic = loadStagingLogic;
        }

        [Function(nameof(AzureLoadStagingActivity))]
        public async Task<LoadStagingResult> ExecuteAsync([ActivityTrigger] LoadStagingOptions loadStagingOptions)
        {
            return await _loadStagingLogic.ExecuteAsync(loadStagingOptions);
        }
    }
}
