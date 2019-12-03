using CarRental.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Classes
{
   public class Car : Vehicle
    {
       

        //constructor
        public Car(int ID, string make, string registrationNum, double odometer, double costkm, VehicleStatuses status, VehicleTypes type)
            : base(ID, make, registrationNum, odometer, costkm, status,  type)
        {
           

        }


    }
}
