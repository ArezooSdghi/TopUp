namespace TopUp
{
    public interface IShaparakService
    {
        Task<OperationResponse> AdviceAsync(Transaction transaction);
        Task<OperationResponse> ReverseAsync(Transaction transaction);
        Task<OperationResponse> PurchaseAsync(Transaction transaction);
    }
}
