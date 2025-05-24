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
    public class GroupHelper : HelperBase
    {
        public GroupHelper(IWebDriver driver) : base(driver)
        {
        }
        public void SubmitGroupCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Enter information']")).Click();
        }

        public void FillGroupForm(GroupData group)
        {
            driver.FindElement(By.XPath("//input[@name='group_name']")).Click();
            driver.FindElement(By.XPath("//input[@name='group_name']")).SendKeys(group.Name);
            driver.FindElement(By.XPath("//textarea[@name='group_header']")).Click();
            driver.FindElement(By.XPath("//textarea[@name='group_header']")).SendKeys(group.Header);
            driver.FindElement(By.XPath("//textarea[@name='group_footer']")).Click();
            driver.FindElement(By.XPath("//textarea[@name='group_footer']")).SendKeys(group.Footer);
        }
        public void InitGroupCreation()
        {
            driver.FindElement(By.XPath("//input[@value='New group']")).Click();
        }

        public void GroupDelete()
        {
            driver.FindElement(By.XPath("//input[@name='delete']")).Click();
        }

        public void SelectGroup(int number)
        {
            driver.FindElement(By.XPath($"//span[@class='group'][{number}]/input")).Click();
        }
    }
}
