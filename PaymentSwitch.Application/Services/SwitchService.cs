using PaymentSwitch.Application.Common.Models;
using PaymentSwitch.Application.Dtos;
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
            => await _dispatcher.DispatchAsync(Map(transaction));

        private TransactionDto Map(Transaction transaction)
        {
            return new TransactionDto
            {
                Id = transaction.Id,
                Type = transaction.Type,
                Amount = transaction.Amount,
                MobileNo = transaction.MobileNo,
                TerminalId = transaction.TerminalId,
                CardNumber = transaction.CardNumber,
            };
        }
    }
}
