using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CustomerManagement.Domain.Customers.Tests
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotCreateEmailWithoutAtCharacter()
        {
            new Email("smith.com");
        }

        [TestMethod]
        public void ShouldCreateValidEmail()
        {
            new Email("john@smith.com");
        }
    }
}
