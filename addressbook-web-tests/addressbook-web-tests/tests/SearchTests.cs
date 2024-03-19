using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;


namespace addressbook_web_tests

{
    [TestFixture]
    public class SearchTests: AuthTestBase
    {
        [Test]
        public void RestSearch () 
        { 
        System.Console.Out.WriteLine(app.Contacts.GetNumberOfSearchResults());
        }
    }
}
