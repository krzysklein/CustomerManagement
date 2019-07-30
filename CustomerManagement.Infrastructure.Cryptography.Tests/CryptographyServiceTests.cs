using CustomerManagement.Domain.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CustomerManagement.Infrastructure.Cryptography.Tests
{
    [TestClass]
    public class CryptographyServiceTests
    {
        private readonly ICryptographyService _cryptographyService;

        public CryptographyServiceTests()
        {
            _cryptographyService = new CryptographyService();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetHashShouldThrowExceptionForNullInput()
        {
            _cryptographyService.GetHash(data: null);
        }

        [TestMethod]
        public void GetHashShouldReturnValidSha256Hash()
        {
            var result = _cryptographyService.GetHash(data: "test");

            Assert.AreEqual("9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08", result);
        }
    }
}
