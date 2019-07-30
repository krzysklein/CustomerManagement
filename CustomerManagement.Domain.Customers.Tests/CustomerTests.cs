using CustomerManagement.Domain.Customers.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CustomerManagement.Domain.Customers.Tests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotCreateCustomerWithoutPersonalDetails()
        {
            new Customer(personalDetails: null, businessAddress: null, businessEmail: null, privateAddress: null, privateEmail: null);
        }

        [TestMethod]
        public void ShouldCreateCustomerWithPersonalDetails()
        {
            var customer =  new Customer(
                personalDetails: new PersonalDetails(firstName: "John", middleName: "Doe", lastName: "Smith"), 
                businessAddress: null, businessEmail: null, privateAddress: null, privateEmail: null);

            Assert.AreEqual(1, customer.Events.Count);
            Assert.IsInstanceOfType(customer.Events[0], typeof(CustomerCreatedEvent));
            Assert.AreEqual(customer, (customer.Events[0] as CustomerCreatedEvent).Customer);
        }

        [TestMethod]
        public void ShouldCreateCustomerWithEmptyTags()
        {
            var customer = new Customer(
                personalDetails: new PersonalDetails(firstName: "John", middleName: "Doe", lastName: "Smith"),
                businessAddress: null, businessEmail: null, 
                privateAddress: null, privateEmail: null);

            Assert.IsNotNull(customer.Tags);
            Assert.AreEqual(0, customer.Tags.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotChangeCustomerDetailsWithoutPersonalDetails()
        {
            var customer = new Customer(
                personalDetails: new PersonalDetails(firstName: "John", middleName: "Doe", lastName: "Smith"),
                businessAddress: null, businessEmail: null, privateAddress: null, privateEmail: null);

            customer.ChangeDetails(
                personalDetails: null,
                businessAddress: null, businessEmail: null,
                privateAddress: null, privateEmail: null);
        }
    }
}
