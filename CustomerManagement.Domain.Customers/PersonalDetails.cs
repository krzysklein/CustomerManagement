using CustomerManagement.Common.SharedKernel;
using System;

namespace CustomerManagement.Domain.Customers
{
    public class PersonalDetails : ValueObject
    {
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }

        private PersonalDetails()
        {
        }

        public PersonalDetails(string firstName, string middleName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("First name is invalid");
            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("Last name is invalid");

            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }
    }
}
