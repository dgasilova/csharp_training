using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    { 
        [Test]
        public void GroupModificationTest()
        {
            if (!app.Groups.IsPresent(1))
            {
                app.Groups.Create(new GroupData("Some name"));
            }

            GroupData newDate = new GroupData("zzz");
            newDate.Header = null;
            newDate.Footer = null;

            app.Groups.Modyfy(1, newDate);
        }

    

    }
}
