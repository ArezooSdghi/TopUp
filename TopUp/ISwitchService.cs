namespace TopUp
{
    public interface ISwitchService
    {
        Task Advice(Guid transactionId);
        Task Reverse(Guid transactionId);
    }
}
