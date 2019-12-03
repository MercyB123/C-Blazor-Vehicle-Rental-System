using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Common.Enums;

namespace CarRental.Common.Classes
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(int ID, string make, string registrationNum, double odometer, double costkm, VehicleStatuses status)
            : base(ID, make, registrationNum, odometer, costkm, status, VehicleTypes.Motorcycle)
        {
        }
    }
}
