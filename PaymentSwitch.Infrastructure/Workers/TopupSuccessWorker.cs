using Microsoft.Extensions.Logging;
using PaymentSwitch.Application.Common.Constants;
using PaymentSwitch.Application.Interfaces;

namespace PaymentSwitch.Infrastructure.Workers
{
    public class TopupSuccessWorker : TopupBaseWorker
    {
        protected override string QueueName => nameof(QueueNames.Advice);

        public TopupSuccessWorker(
            IQueueService queueService,
            ITransactionDispatcher dispatcher,
            ILogger<TopupBaseWorker> logger)
            : base(queueService, dispatcher, logger)
        {
        }
    }
}
