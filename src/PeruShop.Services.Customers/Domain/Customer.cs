namespace PeruShop.Services.Customers.Domain
{
    using System;
    public class Customer
    {
        public Customer(Guid id, string firstName, string lastName, string address, string country)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Country = country;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }
}