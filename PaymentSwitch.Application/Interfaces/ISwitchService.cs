namespace TopUp
{
    public interface ISwitchService
    {
        Task<OperationResponse> ProcessAsync(Transaction transaction);
    }
}
