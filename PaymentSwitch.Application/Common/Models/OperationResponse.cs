namespace PaymentSwitch.Application.Common.Models
{
    public class OperationResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public string? ReferenceNumber { get; set; }

        public static OperationResponse Success(
            string reference,
            string message)
        {
            return new OperationResponse
            {
                IsSuccess = true,
                Message = message,
                ReferenceNumber = reference
            };
        }

        public static OperationResponse Fail(
            string message)
        {
            return new OperationResponse
            {
                IsSuccess = false,
                Message = message
            };
        }
    }
}
