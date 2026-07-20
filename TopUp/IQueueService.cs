namespace TopUp
{
    public interface IQueueService
    {
        Task<T> DequeueAsync<T>(string queueName);
        Task EnqueueAsync<T>(string queueName, T message);
    }
}
