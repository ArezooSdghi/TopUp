using PaymentSwitch.Application.Common.Models;
using PaymentSwitch.Domain.Entities;

namespace PaymentSwitch.Application.Interfaces
{
    public interface ITransactionDispatcher
    {
        Task<OperationResponse> DispatchAsync(Transaction transaction);
    }
}
