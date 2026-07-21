using TopUp;

namespace PaymentSwitch.Application.Interfaces
{
    public interface ITerminalService
    {
        Task<OperationResponse> ProcessAsync(Transaction transaction);
    }
}
