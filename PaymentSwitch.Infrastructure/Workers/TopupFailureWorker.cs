using Microsoft.Extensions.Logging;
using PaymentSwitch.Application.Common.Constants;
using PaymentSwitch.Application.Interfaces;

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
