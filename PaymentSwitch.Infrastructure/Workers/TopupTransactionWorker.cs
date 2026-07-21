using Microsoft.Extensions.Hosting;

namespace PaymentSwitch.Infrastructure.Workers
{
    public abstract class TopupTransactionWorker : BackgroundService
    {
        protected abstract string QueueName { get; }
    }
}
