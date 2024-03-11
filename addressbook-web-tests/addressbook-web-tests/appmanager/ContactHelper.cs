using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
            
        }

        public ContactHelper Create(ContactData contact)
        {
            GoToAddNewPage();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Novigation.GoToHomePage();
            return this;
        }

        public ContactHelper Modyfy(int v, ContactData newDate)
        {
            manager.Novigation.GoToHomePage();
            SelectContact(v);
            InitContactModification();
            FillContactForm(newDate);
            SubmitContactModification();
            manager.Novigation.GoToHomePage();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[8]/a/img")).Click();
            return this;
        }

        public void Remove(int v)
        {
            manager.Novigation.GoToHomePage();

            if (IsPresent())
            {
                SelectContact(v);
                RemoveContact();
            }
                        
            manager.Novigation.PressHome();
            return;

        }

        public bool IsPresent()
        {
            // var totalElements = int.Parse(driver.FindElement(By.Id("search_count")).Text);
            var totalElements = driver.FindElements(By.CssSelector("tr[name=\"entry\"]")).Count;

            return totalElements > 0;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Novigation.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name=\"entry\"]"));


            foreach (IWebElement element in elements)
            {
                ContactData contact = new ContactData(element.Text);
                contacts.Add(contact);
            }
            return contacts;
        }

        public ContactHelper GoToAddNewPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Name);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[20]")).Click();
            return this;
        }

        public ContactHelper SelectContact(int v)
        {
            driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        
    }
}
