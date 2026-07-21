using PaymentSwitch.Application.Common.Models;
using PaymentSwitch.Application.Interfaces;
using PaymentSwitch.Domain.Entities;

namespace PaymentSwitch.Application.Services
{
    public class TerminalService : ITerminalService
    {
        private readonly ISwitchService _switchService;

        public TerminalService(ISwitchService switchService)
            => _switchService = switchService;

        public async Task<OperationResponse> ProcessAsync(Transaction transaction)
            => await _switchService.ProcessAsync(transaction);
    }
}
