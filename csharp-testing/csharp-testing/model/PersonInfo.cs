using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB.Mapping;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook
{
    [Table(Name = "addressbook")]
    public class PersonInfo : IEquatable<PersonInfo>, IComparable<PersonInfo>
    {
        private string allPhones;
        private string details;

        [Column(Name = "firstname")]
        public string FirstName { get; set; } = "default";

        [Column(Name = "lastname")]
        public string LastName { get; set; } = "default";
        
        [Column(Name = "address")]
        public string Address { get; set; } = "default";

        [Column(Name = "home")]
        public string HomePhone { get; set; } = "default";

        [Column(Name = "work")]
        public string WorkPhone { get; set; } = "default";

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; } = "default";

        [Column(Name = "email")]
        public string Email { get; set; } = "default";

        [Column(Name = "id")]
        public string Id { get; set;  }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public int CompareTo(PersonInfo other)
        {
            if (other == null)
            { 
                return 1;
            }
            return LastName.CompareTo(other.LastName);
        }

        public string Details
        {
            get
            {
                if (details != null)
                {
                    return details;
                }
                else
                {
                    return CleanUpDetails(FirstName)
                        + CleanUpDetails(LastName)
                        + CleanUpDetails(Address)
                        + CleanUpDetails(AllPhones)
                        + CleanUpDetails(Email);
                }
            }
            set
            {
                details = value;
            }
        }

        private string CleanUpDetails(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            else
            {
                return text.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "")
                    .Replace("\r", "").Replace("default", "").Replace("H:", "").Replace("M:", "")
                    .Replace("W:", "").Replace("\n", "");
            }

        }

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
                    return CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            else
            {
                return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "")+ "\r\n";
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
        
        public static List<PersonInfo> GetAllContact() 
        {
            using(AddressbookDB db =  new AddressbookDB())
            {
                //return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
                return (from c in db.Contacts
                        where c.Deprecated == "0000-00-00 00:00:00"
                        select c).ToList();
            }
        }
    }
}
