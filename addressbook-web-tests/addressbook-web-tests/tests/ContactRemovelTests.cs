using System;
using System.Collections.Generic;
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
    public class ContactRemovelTests : AuthTestBase
    {
        
        [Test]
        public void ContactRemovelTest()
        {
            if (!app.Contacts.IsPresent())
            {
                app.Contacts.Create(new ContactData("Some name","Some lastname"));
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Remove(1);

            ClassicAssert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);

            ClassicAssert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                ClassicAssert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

        }

    }
}
