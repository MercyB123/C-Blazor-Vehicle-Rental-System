using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace CarRental.Data.Interfaces
{
    public interface IData
    {
        IEnumerable<IPerson> GetPersons();
        IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default);
        IEnumerable<IBooking> GetBookings();
        IBooking GetBooking(int vehicleId);
        IPerson GetPerson(string socialSecurityNumber);
        IPerson GetPerson(int Id);
        IVehicle GetVehicle(string registrationNumber);
        IVehicle GetVehicle(int id);
        
        #region Phase2
        int NextVehicleId { get; }
        int NextPersonId { get; }
        int NextBookingId { get; }

        void AddVehicle(IVehicle vehicle);
        void AddPerson(IPerson customer);
        IBooking RentVehicle(int vehicleId, int customerId);
        IBooking ReturnVehicle(int vehicleId);

        public string[] VehicleStatusNames => Enum.GetNames(typeof(VehicleStatuses));
        public VehicleStatuses GetVehicleStatus(string name) => (VehicleStatuses)Enum.Parse(typeof(VehicleStatuses), name);
        public string[] VehicleTypeNames => Enum.GetNames(typeof(VehicleTypes));
        public VehicleTypes GetVehicleType(string name) => (VehicleTypes)Enum.Parse(typeof(VehicleTypes), name);


        #endregion Phase2
    }
}
