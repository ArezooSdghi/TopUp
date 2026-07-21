using Microsoft.Extensions.Hosting;

namespace TopUp
{
    public class TopupWorker : BackgroundService
    {
        private const int MaxRetryCount = 3;
        private const string TopupQueue = "Topup";
        private const string AdviceQueue = "Advice";
        private const string ReverseQueue = "Reverse";

        private readonly IQueueService _queueService;
        private readonly ITopupService _topupService;

        public TopupWorker(IQueueService queueService, ITopupService topupService)
        {
            _queueService = queueService;
            _topupService = topupService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var request = await _queueService.DequeueAsync<Transaction>(TopupQueue);

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
                await _queueService.EnqueueAsync(AdviceQueue, transaction);
                return;
            }

            transaction.RetryCount++;
            if (transaction.RetryCount < MaxRetryCount)
            {
                await _queueService.EnqueueAsync(TopupQueue, transaction);
                return;
            }

            await _queueService.EnqueueAsync(ReverseQueue, transaction);
        }
    }
}
