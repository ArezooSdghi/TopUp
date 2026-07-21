using PaymentSwitch.Application.Common.Models;
using PaymentSwitch.Application.Interfaces;
using PaymentSwitch.Domain.Entities;

namespace PaymentSwitch.Application.Services
{
    public class SwitchService : ISwitchService
    {
        private readonly ITransactionDispatcher _dispatcher;

        public SwitchService(ITransactionDispatcher dispatcher)
            => _dispatcher = dispatcher;

        public async Task<OperationResponse> ProcessAsync(Transaction transaction)
            => await _dispatcher.DispatchAsync(transaction);
    }
}
