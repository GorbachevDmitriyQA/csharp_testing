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
using AccountTest;

namespace Addressbook
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(AppManager manager) : base(manager) { }
        
        public void Create(PersonInfo person)
        {
            manager.Navigator.GoToNewContactPage();
            FillCreateContact(person);
            SubmitCreateContact();
            // После создания контакта, страница заново рендериться, чтобы найти LogOut использован слип. 
            Thread.Sleep(1000);
        }

        private void SubmitCreateContact()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        private void FillCreateContact(PersonInfo person)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).SendKeys(person.FirstName);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).SendKeys(person.LastName);
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).SendKeys(person.Address);
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).SendKeys(person.Email);
        }
    }
}
