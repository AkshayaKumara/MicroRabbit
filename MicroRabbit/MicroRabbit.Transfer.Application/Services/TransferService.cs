using Microrabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using Microservice.Transfer.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microservice.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Commands;

namespace Microservice.Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        public readonly ITransferRepository _transferRepository;
        public readonly IEventBus _bus;
        public TransferService(ITransferRepository transferRepository,IEventBus bus)
        {
            _transferRepository = transferRepository;
            _bus = bus;

        }
        public IEnumerable<TransferLog> GetTransferLog()
        {
            return _transferRepository.GetTransferLog();
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
