namespace TopUp
{
    public interface ITransactionDispatcher
    {
        Task<OperationResponse> DispatchAsync(Transaction transaction);
    }
}
