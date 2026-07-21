using Microsoft.Extensions.Logging;
using TopUp;

namespace PaymentSwitch.Infrastructure.Workers
{
    public class TopupSuccessWorker : TopupTransactionWorker
    {
        protected override string QueueName => "Advice";

        public TopupSuccessWorker(
            IQueueService queueService,
            ITransactionDispatcher dispatcher,
            ILogger<TopupTransactionWorker> logger)
            : base(queueService, dispatcher, logger)
        {
        }
    }
}
