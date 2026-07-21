using PaymentSwitch.Application.Common.Models;
using PaymentSwitch.Application.Interfaces;
using PaymentSwitch.Domain.Entities;
using PaymentSwitch.Domain.Enums;

namespace PaymentSwitch.Application.Handlers
{
    public class ReverseHandler : ITransactionHandler
    {
        private readonly IShaparakService _shaparakService;
        public TransactionType Type => TransactionType.Reverse;

        public ReverseHandler(IShaparakService shaparakService)
            => _shaparakService = shaparakService;

        public async Task<OperationResponse> HandleAsync(Transaction transaction)
            => await _shaparakService.ReverseAsync(transaction);
    }
}
