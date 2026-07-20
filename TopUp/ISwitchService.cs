namespace TopUp
{
    public interface ISwitchService
    {
        Task AdviceAsync(Guid transactionId);
        Task ReverseAsync(Guid transactionId);
        Task<TransactionResponse> ProcessTopupAsync(Transaction transaction);
        Task<TransactionResponse> ProcessPurchaseAsync(Transaction transaction);
    }
}
