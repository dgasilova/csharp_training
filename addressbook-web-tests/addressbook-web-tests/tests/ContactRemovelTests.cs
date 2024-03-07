using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
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

            app.Contacts.Remove(1);
        }

    }
}
