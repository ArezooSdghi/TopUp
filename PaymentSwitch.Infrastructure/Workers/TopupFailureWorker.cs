using Microsoft.Extensions.Logging;
using TopUp;

namespace PaymentSwitch.Infrastructure.Workers
{
    public class TopupFailureWorker : TopupTransactionWorker
    {
        protected override string QueueName => "Reverse";

        public TopupFailureWorker(
            IQueueService queueService,
            ITransactionDispatcher dispatcher,
            ILogger<TopupTransactionWorker> logger)
            : base(queueService, dispatcher, logger)
        {
        }
    }
}
