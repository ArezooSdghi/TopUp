using PaymentSwitch.Application.Common.Models;
using PaymentSwitch.Application.Interfaces;
using PaymentSwitch.Domain.Entities;
using PaymentSwitch.Domain.Enums;

namespace PaymentSwitch.Application.Handlers
{
    public class AdviceHandler : ITransactionHandler
    {
        private readonly IShaparakService _shaparakService;
        public TransactionType Type => TransactionType.Advice;

        public AdviceHandler(IShaparakService shaparakService)
            => _shaparakService = shaparakService;

        public Task<OperationResponse> HandleAsync(Transaction transaction)
            => _shaparakService.AdviceAsync(transaction);
    }
}
