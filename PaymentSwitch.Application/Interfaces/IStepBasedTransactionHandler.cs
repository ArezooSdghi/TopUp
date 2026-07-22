using PaymentSwitch.Domain.Enums;

namespace PaymentSwitch.Application.Interfaces
{
    public interface IStepBasedTransactionHandler
    {
        TransactionStep? Step { get; }
    }
}
