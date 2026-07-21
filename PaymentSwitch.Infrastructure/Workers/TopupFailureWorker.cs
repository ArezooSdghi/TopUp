using Microsoft.Extensions.Logging;
using PaymentSwitch.Infrastructure.Queue;
using TopUp;

namespace PaymentSwitch.Infrastructure.Workers
{
    public class TopupFailureWorker : TopupTransactionWorker
    {
        protected override string QueueName => nameof(QueueNames.Reverse);

        public TopupFailureWorker(
            IQueueService queueService,
            ITransactionDispatcher dispatcher,
            ILogger<TopupTransactionWorker> logger)
            : base(queueService, dispatcher, logger)
        {
        }
    }
}
