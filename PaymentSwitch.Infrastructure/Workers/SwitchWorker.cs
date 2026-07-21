using Microsoft.Extensions.Hosting;

namespace TopUp
{
    public class SwitchWorker : BackgroundService
    {
        private readonly IQueueService _queue;
        private readonly ISwitchService _switch;
        private const string AdviceQueue = "Advice";
        private const string ReverseQueue = "Reverse";
        

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

                var message =
                    await _queue.DequeueAsync<Transaction>(
                        "Success");


                if (message is null)
                {
                    continue;
                }

                await _switch.AdviceAsync(
                        successRequest.TransactionId);



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
