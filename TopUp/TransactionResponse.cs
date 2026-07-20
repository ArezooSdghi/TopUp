namespace TopUp
{
    public class TransactionResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = default!;
        public string ReferenceNumber { get; set; } = default!;
    }
}
