
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Fl.Azure.Scheduler
{
    public class AzureScheduler
    {
        private readonly ILogger _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public AzureScheduler(ILoggerFactory loggerFactory, IHttpClientFactory httpClientFactory)
        {
            _logger = loggerFactory.CreateLogger<AzureScheduler>();
            _httpClientFactory = httpClientFactory;
        }

        [Function("AzureScheduler")]
        public async Task Run([TimerTrigger("*/3 * * * *")] TimerInfo timerInfo)
        {
            _logger.LogInformation($"Scheduler trigger function executed at {DateTime.UtcNow}");

            string url = Environment.GetEnvironmentVariable("CalculatorUrl") ?? "Calculator trigger URL not found";
            _logger.LogInformation($"Calculator trigger URL: {url}");

            var httpClient = _httpClientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await httpClient.SendAsync(httpRequestMessage);

            if (response != null && response.IsSuccessStatusCode)
            {
                _logger.LogInformation($"Calculator succeeded with status code: {response.StatusCode}");
            }
            else
            {
                _logger.LogError($"Calculator failed with status code: {response?.StatusCode}");
            }

            if (timerInfo.ScheduleStatus != null)
            {
                _logger.LogInformation($"Next timer schedule at: {timerInfo.ScheduleStatus.Next}");
            }
        }
    }
}
