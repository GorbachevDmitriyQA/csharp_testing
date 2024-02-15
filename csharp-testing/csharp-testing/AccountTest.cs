﻿// Generated by Selenium IDE
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

    [TestFixture]
    public class ContactTest
    {
        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;
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
        [Test]
        public void contact()
        {
            OpenHomePage();
            SetWindowSize();
            Login(new AccountData("admin", "secret"));
            PersonInfo personInfo = new PersonInfo("Diman");
            personInfo.LastName = "Nefor";
            personInfo.Address = "Limbo";
            personInfo.Email = "nownownow@mail.ru";
            CreateNewAccount(personInfo);
            Logout();

        }

        private void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void CreateNewAccount(PersonInfo personInfo)
        {
            driver.FindElement(By.LinkText("add new")).Click();
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).SendKeys(personInfo.FirstName);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).SendKeys(personInfo.LastName);
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).SendKeys(personInfo.Address);
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).SendKeys(personInfo.Email);
            driver.FindElement(By.Name("submit")).Click();
            //IDE Ругается на устаревший метод, но он работает. Что в данном случае лучше применить?
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            //Если не использовать таймаут = не удается найти елемент для логаута и тест падает. 
            //driver.FindElement(By.LinkText("home")).Click();
        }

        private void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("input:nth-child(7)")).Click();
        }

        private void SetWindowSize()
        {
            driver.Manage().Window.Size = new System.Drawing.Size(2575, 1415);
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
    }
}
