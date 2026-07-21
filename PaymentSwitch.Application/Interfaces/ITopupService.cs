using PaymentSwitch.Application.Dtos;

namespace PaymentSwitch.Application.Interfaces
{
    public interface ITopupService
    {
        Task<bool> ChargeAsync(TopupRequest request);
    }
}
