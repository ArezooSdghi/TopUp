namespace PaymentSwitch.Application.Interfaces
{
    public interface IQueueService
    {
        Task<T?> DequeueAsync<T>(string queueName);
        Task EnqueueAsync<T>(string queueName, T message);
    }
}
