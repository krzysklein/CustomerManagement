using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CustomerManagement.Domain.Customers.Tests
{
    [TestClass]
    public class PersonalDetailsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotCreatePersonalDetailsWithoutFirstName()
        {
            new PersonalDetails(firstName: null, middleName: "Doe", lastName: "Smith");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotCreatePersonalDetailsWithoutLastName()
        {
            new PersonalDetails(firstName: "John", middleName: "Doe", lastName: null);
        }

        [TestMethod]
        public void ShouldCreatePersonalDetailsWithFirstAndLastNameOnly()
        {
            new PersonalDetails(firstName: "John", middleName: null, lastName: "Smith");
        }
    }
}
