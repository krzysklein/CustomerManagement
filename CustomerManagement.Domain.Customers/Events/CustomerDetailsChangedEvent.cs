using CustomerManagement.Common.SharedKernel.Interfaces;

namespace CustomerManagement.Domain.Customers.Events
{
    public class CustomerDetailsChangedEvent : IEvent
    {
        public Customer Customer { get; }

        public CustomerDetailsChangedEvent(Customer customer)
        {
            Customer = customer;
        }
    }
}
