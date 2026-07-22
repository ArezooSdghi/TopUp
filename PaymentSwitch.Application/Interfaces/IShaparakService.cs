using PaymentSwitch.Application.Common.Models;
using PaymentSwitch.Application.Dtos;

namespace PaymentSwitch.Application.Interfaces
{
    public interface IShaparakService
    {
        Task<OperationResponse> AdviceAsync(TransactionDto transaction);
        Task<OperationResponse> ReverseAsync(TransactionDto transaction);
        Task<OperationResponse> PurchaseAsync(TransactionDto transaction);
    }
}
