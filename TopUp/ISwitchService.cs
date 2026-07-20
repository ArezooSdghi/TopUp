namespace TopUp
{
    public interface ISwitchService
    {
        Task AdviceAsync(Guid transactionId);
        Task ReverseAsync(Guid transactionId);
    }
}
