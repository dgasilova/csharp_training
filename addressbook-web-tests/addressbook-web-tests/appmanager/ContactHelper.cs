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
            InitContactModification(0);
            FillContactForm(newDate);
            SubmitContactModification();
            manager.Novigation.GoToHomePage();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
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
            contactCache = null;
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
            contactCache = null;
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Novigation.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name=\"entry\"]"));

                 foreach ( IWebElement element in elements)
                 {
                    var cells = element.FindElements(By.TagName("td"));
                    var id = cells[0].FindElement(By.TagName("input")).GetAttribute("value");
                    var lastName = cells[1].Text;
                    var name = cells[2].Text;

                    contactCache.Add(new ContactData(element.Text)
                    {
                        Id = id,
                        Lastname = lastName,
                        Name = name
                    });

                }

            }

            return new List<ContactData>(contactCache);
        }


       
        public int GetContactsCount()
        {
            return GetContactList().Count();
        }

        internal ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Novigation.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Adress = address,
                AllPhones = allPhones,
            };
        }

        internal ContactData GetContactInformationFromTable(int index)
        {
            manager.Novigation.GoToHomePage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstName")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastName")).GetAttribute("value");
            string address = driver.FindElement(By.Name("adress")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            return new ContactData(firstName, lastName)
            {
                Adress = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };
        }

        public int GetNumberOfSearchResults()
        {
            manager.Novigation.GoToHomePage();
            string text =driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

    }
}
