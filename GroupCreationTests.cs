using System;
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
                //driver?.Quit();
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

        private void SubmitGroupCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Enter information']")).Click();
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

        private void InitGroupCreation()
        {
            driver.FindElement(By.XPath("//input[@value='New group']")).Click();
        }

        private void GoToGroupsPage()
        {
            driver.FindElement(By.XPath("//*[@class='admin']")).Click();
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