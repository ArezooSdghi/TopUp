using PaymentSwitch.Application.Common.Models;
using PaymentSwitch.Domain.Entities;

namespace PaymentSwitch.Application.Interfaces
{
    public interface IShaparakService
    {
        Task<OperationResponse> AdviceAsync(Transaction transaction);
        Task<OperationResponse> ReverseAsync(Transaction transaction);
        Task<OperationResponse> PurchaseAsync(Transaction transaction);
    }
}
