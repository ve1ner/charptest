using NUnit.Framework;
using OpenQA.Selenium;
using Assert = NUnit.Framework.Assert;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.InitGroupCreation();
            GroupData group = new GroupData("aaa");
            group.Footer = "bbb";
            group.Header = "ccc";
            app.Groups.FillGroupForm(group);
            app.Groups.SubmitGroupCreation();

            var msgBox = driver.FindElement(By.XPath("//div[@class='msgbox']"));
            string actualText = msgBox.Text;

            Assert.That(actualText[0], Is.EqualTo('A'));
            app.Navigator.GoToGroupsPage();
            app.Groups.SelectGroup(1);
            app.Groups.GroupDelete();
            msgBox = driver.FindElement(By.XPath("//div[@class='msgbox']"));
            actualText = msgBox.Text;
            Assert.That(actualText[0], Is.EqualTo('G'));
        }
    }
}