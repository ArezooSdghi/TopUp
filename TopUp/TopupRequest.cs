namespace TopUp
{
    public class TopupRequest
    {
        public int RetryCount { get; set; }
        public Guid TransactionId { get; set; }
        public required string Mobile { get; set; }
        public required decimal Amount { get; set; }
    }
}
