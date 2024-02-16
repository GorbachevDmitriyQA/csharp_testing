using System;
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
    public class LogoutHelper : HelperBase
    {
        public LogoutHelper(IWebDriver driver):base(driver) { }

        public void LogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}
