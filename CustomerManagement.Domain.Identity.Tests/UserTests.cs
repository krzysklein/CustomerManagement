using CustomerManagement.Domain.Identity.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace CustomerManagement.Domain.Identity.Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotCreateUserWithoutUserName()
        {
            new User(userName: null, passwordHash: "passwordhash", contactDetails: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotCreateUserWithoutContactDetails()
        {
            new User(userName: "user", passwordHash: "passwordhash", contactDetails: null);
        }

        [TestMethod]
        public void ShouldCreateUserWithoutPasswordHash()
        {
            var user = new User(userName: "user", passwordHash: null, contactDetails: new UserContactDetails("John", "Smith"));

            Assert.AreEqual(1, user.Events.Count);
            Assert.IsInstanceOfType(user.Events[0], typeof(UserCreatedEvent));
            Assert.AreEqual(user, (user.Events[0] as UserCreatedEvent).User);
        }

        [TestMethod]
        public void ShouldChangePasswordHash()
        {
            var user = new User(userName: "user", passwordHash: "passwordhash", contactDetails: new UserContactDetails("John", "Smith"));

            user.ChangePasswordHash("newpasswordhash");

            Assert.AreEqual("newpasswordhash", user.PasswordHash);
            Assert.IsTrue(user.Events.Count >= 1);
            Assert.IsInstanceOfType(user.Events.Last(), typeof(UserChangedPasswordEvent));
            Assert.AreEqual(user, (user.Events.Last() as UserChangedPasswordEvent).User);
        }

        [TestMethod]
        public void ShouldChangeContactDetails()
        {
            var user = new User(userName: "user", passwordHash: "passwordhash", contactDetails: new UserContactDetails("John", "Smith"));

            user.ChangeContactDetails(new UserContactDetails("Alice", "Wonderland"));

            Assert.AreEqual("Alice", user.ContactDetails.FirstName);
            Assert.AreEqual("Wonderland", user.ContactDetails.LastName);
            Assert.IsTrue(user.Events.Count >= 1);
            Assert.IsInstanceOfType(user.Events.Last(), typeof(UserChangedContactDetails));
            Assert.AreEqual(user, (user.Events.Last() as UserChangedContactDetails).User);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotChangeContactDetailsForNull()
        {
            var user = new User(userName: "user", passwordHash: "passwordhash", contactDetails: new UserContactDetails("John", "Smith"));

            user.ChangeContactDetails(null);
        }
    }
}
