using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTest
{
    public class PersonInfo : IEquatable<PersonInfo>
    {
        public string FirstName { get; set; } = "default";
        public string LastName { get; set; } = "default";
        public string Address { get; set; } = "default";
        public string Email { get; set; } = "default";

        public bool Equals(PersonInfo other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            if (FirstName == other.FirstName && LastName == other.LastName) 
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }





        public PersonInfo() { }

        public PersonInfo(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

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
