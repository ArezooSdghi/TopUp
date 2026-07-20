
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

        public Task HandleAsync(Transaction transaction)
        {
            return _switchService.ProcessPurchaseAsync(transaction);d
        }
    }
}
