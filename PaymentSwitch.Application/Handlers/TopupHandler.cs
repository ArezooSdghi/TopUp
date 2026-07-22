using PaymentSwitch.Application.Common.Constants;
using PaymentSwitch.Application.Common.Models;
using PaymentSwitch.Application.Dtos;
using PaymentSwitch.Application.Interfaces;
using PaymentSwitch.Domain.Enums;

namespace PaymentSwitch.Application.Handlers
{
    public class TopupHandler : ITransactionHandler, IStepBasedTransactionHandler
    {
        private readonly IQueueService _queueService;
        private readonly IShaparakService _shaparakService;

        public TransactionType Type => TransactionType.Topup;
        TransactionStep? IStepBasedTransactionHandler.Step => TransactionStep.Execute;

        public TopupHandler(
            IQueueService queueService,
            IShaparakService shaparakService)
        {
            _queueService = queueService;
            _shaparakService = shaparakService;
        }

        public async Task<OperationResponse> HandleAsync(TransactionDto transaction)
        {
            var result = await _shaparakService.PurchaseAsync(transaction);
            if (!result.IsSuccess) return result;

            await _queueService.EnqueueAsync<TransactionDto>(nameof(QueueNames.Topup), transaction);

            return new OperationResponse
            {
                IsSuccess = true,
                ReferenceNumber = result.ReferenceNumber,
                Message = "Payment successful. Topup pending"
            };
        }
    }
}
