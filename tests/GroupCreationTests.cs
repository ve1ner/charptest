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

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.GoHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToContactsPage();
            ContactData contact = new ContactData("Vadim", "Secret");
            contact.Nickname = "veiner";
            contact.Homepage = "t.me/veiner";
            contact.Address = "Krasnodar";
            contact.Email = "veiner@yandex-team.ru";
            contact.Title = "QA";
            app.Contacts.FillContactForm(contact);
            app.Contacts.SubmitContactCreation();
        }

        [Test]
        public void ExportAIOTest()
        {
            app.Navigator.GoToBasePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToExportPage();
            app.Contacts.Exportdownload("CSV for Nokia");
        }

        
    }
}