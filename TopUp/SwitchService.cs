
namespace TopUp
{
    public class SwitchService : ISwitchService
    {
        public Task AdviceAsync(Guid transactionId)
        {
            Console.WriteLine($"Advice sent for {transactionId}");
            return Task.CompletedTask;
        }

        public Task ReverseAsync(Guid transactionId)
        {
            Console.WriteLine($"Reverse sent for {transactionId}");
            return Task.CompletedTask;
        }
    }
}
