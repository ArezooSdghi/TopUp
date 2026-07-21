using Microsoft.Extensions.Logging;
using PaymentSwitch.Infrastructure.Queue;
using TopUp;

namespace PaymentSwitch.Infrastructure.Workers
{
    public class TopupSuccessWorker : TopupTransactionWorker
    {
        protected override string QueueName => nameof(QueueNames.Advice);

        public TopupSuccessWorker(
            IQueueService queueService,
            ITransactionDispatcher dispatcher,
            ILogger<TopupTransactionWorker> logger)
            : base(queueService, dispatcher, logger)
        {
        }
    }
}
