
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
            //return _shaparakService.AdviceAsync()
            Console.WriteLine($"Advice sent for {transactionId}");
            return Task.CompletedTask;
        }

        public Task ProcessPurchaseAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public async Task<TransactionResponse> ProcessTopupAsync(Transaction transaction)
        {
            var paymentResult = await _shaparakService.PurchaseAsync(transaction);
            if (!paymentResult)
            {
                return new TransactionResponse
                {
                    IsSuccess = false,
                    Message = "Payment failed"
                };
            }

            await _queueService.EnqueueAsync<Transaction>("Topup", transaction);

            return new TransactionResponse
            {
                IsSuccess = true,
                Message = "Payment accepted",
                ReferenceNumber = ""
            };
        }

        public Task ReverseAsync(Guid transactionId)
        {
            Console.WriteLine($"Reverse sent for {transactionId}");
            return Task.CompletedTask;
        }
    }
}
