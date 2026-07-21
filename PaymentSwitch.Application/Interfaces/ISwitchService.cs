namespace TopUp
{
    public interface ISwitchService
    {
        Task<OperationResponse> ProcessAsync(Transaction transaction);
        //Task<OperationResponse> AdviceAsync(Transaction transaction);
        //Task<OperationResponse> ReverseAsync(Transaction transaction);
        //Task<OperationResponse> ProcessTopupAsync(Transaction transaction);
        //Task<OperationResponse> ProcessPurchaseAsync(Transaction transaction);
    }
}
