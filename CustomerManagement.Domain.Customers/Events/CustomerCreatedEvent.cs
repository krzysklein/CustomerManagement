using CustomerManagement.Common.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Domain.Customers.Events
{
    public class CustomerCreatedEvent : IEvent
    {
        public Customer Customer { get; }

        public CustomerCreatedEvent(Customer customer)
        {
            Customer = customer;
        }
    }
}
