﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Addressbook
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(AppManager manager, string baseURL):base(manager)
        {
            this.manager = manager;
            this.baseURL = baseURL;
        }

        public void OpenToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        public void OpenGroupPage()
        {
            //driver.FindElement(By.LinkText("group page")).Click();
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToNewContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void GoToContactPage()
        {
            {
                driver.FindElement(By.LinkText("home")).Click();
            }
        }
    }
}
