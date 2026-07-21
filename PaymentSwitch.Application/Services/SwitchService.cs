
namespace TopUp
{
    public class SwitchService : ISwitchService
    {
        private readonly ITransactionDispatcher _dispatcher;

        public SwitchService(ITransactionDispatcher dispatcher)
            => _dispatcher = dispatcher;

        public async Task<OperationResponse> ProcessAsync(Transaction transaction)
            => await _dispatcher.DispatchAsync(transaction);
    }
}
