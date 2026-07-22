using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PaymentSwitch.Application.Dtos;
using PaymentSwitch.Application.Interfaces;

namespace PaymentSwitch.Infrastructure.Workers
{
    public abstract class TopupBaseWorker : BackgroundService
    {
        private readonly IQueueService _queueService;
        private readonly ITransactionDispatcher _dispatcher;
        private readonly ILogger<TopupBaseWorker> _logger;

        public TopupBaseWorker(
            IQueueService queueService,
            ITransactionDispatcher dispatcher,
            ILogger<TopupBaseWorker> logger)
        {
            _logger = logger;
            _dispatcher = dispatcher;
            _queueService = queueService;
        }

        protected abstract string QueueName { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{GetType().Name} started. Queue: {QueueName}");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var transaction = await _queueService.DequeueAsync<TransactionDto>(QueueName);

                    if (transaction is null)
                    {
                        await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
                        continue;
                    }

                    await _dispatcher.DispatchAsync(transaction);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error processing transaction from queue {QueueName}");
                }

                await Task.Delay(500);
            }
        }
    }
}
