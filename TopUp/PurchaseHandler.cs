
namespace TopUp
{
    public class PurchaseHandler : ITransactionHandler
    {
        private readonly IShaparakService _shaparakService;
        public TransactionType Type => TransactionType.Purchase;

        public PurchaseHandler(IShaparakService shaparakService)
            => _shaparakService = shaparakService;

        public async Task<OperationResponse> HandleAsync(Transaction transaction)
            => await _shaparakService.PurchaseAsync(transaction);
    }
}
