using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkerTemplate
{
    public class WorkerService : BackgroundService
    {
        private readonly ILogger<WorkerService> _logger;
        public WorkerService(ILogger<WorkerService> logger)
        {
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting background job");

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Doing work");

                await Task.Delay(1000);
            }

            _logger.LogInformation("Shutting down");
        }
    }
}