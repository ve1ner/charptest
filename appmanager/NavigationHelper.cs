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
using static System.Net.WebRequestMethods;
using Assert = NUnit.Framework.Assert;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL = "http://localhost";
        public NavigationHelper(IWebDriver driver, string baseURL)
            : base(driver)
        {
            this.baseURL = baseURL;
        }

        public void GoToGroupsPage()
        {
            driver.FindElement(By.XPath("//*[@class='admin']")).Click();
        }
        public void GoToExportPage()
        {
            driver.FindElement(By.XPath("//*[@href='export.php']")).Click();
        }

        public void GoToBasePage()
        {
            driver.Navigate().GoToUrl("http://localhost/addressbook/");
        }
        public void GoToContactsPage()
        {
            driver.FindElement(By.XPath("//a[text()='add new']")).Click();
        }
        public void GoHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
    }
}
