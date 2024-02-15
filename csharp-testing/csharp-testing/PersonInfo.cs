using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTest
{
    internal class PersonInfo
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Address { get; set; } = "";
        public string Email { get; set; } = "";
        
        public PersonInfo(string firstName)
        {
            FirstName = firstName;
        }

        public PersonInfo(string firstName, string lastName, string address, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Email = email;
        }   
    }
}
