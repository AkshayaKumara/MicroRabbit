using Microrabbit.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Transfer.Domain.Events
{
    public class TransferCreatedEvents : Event
    {
        public int From { get; protected set; }
        public int To { get; protected set; }
        public decimal Amount { get; protected set; }

        public TransferCreatedEvents(int from, int to, decimal amount)
        {
            From = from;
            To = to;
            Amount = amount;
        }

    }
}
