using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTest
{
    public class PersonInfo
    {
        public string FirstName { get; set; } = "default";
        public string LastName { get; set; } = "default";
        public string Address { get; set; } = "default";
        public string Email { get; set; } = "default";

        public PersonInfo() { }
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
