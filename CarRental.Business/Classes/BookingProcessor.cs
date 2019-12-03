using CarRental.Common.Classes;
using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using CarRental.Data.Classes;
using CarRental.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Classes
{
    public class BookingProcessor 
    {
        
        
        private static readonly IData _db = new CollectionData();

        
        public int NextPersonId => _db.NextPersonId;

        public int NextVehicleId => _db.NextVehicleId;

        public int NextBookingId => _db.NextBookingId;

        //constructor
        public BookingProcessor()
        {

        }


        
        public IEnumerable<Customer> GetCustomers()
        {
             return _db.GetPersons().Select(ol => new Customer(ol.Id, ol.SocialSecurityNumber, ol.LastName, ol.FirstName)).ToList(); //_customers.ToList();   
        }




        public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default)
        {
            return _db.GetVehicles();
        }


        public IEnumerable<IBooking> GetBookings()
        {
            return _db.GetBookings();
        }




        public IBooking GetBooking(int vehicleId)
        {
            return _db.GetBooking(vehicleId);
            
        }



        public Customer GetCustomer(int customerId)
        {
            return (Customer)_db.GetPersons().Single(c =>c.Id.Equals(customerId));  //TODO: This is an ugly hack
        }






        public IVehicle GetVehicle(int vehicleId)
        {
            return _db.GetVehicle(vehicleId);
        }


        #region Phase2


        public void AddVehicle(string make, string registrationNumber, double odometer, double costkm, VehicleStatuses status, VehicleTypes type)
        {
            IVehicle vehicle = new Car(_db.NextVehicleId, make, registrationNumber, odometer, costkm, status, type);
            _db.AddVehicle(vehicle);

            try
            {
                if (registrationNumber.Equals(string.Empty) || make == default) throw new ArgumentException("The Registration Number cannot be empty.");
                else if (make.Equals(string.Empty) || make == default)
                    throw new ArgumentException("The make name cannot be empty.");
                else if (odometer < 1)
                    throw new ArgumentException("The odometer must be greater than 0.");
                else if (costkm < 0)
                    throw new ArgumentException("he costKm must be greater than 0.");

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void AddCustomer(string socialSecurityNumber, string firstNme, string lastName)
        {
            
                IPerson person = new Customer(_db.NextPersonId, socialSecurityNumber, firstNme, lastName);
                _db.AddPerson(person);

            try
            {
                 if (socialSecurityNumber.Equals(string.Empty) || socialSecurityNumber == default)
                    throw new ArgumentException("The Social Security Number cannot be empty.");
                else if (firstNme.Equals(string.Empty) || firstNme == default)
                    throw new ArgumentException("Firstname cannot be empty.");
                else if (lastName.Equals(string.Empty) || lastName == default)
                    throw new ArgumentException("Lasttname cannot be empty.");

            }
            catch (Exception)
            {

                throw;
            }
        }



        public IBooking RentVehicle(int vehicleId, int customerId)
        {
            return _db.RentVehicle(vehicleId, customerId);
        }


        public IBooking ReturnVehicle(int vehicleId, double distance)
        {
             _db.GetVehicle(vehicleId).Drive(distance);
            return _db.ReturnVehicle(vehicleId);
        }


        //calling default interface methods
        public string[] VehicleStatusNames => _db.VehicleStatusNames;
        public string[] VehicleTypeNames => _db.VehicleTypeNames;
        public VehicleStatuses GetVehicleStatus(string name) => _db.GetVehicleStatus(name);
        public VehicleTypes GetVehicleType(string name) => _db.GetVehicleType(name);

        #endregion Phase2

    }
}
