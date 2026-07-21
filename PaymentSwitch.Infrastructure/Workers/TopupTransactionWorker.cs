using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TopUp;

namespace PaymentSwitch.Infrastructure.Workers
{
    public abstract class TopupTransactionWorker : BackgroundService
    {
        private readonly IQueueService _queueService;
        private readonly ITransactionDispatcher _dispatcher;
        private readonly ILogger<TopupTransactionWorker> _logger;

        public TopupTransactionWorker(
            IQueueService queueService,
            ITransactionDispatcher dispatcher,
            ILogger<TopupTransactionWorker> logger)
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
                    var transaction = await _queueService.DequeueAsync<Transaction>(QueueName);

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


        //    protected override Task ExecuteAsync(CancellationToken stoppingToken)
        //    {
        //        while (!stoppingToken.IsCancellationRequested)
        //        {

        //            // Check Success Queue

        //            //var message =
        //            //    await _queue.DequeueAsync<Transaction>(
        //            //        "Success");


        //            //if (message is null)
        //            //{
        //            //    continue;
        //            //}

        //            //await _switch.AdviceAsync(
        //            //        successRequest.TransactionId);



        //            //// Check Failed Queue

        //            //var failedRequest =
        //            //    await _queue.DequeueAsync<TopupRequest>(
        //            //        "Failed");


        //            //if (failedRequest != null)
        //            //{
        //            //    await _switch.ReverseAsync(
        //            //        failedRequest.TransactionId);
        //            //}



        //            ///*await Task.Delay(500);*/
        //        }
        //}
    }
