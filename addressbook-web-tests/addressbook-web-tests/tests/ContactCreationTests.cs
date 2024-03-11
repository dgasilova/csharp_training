using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        

        [Test]
        public void ContactCreationTest()
        {   
            ContactData contact = new ContactData("Ivan");
            contact.Lastname = "Ivanov";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            ClassicAssert.AreEqual(oldContacts, newContacts);
        }
         
    }
}
