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
            if (!app.Groups.IsPresent(1))
            {
                app.Groups.Create(new GroupData("Some name"));
            }

            app.Groups.Remove(1);

            ClassicAssert.IsTrue(app.Groups.IsPresent(1));
        }

    }
}
