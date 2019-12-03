using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Interfaces
{
    public interface IPerson
    {
        int Id { get; }
        string SocialSecurityNumber { get; }
        string FirstName { get; }
        string LastName { get; }
        string FullName { get;  }


        //In the class: override the ToString method and have it return an 
        //interpolated string with first name, last name and social security number
        //eg John Doe (123456)
    }
}
