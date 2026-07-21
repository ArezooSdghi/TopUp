namespace PaymentSwitch.Application.Interfaces
{
    public interface IQueueService
    {
        Task<T?> DequeueAsync<T>(string queueName);
        IEnumerable<T> GetAll<T>(string queueName);
        Task EnqueueAsync<T>(string queueName, T message);
    }
}
