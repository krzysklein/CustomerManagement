using CustomerManagement.Common.SharedKernel;
using System;

namespace CustomerManagement.Domain.Customers
{
    public class Email : ValueObject
    {
        public string EmailAddress { get; }

        private Email()
        {
        }

        public Email(string emailAddress)
        {
            if (!emailAddress.Contains("@")) throw new ArgumentException("Email address is invalid");

            EmailAddress = emailAddress;
        }
    }
}
