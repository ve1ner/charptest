using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GoHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("aaa");
            group.Footer = "bbb";
            group.Header = "ccc";
            FillGroupForm(group);
            SubmitGroupCreation();

            var msgBox = driver.FindElement(By.XPath("//div[@class='msgbox']"));
            string actualText = msgBox.Text;

            Assert.That(actualText[0], Is.EqualTo('A'));
        }

        [Test]
        public void ContactCreationTest()
        {
            GoHomePage();
            Login(new AccountData("admin", "secret"));
            GoToContactsPage();
            ContactData contact = new ContactData("Vadim", "Secret");
            contact.Nickname = "veiner";
            contact.Homepage = "t.me/veiner";
            contact.Address = "Krasnodar";
            contact.Email = "veiner@yandex-team.ru";
            contact.Title = "QA";
            FillContactForm(contact);
            SubmitContactCreation();
        }

        [Test]
        public void ExportAIOTest()
        {
            GoToBasePage();
            LoginData login = new LoginData("admin", "secret");
            LLogin(login);
            GoToExportPage();
            Exportdownload("CSV for Nokia");
        }

        
    }
}