
namespace TopUp
{
    public class PurchaseHandler : ITransactionHandler
    {
        private readonly ISwitchService _switchService;
        public TransactionType Type => TransactionType.Purchase;

        public PurchaseHandler(ISwitchService switchService)
        {
            _switchService = switchService;
        }

        public async Task<TransactionResponse> HandleAsync(Transaction transaction)
        {
            return await _switchService.ProcessPurchaseAsync(transaction);
        }
    }
}
