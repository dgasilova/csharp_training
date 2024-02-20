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
    public class ContactCreationTests : TestBase
    {
        

        [Test]
        public void ContactCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret")); ;
            GoToAddNewPage();
            ContactData contact = new ContactData("Ivan");
            contact.Lastname = "Ivanov";
            FillContactForm(contact);
            SubmitContactCreation();
            GoToHomePage();
            Logout();
        }
         
    }
}
