namespace TopUp
{
    public class AdviceHandler : ITransactionHandler
    {
        private readonly IShaparakService _shaparakService;
        public TransactionType Type => TransactionType.Advice;

        public AdviceHandler(IShaparakService shaparakService)
            => _shaparakService = shaparakService;

        public Task<OperationResponse> HandleAsync(Transaction transaction)
            => _shaparakService.ReverseAsync(transaction);
    }
}
