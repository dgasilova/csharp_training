using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    { 
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

        public string Adress { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }

        public string AllPhones
        {
            get
            {
                if (AllPhones != null)
                {
                    return AllPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                AllPhones = value;
            }
        }

        

        private  string CleanUp(string phone)
        {
           if (phone== null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone,"[ -()]","")  + "\r\n";
        }

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
