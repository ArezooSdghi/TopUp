
namespace TopUp
{
    public class SwitchService : ISwitchService
    {
        private readonly IQueueService _queueService;
        private readonly IShaparakService _shaparakService;

        public SwitchService(IQueueService queueService, IShaparakService shaparakService)
        {
            _queueService = queueService;
            _shaparakService = shaparakService;
        }

        public Task AdviceAsync(Guid transactionId)
        {
            Console.WriteLine($"Advice sent for {transactionId}");
            return Task.CompletedTask;
        }

        public Task ProcessPurchaseAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Task ProcessTopupAsync(Transaction transaction)
        {
            return _queueService.EnqueueAsync<Transaction>("Topup", transaction);
        }

        public Task ReverseAsync(Guid transactionId)
        {
            Console.WriteLine($"Reverse sent for {transactionId}");
            return Task.CompletedTask;
        }
    }
}
