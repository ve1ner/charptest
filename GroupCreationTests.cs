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
    public class GroupCreationTests
    {
        private IWebDriver driver = null!;
        private StringBuilder verificationErrors = null!;
        private string baseURL = null!;

        [SetUp]
        public void SetupTest()
        {
            var options = new ChromeOptions();

            options.BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            driver = new ChromeDriver(@"C:\Users\veiner\Documents\drive\", options); 

            baseURL = "http://localhost/addressbook/";
            verificationErrors = new StringBuilder();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver?.Quit();
            }
            catch (Exception)
            {
             
            }
            Assert.That(verificationErrors.ToString(), Is.Empty, verificationErrors.ToString());
        }

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
            login.Ghoul = "admin";
            LLogin(login);
            GoToExportPageSKibidi();
            Exportdownload("CSV for Nokia");
        }

        private void Exportdownload(string type)
        {
            switch (type)
            {
                case "AIO":
                    driver.FindElement(By.XPath("//form[.//label[contains(text(), 'All in one vCard')]]//input[@type='submit']")).Click();
                    break;
                case "vCards for Outlook":
                    driver.FindElement(By.XPath("//form[.//label[contains(text(), 'All in one vCard')]]//input[@type='submit']")).Click();
                    break;
                case "CSV for Excel":
                    driver.FindElement(By.XPath("//form[.//label[contains(text(), 'All in one vCard')]]//input[@type='submit']")).Click();
                    break;
                case "CSV for Nokia":
                    driver.FindElement(By.XPath("//form[.//label[contains(text(), 'All in one vCard')]]//input[@type='submit']")).Click();
                    break;
            }
        }

        private void GoToExportPageSKibidi()
        {
            driver.FindElement(By.XPath("//*[@href='export.php']")).Click();
        }

        private void LLogin(LoginData login)
        {
            driver.FindElement(By.XPath("//input[@name='user']")).Click();
            driver.FindElement(By.XPath("//input[@name='user']")).SendKeys(login.Username);
            driver.FindElement(By.XPath("//input[@name='pass']")).Click();
            driver.FindElement(By.XPath("//input[@name='pass']")).SendKeys(login.Password);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        private void GoToBasePage()
        {
            driver.Navigate().GoToUrl("http://localhost/addressbook/");
        }

        private void SubmitGroupCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Enter information']")).Click();
        }
        private void SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//input[@name='submit']")).Click();
        }

        private void FillGroupForm(GroupData group)
        {
            driver.FindElement(By.XPath("//input[@name='group_name']")).Click();
            driver.FindElement(By.XPath("//input[@name='group_name']")).SendKeys(group.Name);
            driver.FindElement(By.XPath("//textarea[@name='group_header']")).Click();
            driver.FindElement(By.XPath("//textarea[@name='group_header']")).SendKeys(group.Header);
            driver.FindElement(By.XPath("//textarea[@name='group_footer']")).Click();
            driver.FindElement(By.XPath("//textarea[@name='group_footer']")).SendKeys(group.Footer);
        }

        private void FillContactForm(ContactData contact)
        {
            driver.FindElement(By.XPath("//input[@name='firstname']")).Click();
            driver.FindElement(By.XPath("//input[@name='firstname']")).SendKeys(contact.FName);
            driver.FindElement(By.XPath("//input[@name='middlename']")).Click();
            driver.FindElement(By.XPath("//input[@name='middlename']")).SendKeys(contact.MName);
            //last
            driver.FindElement(By.XPath("//input[@name='lastname']")).Click();
            driver.FindElement(By.XPath("//input[@name='lastname']")).SendKeys(contact.LName);
            //nick
            driver.FindElement(By.XPath("//input[@name='nickname']")).Click();
            driver.FindElement(By.XPath("//input[@name='nickname']")).SendKeys(contact.Nickname);
            //photo
            //filedrop in progress
            //title
            driver.FindElement(By.XPath("//input[@name='title']")).Click();
            driver.FindElement(By.XPath("//input[@name='title']")).SendKeys(contact.Title);
            //company
            driver.FindElement(By.XPath("//input[@name='company']")).Click();
            driver.FindElement(By.XPath("//input[@name='company']")).SendKeys(contact.Company);
            //address
            driver.FindElement(By.XPath("//textarea[@name='address']")).Click();
            driver.FindElement(By.XPath("//textarea[@name='address']")).SendKeys(contact.Address);
            //telephones
            //home
            driver.FindElement(By.XPath("//input[@name='home']")).Click();
            driver.FindElement(By.XPath("//input[@name='home']")).SendKeys(contact.THome);
            //mobile
            driver.FindElement(By.XPath("//input[@name='mobile']")).Click();
            driver.FindElement(By.XPath("//input[@name='mobile']")).SendKeys(contact.TMobile);
            //work
            driver.FindElement(By.XPath("//input[@name='work']")).Click();
            driver.FindElement(By.XPath("//input[@name='work']")).SendKeys(contact.TWork);
            //work
            driver.FindElement(By.XPath("//input[@name='fax']")).Click();
            driver.FindElement(By.XPath("//input[@name='fax']")).SendKeys(contact.Fax);
            //emails
            //first
            driver.FindElement(By.XPath("//input[@name='email']")).Click();
            driver.FindElement(By.XPath("//input[@name='email']")).SendKeys(contact.Email);
            //second
            driver.FindElement(By.XPath("//input[@name='email2']")).Click();
            driver.FindElement(By.XPath("//input[@name='email2']")).SendKeys(contact.Email2);
            //third
            driver.FindElement(By.XPath("//input[@name='email3']")).Click();
            driver.FindElement(By.XPath("//input[@name='email3']")).SendKeys(contact.Email3);
            //homepage/
            driver.FindElement(By.XPath("//input[@name='homepage']")).Click();
            driver.FindElement(By.XPath("//input[@name='homepage']")).SendKeys(contact.Homepage);
            //bday
            //data in progress
            //anniversary
            //data in progress
            //group
            //dropdownlist in progress

        }

        private void InitGroupCreation()
        {
            driver.FindElement(By.XPath("//input[@value='New group']")).Click();
        }

        private void GoToGroupsPage()
        {
            driver.FindElement(By.XPath("//*[@class='admin']")).Click();
        } 

        private void GoToContactsPage()
        {
            driver.FindElement(By.XPath("//a[text()='add new']")).Click();
        } 

        private void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        private void GoHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
    }
}