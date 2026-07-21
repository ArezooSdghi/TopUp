using Microsoft.Extensions.DependencyInjection;
using PaymentSwitch.Application.Interfaces;
using PaymentSwitch.Application.Services;
using TopUp;

var services = new ServiceCollection();

services.AddSingleton<ITerminalService, TerminalService>();
services.AddSingleton<ISwitchService, TerminalService>();

//services.AddSingleton(ITerminalService)

//services.AddSingleton<ISwitchService, SwitchService>();
//services.AddSingleton<ITransactionDispatcher, TransactionDispatcher>();

//services.AddSingleton<IPurchaseHandler, PurchaseHandler>();
//services.AddSingleton<ITopupHandler, TopupHandler>();
//services.AddSingleton<IReverseHandler, ReverseHandler>();
//services.AddSingleton<IAdviceHandler, AdviceHandler>();

//services.AddSingleton<IQueueService, InMemoryQueueService>();
