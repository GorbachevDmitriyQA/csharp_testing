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
using System.Security.Cryptography.X509Certificates;

namespace Addressbook
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected AppManager manager;

        public HelperBase(AppManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }

        public bool IsElemetnPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        ///Comment
    }
}
