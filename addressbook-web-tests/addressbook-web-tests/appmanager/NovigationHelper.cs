using OpenQA.Selenium;
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

    public class NovigationHelper: HelperBase
    {
        private string baseURL;

        public NovigationHelper(ApplicationManager manager, string baseURL): base(manager) 
        {
            this.baseURL = baseURL;
        }

        public void GoToHomePage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToGroupsPage()

        {
            if (driver.Url == baseURL + "group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void PressHome()
        {
            if (driver.Url == baseURL
                && IsElementPresent(By.Name("searchstring")))
            {
                return;
            }
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
