using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (!app.Contacts.IsPresent())
            {
                app.Contacts.Create(new ContactData("Some name", "Some lastname"));
            }

            ContactData newDate = new ContactData("TestContact");
            newDate.Lastname = null;

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modyfy(1, newDate);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[0].Lastname = newDate.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            
            ClassicAssert.AreEqual(oldContacts, newContacts);
        }
    }
}
