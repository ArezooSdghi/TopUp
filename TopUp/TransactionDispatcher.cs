namespace TopUp
{
    public class TransactionDispatcher
    {
        private readonly IEnumerable<ITransactionHandler> _handlers;

        public TransactionDispatcher(IEnumerable<ITransactionHandler> handlers)
        {
            _handlers = handlers;
        }

        public async Task DispatchAsync(Transaction transaction)
        {
            var handler = _handlers.FirstOrDefault(x => x.Type == transaction.Type);
            if (handler is null) throw new Exception("Handler not found");
            await handler.HandleAsync(transaction);
        }
    }
}
