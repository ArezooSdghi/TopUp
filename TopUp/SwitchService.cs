
namespace TopUp
{
    public class SwitchService : ISwitchService
    {
        

        public Task<OperationResponse> ProcessAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        //private readonly IQueueService _queueService;
        //private readonly ILogger<SwitchService> _logger;
        //private readonly IShaparakService _shaparakService;

        //public SwitchService(IQueueService queueService, IShaparakService shaparakService, ILogger<SwitchService> logger)
        //{
        //    _logger = logger;
        //    _queueService = queueService;
        //    _shaparakService = shaparakService;
        //}

        //public async Task<OperationResponse> AdviceAsync(Transaction transaction)
        //    => await _shaparakService.AdviceAsync(transaction);

        //public async Task<OperationResponse> ProcessPurchaseAsync(Transaction transaction)
        //    => await _shaparakService.PurchaseAsync(transaction);

        //public async Task<OperationResponse> ProcessTopupAsync(Transaction transaction)
        //{
        //    var purchaseResult = await _shaparakService.PurchaseAsync(transaction);
        //    if (!purchaseResult.IsSuccess) return purchaseResult;

        //    try
        //    {
        //        await _queueService.EnqueueAsync<TopupRequest>("Topup", new TopupRequest
        //        {
        //            Amount = transaction.Amount,
        //            Mobile = transaction.MobileNo,
        //            TransactionId = transaction.Id
        //        });

        //        return new OperationResponse
        //        {
        //            IsSuccess = true,
        //            Message = "Payment successful. Topup pending",
        //            ReferenceNumber = purchaseResult.ReferenceNumber
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"Topup enqueue failed for transaction {transaction.Id}");
        //        var reverseResult = await _shaparakService.ReverseAsync(transaction);

        //        return new OperationResponse
        //        {
        //            IsSuccess = false,
        //            Message = reverseResult.IsSuccess
        //            ? "Payment reversed"
        //            : "Payment successful but reverse failed"
        //        };
        //    }
        //}

        //public async Task<OperationResponse> ReverseAsync(Transaction transaction)
        //    => await _shaparakService.ReverseAsync(transaction);       
    }
}
