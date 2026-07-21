using PaymentSwitch.Application.Dtos;
using PaymentSwitch.Application.Interfaces;

namespace PaymentSwitch.Application.Services
{
    public class TopupService : ITopupService
    {
        private readonly Random _random = new();

        public async Task<bool> ChargeAsync(TopupRequest request)
        {
            return false;
            //await Task.Delay(1000);
            //return _random.Next(0, 100) < 30;
        }
    }
}
