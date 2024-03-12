using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook
{
    public class PersonInfo : IEquatable<PersonInfo>
    {
        public string FirstName { get; set; } = "default";
        public string LastName { get; set; } = "default";
        public string Address { get; set; } = "default";
        public string HomePhone { get; set; } = "default";
        public string WorkPhone { get; set; } = "default";
        public string MobilePhone { get; set; } = "default";
        public string Email { get; set; } = "default";

        private string allPhones;
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return ClenUp(HomePhone) + ClenUp(MobilePhone) + ClenUp(WorkPhone).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string ClenUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            else
            {
                return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
            }
        }

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
