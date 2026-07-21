namespace TopUp
{
    public interface ITransactionHandler
    {
        TransactionType Type { get; }
        Task<OperationResponse> HandleAsync(Transaction transaction);
    }
}
