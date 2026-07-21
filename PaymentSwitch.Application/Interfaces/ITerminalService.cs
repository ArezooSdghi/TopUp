using PaymentSwitch.Application.Common.Models;
using PaymentSwitch.Domain.Entities;

namespace PaymentSwitch.Application.Interfaces
{
    public interface ITerminalService
    {
        Task<OperationResponse> ProcessAsync(Transaction transaction);
    }
}
