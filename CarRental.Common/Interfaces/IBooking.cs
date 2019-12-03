using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Interfaces
{
    public interface IBooking
    {
         int Id { get; }
         int VehicleId { get; }
         string RegistrationNumber { get; }
         IPerson Person { get; }
         DateTime Rented { get; }
         DateTime Returned { get; set; }
         double Cost { get; }
         double OdometerRented { get; }
         double OdometerReturned { get; }


         void ReturnVehicle(IVehicle vehicle);

        /*
         the class constructor should;
         Throw an AggregateExeption if id < 0 or vehicle.id < 0 or person == default
         Assign properties with values from the passed in parameters
         */


        //assign values to the class properties with values from the vehicle parameter
        //Cost = days * vehicle.CostDay + km * vehicle.CostKm
        //call the Duration extension method to calculate the days
    }
}
