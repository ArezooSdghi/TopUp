using PaymentSwitch.Application.Common.Models;
using PaymentSwitch.Domain.Entities;
using PaymentSwitch.Domain.Enums;

namespace PaymentSwitch.Application.Interfaces
{
    public interface ITransactionHandler
    {
        TransactionType Type { get; }
        Task<OperationResponse> HandleAsync(Transaction transaction);
    }
}
