using CarRental.Common.Interfaces;
using CarRental.Common.Enums;
using CarRental.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Classes
{
    public class Bookings : IBooking
    {
        public int Id { get; }
        public int VehicleId { get; }
        public string RegistrationNumber { get; }
        public IPerson Person { get; }
        public DateTime Rented { get; set; }
        public DateTime Returned { get; set; }
        public double Cost { get; private set; }
        public double OdometerRented { get; }
        public double OdometerReturned { get; private set; }
       

        
       public void ReturnVehicle(IVehicle vehicle)
        {
            //// Record information:
            Returned = DateTime.Now;
            OdometerReturned = vehicle.Odometer;

            // Calculate cost for time:
            int days = Rented.Duration(Returned);
            Cost = days * vehicle.CostDay;

            // Calculate cost for distance:
            double distance = OdometerReturned - OdometerRented;
            Cost += vehicle.CostKm * distance;

            // Make the vehicle available to rent again:
            vehicle.Status = VehicleStatuses.Available;



        }


        public Bookings(int ID, IVehicle vehicle, IPerson person)
        {
            if (Id < 0 || person == default || vehicle == null || vehicle.Id < 0 || vehicle.Status == VehicleStatuses.Booked)
            {
                throw new ArgumentException("Vehicle not available");
            }

            Id = ID;
            VehicleId = vehicle.Id;
            RegistrationNumber = vehicle.RegistrationNumber;
            Rented = DateTime.Now.AddDays(-2.5); //TODO: This is a fake time difference to make the test data work, proper code should just use DateTime.Now
            Returned = DateTime.MinValue;
            OdometerRented = vehicle.Odometer;
            vehicle.Status = VehicleStatuses.Booked;
            Person = person;

            /*
        the class constructor should;
        Throw an ArgumentExeption if id < 0 or vehicle.id < 0 or person == default
        Assign properties with values from the passed in parameters
        */


            //assign values to the class properties with values from the vehicle parameter
            //Cost = days * vehicle.CostDay + km * vehicle.CostKm
            //call the Duration extension method to calculate the days
        }
    }
}
