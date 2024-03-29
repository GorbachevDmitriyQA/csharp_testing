﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook
{
    public class PersonInfo : IEquatable<PersonInfo>
    {
        private string allPhones;
        private string details;

        public string FirstName { get; set; } = "default";
        public string LastName { get; set; } = "default";
        public string Address { get; set; } = "default";
        public string HomePhone { get; set; } = "default";
        public string WorkPhone { get; set; } = "default";
        public string MobilePhone { get; set; } = "default";
        public string Email { get; set; } = "default";

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
    }
}
