using MicroRabbit.Banking.Domain.Models;
using Microservice.Banking.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();

        void Transfer(AccountTransfer accountTransfer);
    }
}
