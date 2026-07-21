
namespace TopUp
{
    public class TopupService : ITopupService
    {
        private readonly Random _random = new();

        public async Task<bool> ChargeAsync(TopupRequest request)
        {
            await Task.Delay(1000);
            return _random.Next(0, 100) > 30;
        }
    }
}
