using Microsoft.Extensions.Hosting;

namespace TopUp
{
    public class SwitchWorker : BackgroundService
    {
        private readonly IQueueService _queue;
        private readonly ISwitchService _switch;

        public SwitchWorker(
            IQueueService queue,
            ISwitchService switchService)
        {
            _queue = queue;
            _switch = switchService;
        }


        protected override async Task ExecuteAsync(
            CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {

                // Check Success Queue

                var successRequest =
                    await _queue.DequeueAsync<TopupRequest>(
                        "Success");


                if (successRequest != null)
                {
                    await _switch.AdviceAsync(
                        successRequest.TransactionId);
                }



                // Check Failed Queue

                var failedRequest =
                    await _queue.DequeueAsync<TopupRequest>(
                        "Failed");


                if (failedRequest != null)
                {
                    await _switch.ReverseAsync(
                        failedRequest.TransactionId);
                }



                await Task.Delay(500);
            }
        }
    }
}
