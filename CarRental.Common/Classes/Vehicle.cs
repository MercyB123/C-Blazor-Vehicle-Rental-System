using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Classes
{
    public abstract class Vehicle : IVehicle
    {
        public int Id { get; } = default;
        public string Make { get; } = string.Empty;
        public string RegistrationNumber { get;}
        public double Odometer { get; protected set; }
        public double CostKm { get; } = default;
        public double CostDay => GetDayCostForType(Type);
        public VehicleStatuses Status { get; set; } = default;
        public VehicleTypes Type { get; } = default;



        //Add thé distance to the odometer property
        public virtual void Drive(double distance)
        {
            
            Odometer += distance;
        }

        //constructor
        public Vehicle(int ID, string make, string registrationNum, double odometer, double costkm, VehicleStatuses status, VehicleTypes type)
            
        {
            Id = ID;
            Make = make;
            RegistrationNumber = registrationNum;
            Odometer = odometer;
            CostKm = costkm;
            Status = status;
            Type = type;

        }

        //switch statement
        public double GetDayCostForType(VehicleTypes vehicletype)
        {
            switch (vehicletype)
            {
                case VehicleTypes.Sedan:
                    {
                        return 100;
                    }
                case VehicleTypes.Combi:
                    {
                        return 200;
                    }
                case VehicleTypes.Motorcycle:
                    {
                        return 50;
                    }
                case VehicleTypes.Van:
                    {
                        return 300;
                    }

                default:
                    {
                        throw new ArgumentException("Vehicle type unavailable.");
                    }

            };

        }
        //end switch



    }
}

