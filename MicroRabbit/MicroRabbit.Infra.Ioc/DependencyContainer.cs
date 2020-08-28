using MediatR;
using Microrabbit.Domain.Core.Bus;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.CommandHandler;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Data.Repository;
using MicroRabbit.Transfer.Domain.EventHandler;
using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Transfer.Domain.Interfaces;
using Microservice.Banking.Application.Interfaces;
using Microservice.Banking.Application.Services;
using Microservice.Transfer.Application.Interfaces;
using Microservice.Transfer.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Infra.Ioc
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>(sp=> {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(),scopeFactory);
            });

            //Domain Events
            //services.AddTransient<IEventHandler<TransferCreatedEvents>, TransferEventHandler>();
            services.AddTransient<IEventHandler<TransferCreatedEvents>, TransferEventHandler>();

            //Domain banking commands
            services.AddTransient<IRequestHandler<CreateTransferCommand,bool>, TransferCommandHanlder>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<BankingDbContext>();
            
            services.AddTransient<ITransferService, TransferService>();
            services.AddTransient<ITransferRepository, TransferRepository>();
            services.AddTransient<TransferDbContext>();




        }
    }
}
