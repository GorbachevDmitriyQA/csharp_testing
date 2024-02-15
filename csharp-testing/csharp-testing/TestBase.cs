using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using AccountTest;

namespace Addressbook
{
    public class TestBase
    {
        protected IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        //private IJavaScriptExecutor js;
        public string baseURL;

        [SetUp]
        public void SetUp()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
            // options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost:8080/addressbook/";


        }
        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        protected void OpenToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        protected void LogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        protected void CreateGroup(GroupData groupData)
        {
            driver.FindElement(By.LinkText("groups")).Click();
            driver.FindElement(By.Name("new")).Click();
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).SendKeys(groupData.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).SendKeys(groupData.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).SendKeys(groupData.Footer);
            driver.FindElement(By.Name("submit")).Click();
        }

        protected void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("input:nth-child(7)")).Click();
        }

        protected void CustomizeWindow()
        {
            driver.Manage().Window.Size = new System.Drawing.Size(2575, 1415);
        }

        protected void OpenGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        protected void CreateNewAccount(PersonInfo person)
        {
            driver.FindElement(By.LinkText("add new")).Click();
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).SendKeys(person.FirstName);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).SendKeys(person.LastName);
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).SendKeys(person.Address);
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).SendKeys(person.Email);
            driver.FindElement(By.Name("submit")).Click();
            Thread.Sleep(1000);
            //IDE Ругается на устаревший метод, но он работает. Что в данном случае лучше применить?
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            //Если не использовать таймаут = не удается найти елемент для логаута и тест падает. 
            //driver.FindElement(By.LinkText("home")).Click();

        }
    }
}
