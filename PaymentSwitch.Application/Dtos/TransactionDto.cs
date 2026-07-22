using PaymentSwitch.Domain.Enums;

namespace PaymentSwitch.Application.Dtos
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public int TerminalId { get; set; }
        public int RetryCount { get; set; }
        public string? MobileNo { get; set; }
        public string? CardNumber { get; set; }
        public TransactionType Type { get; set; }
        public TransactionStep Step { get; set; }
    }
}
