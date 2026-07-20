namespace TopUp
{
    public class TopupRequest
    {
        public int RetryCount { get; set; }
        public required string Mobile { get; set; }
        public required decimal Amount { get; set; }
        public required Guid TransactionId { get; set; }
    }
}
