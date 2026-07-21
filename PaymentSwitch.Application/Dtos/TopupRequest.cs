namespace TopUp
{
    public class TopupRequest
    {
        public string? Mobile { get; set; } 
        public int RetryCount { get; set; }
        public decimal Amount { get; set; }
        public Guid TransactionId { get; set; }
    }
}
