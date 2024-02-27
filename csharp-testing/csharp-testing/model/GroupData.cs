using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook
{
    public class GroupData : IEquatable<GroupData>
    {
        public string Name { get; set; } = "default";
        public string Header { get; set; } = "default";
        public string Footer { get; set; } = "default";


        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            { 
                return true;
            }
            return Name == other.Name;
        }
        //public override int GetHashCode()
        //{
        //    return Name.GetHashCode();
        //}

        public GroupData()
        {

        }
        public GroupData(string name)
        {
            Name = name;
        }
        public GroupData(string name, string header, string footer)
        {
            Name = name;
            Header = header;
            Footer = footer;
        }       
    }

    
}
