using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovelTests : AuthTestBase
    {
        [Test]
        public void GroupRemovelTest()
        {
           if (!app.Groups.IsPresent(0))
            {
                app.Groups.Create(new GroupData("Some name"));
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            
            app.Groups.Remove(0);

            //ClassicAssert.IsFalse(app.Groups.IsPresent(0));

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);

            ClassicAssert.AreEqual(oldGroups, newGroups);
        }

    }
}
