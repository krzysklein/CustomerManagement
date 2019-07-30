using CustomerManagement.Common.SharedKernel;
using System;

namespace CustomerManagement.Domain.Identity
{
    public class UserContactDetails : ValueObject
    {
        public string FirstName { get; }
        public string LastName { get; }

        private UserContactDetails()
        {
        }

        public UserContactDetails(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("First name is invalid");
            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("Last name is invalid");

            FirstName = firstName;
            LastName = lastName;
        }
    }
}
