namespace TopUp
{
    public class OperationResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = default!;
        public string ReferenceNumber { get; set; } = default!;
    }
}
