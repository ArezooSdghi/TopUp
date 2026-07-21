using PaymentSwitch.Application.Common.Models;
using PaymentSwitch.Application.Interfaces;
using PaymentSwitch.Domain.Entities;

namespace PaymentSwitch.Application.Dispatchers
{
    public class TransactionDispatcher
    {
        private readonly IEnumerable<ITransactionHandler> _handlers;

        public TransactionDispatcher(IEnumerable<ITransactionHandler> handlers)
            => _handlers = handlers;

        public async Task<OperationResponse> DispatchAsync(Transaction transaction)
        {
            var handler = _handlers.FirstOrDefault(x => x.Type == transaction.Type);
            if (handler is null)
            {
                return new OperationResponse
                {
                    IsSuccess = false,
                    Message = "Unsupported transaction type"
                };
            }

            return await handler.HandleAsync(transaction);
        }
    }
}
