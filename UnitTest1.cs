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
        public void TestAddressBookAccess()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys("admin");
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys("secret");
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            driver.FindElement(By.XPath("//*[@class='admin']")).Click();
            driver.FindElement(By.XPath("//input[@value='New group']")).Click(); 
            driver.FindElement(By.XPath("//input[@name='group_name']")).Click();
            driver.FindElement(By.XPath("//input[@name='group_name']")).SendKeys("name");
            driver.FindElement(By.XPath("//textarea[@name='group_header']")).Click();
            driver.FindElement(By.XPath("//textarea[@name='group_header']")).SendKeys("header");
            driver.FindElement(By.XPath("//textarea[@name='group_footer']")).Click();
            driver.FindElement(By.XPath("//textarea[@name='group_footer']")).SendKeys("footer"); 
            driver.FindElement(By.XPath("//input[@value='Enter information']")).Click();
            var msgBox = driver.FindElement(By.XPath("//div[@class='msgbox']"));
            string actualText = msgBox.Text;
            Assert.That(actualText[0], Is.EqualTo('A'));
        }
    }
}