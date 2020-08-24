using Microrabbit.Domain.Core.Bus;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using Microservice.Banking.Application.Interfaces;
using Microservice.Banking.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        public readonly IAccountRepository _accountRepository;
        public readonly IEventBus _bus;
        public AccountService(IAccountRepository accountRepository,IEventBus bus)
        {
            _accountRepository = accountRepository;
            _bus = bus;

        }
        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var CreateTranferCommand = new CreateTransferCommand(
                accountTransfer.FromAccount,
                accountTransfer.ToAccount,
                accountTransfer.TransferAmount
                
                );
            _bus.SendCommand(CreateTranferCommand);
        }
    }
}
