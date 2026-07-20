
using System.Collections.Concurrent;

namespace TopUp
{
    public class InMemoryQueueService : IQueueService
    {
        private readonly ConcurrentDictionary<string, ConcurrentQueue<object>> _queues = new();

        public Task<T> DequeueAsync<T>(string queueName)
        {
            throw new NotImplementedException();
        }

        public Task EnqueueAsync<T>(string queueName, T message)
        {
            throw new NotImplementedException();
        }
    }
}
