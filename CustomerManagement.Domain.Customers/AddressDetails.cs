using CustomerManagement.Common.SharedKernel;

namespace CustomerManagement.Domain.Customers
{
    public class AddressDetails : ValueObject
    {
        public string AddressLine1 { get; }
        public string AddressLine2 { get; }
        public string City { get; }
        public string State { get; }
        public string PostCode { get; }
        public string Country { get; }

        private AddressDetails()
        {
        }

        public AddressDetails(
            string addressLine1, string addressLine2, string city, 
            string state, string postCode, string country)
        {
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
            State = state;
            PostCode = postCode;
            Country = country;
        }
    }
}
