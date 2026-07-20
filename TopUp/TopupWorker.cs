
namespace TopUp
{
    public class TopupWorker : BackgroundService
    {
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
                var request = await _queueService.DequeueAsync<TopupRequest>("Topup");

                if (request is null)
                {
                    await Task.Delay(500);
                    continue;
                }

                var result = await _topupService.ChargeAsync(request);

                if (result)
                {
                    await _queueService.EnqueueAsync("Success", request);
                }
                else
                {
                    request.RetryCount++;
                    if (request.RetryCount < 3)
                    {
                        await Task.Delay(2000);
                        await _queueService.EnqueueAsync("Topup", request);
                    }
                    else
                    {
                        await _queueService.EnqueueAsync("Failed", request);
                    }
                }
            }
        }
    }
}
