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
    public class GroupModificationTests : TestBase
    { 
        [Test]
        public void GroupModificationTest()
        {

            GroupData newDate = new GroupData("zzz");
            newDate.Header = "ttt";
            newDate.Footer = "qqq";

            app.Groups.Modyfy(1, newDate);
        }

    

    }
}
