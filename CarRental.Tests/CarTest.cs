using System;
using Xunit;
using CarRental.Common.Classes;
using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using CarRental.Data.Classes;

namespace CarRental.Tests
{
    public class CarTest
    {
        [Fact]
        public void CanCreateCarInstance()
        {
            var car = new Car(1, "Volvo", "ABC123", 10000, 1, VehicleStatuses.Available, VehicleTypes.Combi);

            Assert.NotNull(car);
            Assert.Equal(1, car.Id);
            Assert.Equal("Volvo", car.Make);
            Assert.Equal("ABC123", car.RegistrationNumber);
            Assert.Equal(1, car.CostKm);
            Assert.Equal(VehicleStatuses.Available, car.Status);
            Assert.Equal(VehicleTypes.Combi, car.Type);

        }



        [Fact]
        public void CanAddVehicleToCarInstance()
        {
            var vehicle1 = new CollectionData();
            IVehicle vehicle = new Car(6, "Volvo", "ABC123", 10000, 1, VehicleStatuses.Available, VehicleTypes.Combi);
            vehicle1.AddVehicle(vehicle);
           

            // Assert Car
            Assert.NotNull(vehicle1);
            Assert.Equal(6, vehicle.Id);
            Assert.Equal("Volvo", vehicle.Make);
            Assert.Equal("ABC123", vehicle.RegistrationNumber);
            Assert.NotEmpty(vehicle1.NextVehicleId.ToString());

           
        }
    }
}
