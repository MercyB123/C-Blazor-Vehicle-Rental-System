using System;
using Xunit;
using CarRental.Common.Classes;
using CarRental.Common.Enums;
using CarRental.Data.Classes;
using CarRental.Common.Interfaces;

namespace CarRental.Tests
{
    public class CustomerTest
    {
        [Fact]
        public void CanCreateCustomerInstance()
        {
            var customer = new Customer(1, "123456", "Chris", "Taylor");

            Assert.NotNull(customer);

            Assert.Equal(1, customer.Id);

            Assert.Equal("123456", customer.SocialSecurityNumber);

            Assert.Equal("Chris", customer.FirstName);

            Assert.Equal("Taylor", customer.LastName);

        }


        [Fact]
        public void CanAddVehicleToCarInstance()
        {
            var person1 = new CollectionData();
            IPerson person = new Customer(3, "123456", "Chris", "Taylor");
            person1.AddPerson(person);


            // Assert Customer
            Assert.NotNull(person1);
            Assert.Equal(3, person.Id);
            Assert.Equal("123456", person.SocialSecurityNumber);
            Assert.Equal("Chris", person.FirstName);
            Assert.Equal("Taylor", person.LastName);
            Assert.NotEmpty(person1.NextPersonId.ToString());

        }
    }

}
