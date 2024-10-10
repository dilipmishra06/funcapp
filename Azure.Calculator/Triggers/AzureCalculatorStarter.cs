using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.DurableTask.Client;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Fl.Azure.Calculator.Models;

namespace Fl.Azure.Calculator.Triggers
{
    public class AzureCalculatorStarter
    {
        [Function("AzureCalculatorStarter")]
        public async Task<HttpResponseData> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req,
            [DurableClient] DurableTaskClient client,
            FunctionContext executionContext)
        {
            ILogger logger = executionContext.GetLogger<AzureCalculatorStarter>();

            var orchestrationOptions = await GetOrchestrationOptionsFromRequest(req);

            var instanceId = await client.ScheduleNewOrchestrationInstanceAsync(
                nameof(AzureCalculatorOrchestrator), orchestrationOptions);

            logger.LogInformation("Started orchestration with ID = '{instanceId}'", instanceId);

            return await client.CreateCheckStatusResponseAsync(req, instanceId);
        }

        private static async Task<OrchestrationOptions?> GetOrchestrationOptionsFromRequest(HttpRequestData req)
        {
            var body = await req.ReadAsStringAsync();

            return !string.IsNullOrWhiteSpace(body)
                ? JsonSerializer.Deserialize<OrchestrationOptions>(body)
                : null;
        }
    }
}
