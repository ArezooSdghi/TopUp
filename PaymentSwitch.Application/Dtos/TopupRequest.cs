namespace PaymentSwitch.Application.Dtos
{
    public class TopupRequest
    {
        public string? Mobile { get; set; }
        public decimal Amount { get; set; }
        public Guid TransactionId { get; set; }
    }
}
