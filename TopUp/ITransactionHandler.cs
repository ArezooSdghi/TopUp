namespace TopUp
{
    public interface ITransactionHandler
    {
        TransactionType Type { get; }
        Task HandleAsync(Transaction transaction);
    }
}
