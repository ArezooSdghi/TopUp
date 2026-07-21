using PaymentSwitch.Application.Interfaces;
using System.Collections.Concurrent;

namespace PaymentSwitch.Infrastructure.Messaging
{
    public class InMemoryQueueService : IQueueService
    {
        private readonly ConcurrentDictionary<string, ConcurrentQueue<object>> _queues = new();

        public Task EnqueueAsync<T>(string queueName, T message)
        {
            var queue = _queues.GetOrAdd(queueName, new ConcurrentQueue<object>());
            queue.Enqueue(message!);
            return Task.CompletedTask;
        }

        public Task<T?> DequeueAsync<T>(string queueName)
        {
            if (_queues.TryGetValue(queueName, out var queue))
            {
                if (queue.TryDequeue(out var message)) return Task.FromResult((T?)message);
            }

            return Task.FromResult(default(T));
        }

        public IEnumerable<T> GetAll<T>(string queueName)
        {
            if (_queues.TryGetValue(queueName, out var queue))
            {
                return queue.OfType<T>().ToList();
            }

            return Enumerable.Empty<T>();
        }
    }
}
