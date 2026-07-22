using Microsoft.Extensions.Hosting;
using PaymentSwitch.Application.Common.Constants;
using PaymentSwitch.Application.Dtos;
using PaymentSwitch.Application.Interfaces;
using PaymentSwitch.Domain.Enums;

namespace PaymentSwitch.Infrastructure.Workers
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
                var request = await _queueService.DequeueAsync<TransactionDto>(nameof(QueueNames.Topup));

                if (request is null)
                {
                    await Task.Delay(500, stoppingToken);
                    continue;
                }

                await ProcessRequestAsync(request);
            }
        }

        private async Task ProcessRequestAsync(TransactionDto transaction)
        {
            var isSuccess = await _topupService.ChargeAsync(new TopupRequest
            {
                Amount = transaction.Amount,
                Mobile = transaction.MobileNo,
                TransactionId = transaction.Id
            });

            if (isSuccess)
            {
                transaction.Step = TransactionStep.Advice;
                await _queueService.EnqueueAsync(nameof(QueueNames.Advice), transaction);
                return;
            }

            transaction.RetryCount++;
            if (transaction.RetryCount < MaxRetryCount)
            {
                transaction.Step = TransactionStep.Execute;
                await _queueService.EnqueueAsync(nameof(QueueNames.Topup), transaction);
                return;
            }

            transaction.Step = TransactionStep.Reverse;
            await _queueService.EnqueueAsync(nameof(QueueNames.Reverse), transaction);
        }
    }
}
