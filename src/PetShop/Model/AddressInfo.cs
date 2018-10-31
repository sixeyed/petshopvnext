using System;
using System.Data.Linq.Mapping;

namespace PetShop.Model {

    /// <summary>
    /// Business entity used to model addresses
    /// </summary>
    [Serializable]
    public class AddressInfo {

        /// <summary>
        /// Default constructor
        /// </summary>
        public AddressInfo() { }

        /// <summary>
        /// Constructor with specified initial values
        /// </summary>
        /// <param name="firstName">First Name</param>
        /// <param name="lastName">Last Name</param>
        /// <param name="address1">Address line 1</param>
        /// <param name="address2">Address line 2</param>
        /// <param name="city">City</param>
        /// <param name="state">State</param>
        /// <param name="zip">Postal Code</param>
        /// <param name="country">Country</param>
        /// <param name="phone">Phone number at this address</param>
        /// <param name="email">Email at this address</param>
        public AddressInfo(string firstName, string lastName, string address1, string address2, string city, string state, string zip, string country, string phone, string email) {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address1 = address1;
            this.Address2 = address2;
            this.City = city;
            this.State = state;
            this.Zip = zip;
            this.Country = country;
            this.Phone = phone;
            this.Email = email;
        }

        // Properties
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}