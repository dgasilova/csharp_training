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
using System.Reflection;

namespace addressbook_web_tests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }

        public GroupHelper Create(GroupData group)
        {
            manager.Novigation.GoToGroupsPage();
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            manager.Novigation.GoToGroupsPage();
            return this;
        }

        public GroupHelper Modyfy(int v, GroupData newDate)
        {
            manager.Novigation.GoToGroupsPage();
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newDate);
            SubmitGroupModification();
            manager.Novigation.GoToGroupsPage();
            return this;
        }

        
        public GroupHelper Remove(int p)
        {
            manager.Novigation.GoToGroupsPage();

            if (IsPresent(p))
            {
                SelectGroup(p);
                RemoveGroup();
            }

            manager.Novigation.GoToGroupsPage();
            return this;
        }

        public bool IsPresent(int index) 
        {
            return IsElementPresent(By.XPath("//div[@id='content']/form/span[" + (index + 1) + "]/input"));
        }

        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
        
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (index+1) + "]/input")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[5]")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Novigation.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));


            foreach (IWebElement element in elements) 
            {
                GroupData group = new GroupData(element.Text);
                groups.Add(group);
            }
            return groups;
        }
    }

        
}
