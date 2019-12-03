using CarRental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Classes
{
   public class Customer : IPerson
    {
        public int Id { get; set; } = default;
        public string SocialSecurityNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName} ({SocialSecurityNumber})";


        //constructor
        public Customer(int ID, string socialSecurityNum, string fName, string lName)
        {
            
            Id = ID;
            SocialSecurityNumber = socialSecurityNum;
            FirstName = fName;
            LastName = lName;
            
        }



        

    }
}
