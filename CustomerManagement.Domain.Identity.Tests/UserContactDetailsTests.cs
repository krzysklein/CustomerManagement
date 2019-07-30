using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CustomerManagement.Domain.Identity.Tests
{
    [TestClass]
    public class UserContactDetailsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotCreateUserContactDetailsWithoutFirstName()
        {
            new UserContactDetails(firstName: null, lastName: "Smith");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotCreateUserContactDetailsWithoutLastName()
        {
            new UserContactDetails(firstName: "John", lastName: null);
        }

        [TestMethod]
        public void ShouldCreateUserContactDetailsWithValidArguments()
        {
            var userContactDetails = new UserContactDetails(firstName: "John", lastName: "Smith");

            Assert.IsNotNull(userContactDetails);
        }
    }
}
