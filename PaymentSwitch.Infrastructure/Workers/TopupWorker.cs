using Microsoft.Extensions.Hosting;
using PaymentSwitch.Infrastructure.Queue;

namespace TopUp
{
    public class TopupWorker : BackgroundService
    {
        private const int MaxRetryCount = 3;
        private readonly IQueueService _queueService;
        private readonly ITopupService _topupService;

        public TopupWorker(
            IQueueService queueService,
            ITopupService topupService)
        {
            _queueService = queueService;
            _topupService = topupService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var request = await _queueService.DequeueAsync<Transaction>(nameof(QueueNames.Topup));

                if (request is null)
                {
                    await Task.Delay(500, stoppingToken);
                    continue;
                }

                await ProcessRequestAsync(request);
            }
        }

        private async Task ProcessRequestAsync(Transaction transaction)
        {
            var isSuccess = await _topupService.ChargeAsync(new TopupRequest
            {
                Amount = transaction.Amount,
                Mobile = transaction.MobileNo,
                TransactionId = transaction.Id
            });

            if (isSuccess)
            {
                await _queueService.EnqueueAsync(nameof(QueueNames.Advice), transaction);
                return;
            }

            transaction.RetryCount++;
            if (transaction.RetryCount < MaxRetryCount)
            {
                await _queueService.EnqueueAsync(nameof(QueueNames.Topup), transaction);
                return;
            }

            await _queueService.EnqueueAsync(nameof(QueueNames.Reverse), transaction);
        }
    }
}
