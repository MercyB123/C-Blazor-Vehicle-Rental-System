using CarRental.Common.Classes;
using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using CarRental.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Data.Classes
{
    public class CollectionData : IData
    {
        #region Fields
        readonly List<IPerson> _persons = new List<IPerson>();
        readonly List<IVehicle> _vehicles = new List<IVehicle>();
        readonly List<IBooking> _bookings = new List<IBooking>();
        #endregion Fields

        #region Properties
        
        public int NextVehicleId => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(m => m.Id) + 1;
       
        public int NextPersonId => _persons.Count == 0 ? 1 : _persons.Max(c => c.Id) + 1; 
        
        public int NextBookingId => _bookings.Count == 0 ? 1 : _bookings.Max(m => m.Id) + 1;
       
        #endregion Properties






        #region Construction
        public CollectionData()
        {
            SeedData();
        }

        void SeedData()
        {
            //Add customers
            _persons.Add(new Customer(1, "12345", "John", "Doe"));
            _persons.Add(new Customer(2, "67891", "Jane", "Smith"));
            
            //Add Vehicles
            _vehicles.AddRange(new List<IVehicle>
            {
                new Car(1, "Volvo", "ABC123", 10000, 1, VehicleStatuses.Available, VehicleTypes.Combi),
                new Car(2, "Saab", "DEF456", 20000, 1, VehicleStatuses.Available, VehicleTypes.Sedan),
                new Car(3, "Tesla", "GHI789", 1000, 3, VehicleStatuses.Available, VehicleTypes.Sedan),
                new Car(4, "Jeep", "JKL012", 5000, 1.5, VehicleStatuses.Available, VehicleTypes.Van),
                new Motorcycle(5, "Yamaha", "MN0234", 10000, 0.5, VehicleStatuses.Available)
            });

            //Add Bookings
            var vehicle1 = _vehicles.Single(v => v.Id.Equals(3));
            var person1 = _persons.Single(p => p.Id.Equals(1));
            _bookings.Add(new Bookings(1, vehicle1, person1));

            var vehicle2 = _vehicles.Single(v => v.Id.Equals(4));
            var person2 = _persons.Single(p => p.Id.Equals(2));
            _bookings.Add(new Bookings(2, vehicle2, person2));

            // Drive vehicle2
            vehicle2.Drive(100);

            //Return Vehicle2
            var booking = GetBooking(vehicle2.Id);
            booking.ReturnVehicle(vehicle2);

            //var vehicle3 = _vehicles.Single(v => v.Id.Equals(5));
            //_bookings.Add(new Bookings(3, vehicle3, person2));

            //// Drive vehicle3
            //vehicle3.Drive(200);

            //Return Vehicle3
            //booking = GetBooking(vehicle3.Id);
            //booking.ReturnVehicle(vehicle3);


            
        }
        #endregion Construction

        #region Phase1Methods
        public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status)
        {

            if (status == 0)
            {
                return _vehicles;
            }
            else
                return _vehicles.FindAll(v => v.Status.Equals(status));
        }

        


        public IVehicle GetVehicle(string registrationNumber)
        {
            return _vehicles.SingleOrDefault(v => v.RegistrationNumber.Equals(registrationNumber));
        }




        public IVehicle GetVehicle(int id)
        {
            return _vehicles.SingleOrDefault(v => v.Id.Equals(id));
        }




        public IEnumerable<IBooking> GetBookings()
        {
            return _bookings;
        }



        public IBooking GetBooking(int vehicleId)
        {
            return _bookings.SingleOrDefault(b => b.VehicleId==vehicleId && b.Returned == DateTime.MinValue); //only consider open bookings

        }



        public IEnumerable<IPerson> GetPersons()
        {
            return _persons;
        }



        public IPerson GetPerson(string socialSecurityNumber)
        {
            return _persons.SingleOrDefault(p => p.SocialSecurityNumber.Equals(socialSecurityNumber));
        }



        public IPerson GetPerson(int Id)
        {
            return _persons.SingleOrDefault(p => p.Id.Equals(Id));
        }
        #endregion Phase1Methods




        #region Phase2Methods

        
        public void AddVehicle(IVehicle vehicle)
        {
            
                _vehicles.Add(vehicle);
            
        }

        



        public void AddPerson(IPerson customer)
        {
            
                _persons.Add(customer);
           

        } 



        public IBooking RentVehicle(int vehicleId, int customerId)
        {
            var vehicleBooking = GetVehicle(vehicleId);
           
            var personBooking = GetPerson(customerId);
           
            var newBooking = new Bookings(NextBookingId, vehicleBooking, personBooking);

            _bookings.Add(newBooking);

            return newBooking;
        }



        public IBooking ReturnVehicle(int vehicleId)
        {
                        
            var returnVehicle = GetBooking(vehicleId);
            var vehicleBooked = GetVehicle(vehicleId);
            returnVehicle.ReturnVehicle(vehicleBooked);
            
            return returnVehicle;
        }
        #endregion Phase2Methods
    }
}
