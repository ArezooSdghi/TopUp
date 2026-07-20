namespace TopUp
{
    public interface IShaparakService
    {
        Task AdviceAsync(Transaction transaction);
        Task ReverseAsync(Transaction transaction);
        Task<TransactionResponse> PurchaseAsync(Transaction transaction);
    }
}
