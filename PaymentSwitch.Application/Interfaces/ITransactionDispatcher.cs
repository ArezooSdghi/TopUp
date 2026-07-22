using PaymentSwitch.Application.Common.Models;
using PaymentSwitch.Application.Dtos;

namespace PaymentSwitch.Application.Interfaces
{
    public interface ITransactionDispatcher
    {
        Task<OperationResponse> DispatchAsync(TransactionDto transaction);
    }
}
