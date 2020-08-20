using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using Microservice.Banking.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        public readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }
    }
}
