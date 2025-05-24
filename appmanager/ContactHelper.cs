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
    public class ContactHelper : HelperBase
    {
    public ContactHelper(IWebDriver driver) : base(driver)
        {
        }
            public void Exportdownload(string type)
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




        public void SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//input[@name='submit']")).Click();
        }



        public void FillContactForm(ContactData contact)
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
    }
}
