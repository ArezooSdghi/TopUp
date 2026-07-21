using PaymentSwitch.Application.Common.Models;
using PaymentSwitch.Domain.Entities;

namespace PaymentSwitch.Application.Interfaces
{
    public interface ISwitchService
    {
        Task<OperationResponse> ProcessAsync(Transaction transaction);
    }
}
