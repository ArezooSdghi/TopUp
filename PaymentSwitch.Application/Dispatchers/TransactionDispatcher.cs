using PaymentSwitch.Application.Common.Models;
using PaymentSwitch.Application.Dtos;
using PaymentSwitch.Application.Interfaces;

namespace PaymentSwitch.Application.Dispatchers
{
    public class TransactionDispatcher : ITransactionDispatcher
    {
        private readonly IEnumerable<ITransactionHandler> _handlers;

        public TransactionDispatcher(IEnumerable<ITransactionHandler> handlers)
            => _handlers = handlers;

        public async Task<OperationResponse> DispatchAsync(TransactionDto transaction)
        {
            var handler = _handlers.FirstOrDefault(
                x => transaction.Step != 0
                ? x.Type.ToString() == transaction.Step.ToString()
                : x.Type == transaction.Type);

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
