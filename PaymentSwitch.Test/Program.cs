using Microsoft.Extensions.DependencyInjection;
using PaymentSwitch.Application.Common.Constants;
using PaymentSwitch.Application.Dispatchers;
using PaymentSwitch.Application.Handlers;
using PaymentSwitch.Application.Interfaces;
using PaymentSwitch.Application.Services;
using PaymentSwitch.Domain.Entities;
using PaymentSwitch.Domain.Enums;
using PaymentSwitch.Infrastructure.Messaging;
using PaymentSwitch.Infrastructure.Workers;

var services = new ServiceCollection();

services.AddSingleton<ITopupService, TopupService>();
services.AddSingleton<ISwitchService, SwitchService>();
services.AddSingleton<ITerminalService, TerminalService>();
services.AddSingleton<IShaparakService, ShaparakService>();
services.AddSingleton<IQueueService, InMemoryQueueService>();

services.AddSingleton<ITransactionDispatcher, TransactionDispatcher>();

services.AddSingleton<ITransactionHandler, TopupHandler>();
services.AddSingleton<ITransactionHandler, AdviceHandler>();
services.AddSingleton<ITransactionHandler, ReverseHandler>();
services.AddSingleton<ITransactionHandler, PurchaseHandler>();

services.AddSingleton<TopupWorker>();
services.AddSingleton<TopupSuccessWorker>();
services.AddSingleton<TopupFailureWorker>();

services.AddLogging();

var provider = services.BuildServiceProvider();

var switchService = provider.GetRequiredService<ISwitchService>();

var transaction = new Transaction
{
    Amount = 100000,
    Id = Guid.NewGuid(),
    TerminalId = 123456,
    Type = TransactionType.Topup,
    CardNumber = "1234567890123456"
};

var result = await switchService.ProcessAsync(transaction);
//Console.WriteLine(result.IsSuccess);
//Console.WriteLine(result.Message);
//Console.WriteLine(result.ReferenceNumber);

var queueService = provider.GetRequiredService<IQueueService>();

var topupTransactions = queueService.GetAll<Transaction>(nameof(QueueNames.Topup));

var TopUpworker = provider.GetRequiredService<TopupWorker>();

await TopUpworker.StartAsync(CancellationToken.None);

Console.WriteLine("Topup Worker started");

await Task.Delay(1000);

await TopUpworker.StopAsync(CancellationToken.None);

var failedTransactions = queueService.GetAll<Transaction>(nameof(QueueNames.Reverse));
var successTransactions = queueService.GetAll<Transaction>(nameof(QueueNames.Advice));

//await queueService.EnqueueAsync(
//    nameof(QueueNames.Advice),
//    transaction);

var TopUpSuccessWorker = provider.GetRequiredService<TopupFailureWorker>();

await TopUpSuccessWorker.StartAsync(CancellationToken.None);

Console.WriteLine("Topup Worker started");

await Task.Delay(5000);

await TopUpSuccessWorker.StopAsync(CancellationToken.None);


foreach (var item in topupTransactions)
{
    Console.WriteLine($"Id: {item.Id}");
    Console.WriteLine($"Amount: {item.Amount}");
    Console.WriteLine($"Type: {item.Type}");
}
