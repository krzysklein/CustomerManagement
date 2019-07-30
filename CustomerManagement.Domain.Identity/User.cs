using CustomerManagement.Common.SharedKernel;
using CustomerManagement.Common.SharedKernel.Interfaces;
using CustomerManagement.Domain.Identity.Events;
using System;
using System.Collections.Generic;

namespace CustomerManagement.Domain.Identity
{
    public class User : AggregateRoot
    {
        public string UserName { get; }
        public string PasswordHash { get; private set; }
        public UserContactDetails ContactDetails { get; private set; }

        internal new IReadOnlyList<IEvent> Events => base.Events;

        private User()
        {
        }

        public User(string userName, string passwordHash, UserContactDetails contactDetails)
        {
            if (string.IsNullOrWhiteSpace(userName)) throw new ArgumentException("User name is invalid");
            if (contactDetails == null) throw new ArgumentException("Contact details are invalid");

            UserName = userName;
            PasswordHash = passwordHash;
            ContactDetails = contactDetails;

            ApplyEvent(new UserCreatedEvent(this));
        }

        public void ChangePasswordHash(string passwordHash)
        {
            PasswordHash = passwordHash;

            ApplyEvent(new UserChangedPasswordEvent(this));
        }

        public void ChangeContactDetails(UserContactDetails contactDetails)
        {
            if (contactDetails == null) throw new ArgumentException("Contact details are invalid");

            ContactDetails = contactDetails;

            ApplyEvent(new UserChangedContactDetails(this));
        }
    }
}
