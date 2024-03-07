using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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

            app.Contacts.Modyfy(1, newDate);
        }
    }
}
