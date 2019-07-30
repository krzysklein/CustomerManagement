using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomerManagement.Domain.Customers.Tests
{
    [TestClass]
    public class AddressDetailsTests
    {
        [TestMethod]
        public void ShouldCreateAddressDetailsWithAllNullArguments()
        {
            var addressDetails = new AddressDetails(
                addressLine1: null, addressLine2: null, 
                city: null, state: null, 
                postCode: null, country: null);

            Assert.IsNotNull(addressDetails);
        }
    }
}
