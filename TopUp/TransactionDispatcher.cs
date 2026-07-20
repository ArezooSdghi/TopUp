namespace TopUp
{
    public class TransactionDispatcher
    {
        private readonly IEnumerable<ITransactionHandler> _handlers;

        public TransactionDispatcher(IEnumerable<ITransactionHandler> handlers)
        {
            _handlers = handlers;
        }

        public async Task<TransactionResponse> DispatchAsync(Transaction transaction)
        {
            var handler = _handlers.FirstOrDefault(x => x.Type == transaction.Type);
            if (handler is null)
            {
                return new TransactionResponse
                {
                    IsSuccess = false,
                    Message = "Handler not found"
                };
            }

            return await handler.HandleAsync(transaction);
        }
    }
}
