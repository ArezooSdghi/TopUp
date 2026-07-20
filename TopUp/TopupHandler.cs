
namespace TopUp
{
    public class TopupHandler : ITransactionHandler
    {
        private readonly ISwitchService _switchService;
        public TransactionType Type => TransactionType.Topup;

        public TopupHandler(ISwitchService switchService)
        {
            _switchService = switchService;
        }

        public Task HandleAsync(Transaction transaction)
        {
            return _switchService.ProcessTopupAsync(transaction);
        }
    }
}
