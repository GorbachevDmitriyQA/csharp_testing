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
            TypeFillCreateContact(By.Name("firstname"), person.FirstName);
            TypeFillCreateContact(By.Name("lastname"), person.LastName);
            TypeFillCreateContact(By.Name("address"), person.Address);
            TypeFillCreateContact(By.Name("email"), person.Email);
        }

        private void TypeFillCreateContact(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Click();
                driver.FindElement(locator).SendKeys(text);
            }
        }

        private void TypeFillEditContact(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }

        public void DeleteContact(int contactSelect)
        {
            SelectContact(contactSelect);
            driver.FindElement(By.CssSelector("input[value=Delete]")).Click();
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(1000);
        }

        public void SelectContact(int contactSelect)
        {
            driver.FindElement(By.XPath("(//input[@name ='selected[]'])[" + contactSelect + "]")).Click();
        }

        public void EditContact(int contactSelect, PersonInfo newPerson)
        {
            SelectContact(contactSelect);
            EditContact();
            FillEditContact(newPerson);
            SubmitEditContact();
            Thread.Sleep(1000);


        }

        public void EditContact()
        {
            driver.FindElement(By.CssSelector("tr:nth-child(4) > .center:nth-child(8) img")).Click();
        }

        public void FillEditContact(PersonInfo person)
        {
            TypeFillEditContact(By.Name("firstname"), person.FirstName);
            TypeFillEditContact(By.Name("lastname"), person.LastName);
            TypeFillEditContact(By.Name("address"), person.Address);
            TypeFillEditContact(By.Name("email"), person.Email);
        }

        public void SubmitEditContact()
        {
            driver.FindElement(By.Name("update")).Click();
        }


    }
}
