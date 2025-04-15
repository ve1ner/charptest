using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;


namespace SeleniumTests
{
    [TestFixture]
    public class AddressBookWebTests
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

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
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
        public void TestAddressBookAccess()
        {
            driver.Navigate().GoToUrl(baseURL);
            Assert.That(driver.Title, Does.Contain("Address book"));

        }
    }
}