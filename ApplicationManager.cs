using System;
using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
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
    public class ApplicationManager
    {
        protected IWebDriver driver = null!;
        protected string baseURL = "http://localhost/addressbook";

        protected LoginHelper loginHelper;
        protected GroupHelper groupHelper;
        protected NavigationHelper navigator;
        protected ContactHelper contactHelper;

        public ApplicationManager(IWebDriver driver)
        {
            Driver = driver;
            loginHelper = new LoginHelper(driver);
            groupHelper = new GroupHelper(driver);
            contactHelper = new ContactHelper(driver);
            navigator = new NavigationHelper(driver, baseURL);
        }

        public IWebDriver Driver { get; }
        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }
        public NavigationHelper Navigator
        {
            get
            {
                return navigator;
            }
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
        public ContactHelper Contacts
        {
            get
            {
                return contactHelper;
            }
        }

        public void Stop() => Driver?.Quit();
    }
}
