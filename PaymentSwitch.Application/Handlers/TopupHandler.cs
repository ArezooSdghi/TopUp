
using PaymentSwitch.Infrastructure.Queue;

namespace TopUp
{
    public class TopupHandler : ITransactionHandler
    {
        private readonly IQueueService _queueService;
        private readonly IShaparakService _shaparakService;

        public TransactionType Type => TransactionType.Topup;

        public TopupHandler(
            IQueueService queueService,
            IShaparakService shaparakService)
        {
            _queueService = queueService;
            _shaparakService = shaparakService;
        }

        public async Task<OperationResponse> HandleAsync(Transaction transaction)
        {
            var result = await _shaparakService.PurchaseAsync(transaction);
            if (!result.IsSuccess) return result;

            await _queueService.EnqueueAsync<Transaction>(nameof(QueueNames.Topup), transaction);

            return new OperationResponse
            {
                IsSuccess = true,
                ReferenceNumber = result.ReferenceNumber,
                Message = "Payment successful. Topup pending"
            };
        }
    }
}
