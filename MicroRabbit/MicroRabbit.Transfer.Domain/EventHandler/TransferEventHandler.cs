﻿using Microrabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Domain.EventHandler
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvents>
    {
        private readonly ITransferRepository _transferRepository;
        public TransferEventHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }
        public Task Handler(TransferCreatedEvents @event)
        {
            _transferRepository.Add(
                new TransferLog()
                {
                    FromAccount = @event.From,
                    ToAccount = @event.To,
                    TransferAmount=@event.Amount
                });
            ;


            return Task.CompletedTask;
        }
    }
}
