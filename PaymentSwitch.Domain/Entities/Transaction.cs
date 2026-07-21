namespace TopUp
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public int TerminalId { get; set; }
        public string? MobileNo { get; set; }
        public string? CardNumber { get; set; }
        public TransactionType Type { get; set; }
    }
}
