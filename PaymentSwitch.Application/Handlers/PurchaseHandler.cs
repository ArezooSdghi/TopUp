using PaymentSwitch.Application.Common.Models;
using PaymentSwitch.Application.Dtos;
using PaymentSwitch.Application.Interfaces;
using PaymentSwitch.Domain.Enums;

namespace PaymentSwitch.Application.Handlers
{
    public class PurchaseHandler : ITransactionHandler
    {
        private readonly IShaparakService _shaparakService;
        public TransactionType Type => TransactionType.Purchase;

        public PurchaseHandler(IShaparakService shaparakService)
            => _shaparakService = shaparakService;

        public async Task<OperationResponse> HandleAsync(TransactionDto transaction)
            => await _shaparakService.PurchaseAsync(transaction);
    }
}
