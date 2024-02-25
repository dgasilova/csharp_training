﻿using System;
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
    public class ContactRemovelTests : TestBase
    {
        
        [Test]
        public void ContactRemovelTest()
        {           
           
            app.Contacts.Remove(1);
        }

    }
}