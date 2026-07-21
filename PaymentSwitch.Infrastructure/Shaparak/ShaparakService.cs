namespace TopUp
{
    public class ShaparakService : IShaparakService
    {
        private readonly ILogger<ShaparakService> _logger;

        public ShaparakService(ILogger<ShaparakService> logger)
        {
            _logger = logger;
        }

        public async Task<OperationResponse> AdviceAsync(Transaction transaction)
        {
            _logger.LogInformation($"Advice Request | TransactionId:{transaction.Id}");

            await Task.Delay(500);

            return new OperationResponse
            {
                IsSuccess = true,
                Message = "Advice Success",
                ReferenceNumber = Guid.NewGuid().ToString("N")
            };
        }

        public async Task<OperationResponse> PurchaseAsync(Transaction transaction)
        {
            _logger.LogInformation($"Purchase Request | TransactionId:{transaction.Id}");

            await Task.Delay(1000);

            return new OperationResponse
            {
                IsSuccess = true,
                Message = "Purchase Success",
                ReferenceNumber = Guid.NewGuid().ToString("N")
            };
        }

        public async Task<OperationResponse> ReverseAsync(Transaction transaction)
        {
            _logger.LogInformation($"Reverse Request | TransactionId:{transaction.Id}");

            await Task.Delay(500);

            return new OperationResponse
            {
                IsSuccess = true,
                Message = "Reverse Success",
                ReferenceNumber = Guid.NewGuid().ToString("N")
            };
        }
    }
}
