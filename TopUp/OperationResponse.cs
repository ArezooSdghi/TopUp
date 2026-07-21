namespace TopUp
{
    public class OperationResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = default!;
        public Guid ReferenceNumber { get; set; } = default!;
    }
}
