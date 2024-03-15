using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string lastname;

        public ContactData(string firstname)
        {
            Name = firstname;
        }
        public ContactData(string firstname, string lastname)
        {
            Name = firstname; 
            Lastname = lastname; 
        }

        public string Name { get; set; }
        
       
        public string Lastname { get; set; }

        public string Id { get; set; }


        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name && Lastname == other.Lastname;
        }

        public int GetHashCode()
        {
            return Name.GetHashCode() + Lastname.GetHashCode();
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name) + Lastname.CompareTo(other.Lastname);
        }


    }
}
