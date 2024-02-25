﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {

            ContactData newDate = new ContactData("TestContact");
            newDate.Lastname = "TestContact1";

            app.Contacts.Modyfy(1, newDate);
        }
    }
}
