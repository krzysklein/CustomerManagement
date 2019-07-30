using CustomerManagement.Common.SharedKernel;
using CustomerManagement.Common.SharedKernel.Interfaces;
using CustomerManagement.Domain.Customers.Events;
using System;
using System.Collections.Generic;

namespace CustomerManagement.Domain.Customers
{
    public class Customer : AggregateRoot
    {
        public PersonalDetails PersonalDetails { get; private set; }
        public AddressDetails BusinessAddress { get; private set; }
        public Email BusinessEmail { get; private set; }
        public AddressDetails PrivateAddress { get; private set; }
        public Email PrivateEmail { get; private set; }

        public IReadOnlyCollection<Tag> Tags => _tags;
        private readonly List<Tag> _tags = new List<Tag>();

        internal new IReadOnlyList<IEvent> Events => base.Events;

        private Customer()
        {
        }

        public Customer(
            PersonalDetails personalDetails, 
            AddressDetails businessAddress, Email businessEmail, 
            AddressDetails privateAddress, Email privateEmail)
        {
            if (personalDetails == null) throw new ArgumentException("Personal details are required");

            PersonalDetails = personalDetails;
            BusinessAddress = businessAddress;
            BusinessEmail = businessEmail;
            PrivateAddress = privateAddress;
            PrivateEmail = privateEmail;

            ApplyEvent(new CustomerCreatedEvent(this));
        }

        public void ChangeDetails(
            PersonalDetails personalDetails,
            AddressDetails businessAddress, Email businessEmail,
            AddressDetails privateAddress, Email privateEmail)
        {
            if (personalDetails == null) throw new ArgumentException("Personal details are required");

            PersonalDetails = personalDetails;
            BusinessAddress = businessAddress;
            BusinessEmail = businessEmail;
            PrivateAddress = privateAddress;
            PrivateEmail = privateEmail;

            ApplyEvent(new CustomerDetailsChangedEvent(this));
        }

        // TODO: Add Tags support
    }
}
