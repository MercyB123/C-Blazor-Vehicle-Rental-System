using CarRental.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Interfaces
{
   public interface IVehicle
    {
        int Id { get; }
        string Make { get; }
        string RegistrationNumber { get; }
        double Odometer { get; }
        double CostKm { get; }

        //in the class, use a switch to return the following values:
        //Sedan: 100, Combi: 200, Van: 300, Motorcycle: 50
        //Throw an argumentExeption with the text: "Vehicle type unavailable" in the default case
        double CostDay { get; }
        VehicleStatuses Status { get; set; }
        VehicleTypes Type { get; }

        //Add thé distance to the odometer property
        void Drive(double distance);
    }
}
