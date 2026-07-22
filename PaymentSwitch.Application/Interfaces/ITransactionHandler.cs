using PaymentSwitch.Application.Common.Models;
using PaymentSwitch.Application.Dtos;
using PaymentSwitch.Domain.Enums;

namespace PaymentSwitch.Application.Interfaces
{
    public interface ITransactionHandler
    {
        TransactionType Type { get; }
        Task<OperationResponse> HandleAsync(TransactionDto transaction);
    }
}
