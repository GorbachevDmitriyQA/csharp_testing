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
using System.Reflection;

namespace Addressbook
{
    public class ContactHelper : HelperBase
    {
        //private List<PersonInfo> contactCache = null;
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
            personListCache = null;
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
            personListCache = null;
            Thread.Sleep(1000);
        }

        public void SelectContact(int contactSelect)
        {
            driver.FindElement(By.XPath("(//input[@name ='selected[]'])[" + (contactSelect+1) + "]")).Click();
        }

        public void EditContact(int contactSelect, PersonInfo newPerson)
        {
            SelectContact(contactSelect);
            GoEditContacts();
            FillEditContact(newPerson);
            SubmitEditContact();
            Thread.Sleep(1000);


        }

        public void GoEditContacts()
        {
            driver.FindElement(By.CssSelector("tr:nth-child(2) > .center:nth-child(8) img")).Click();
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
            personListCache = null;
        }

        public void VerificationContanct(PersonInfo person)
        {
            if (IsElemetnPresent(By.Name("selected[]")))
            {
                return;
            }
            else
            {
                Create(person);
            }
        }

        private List<PersonInfo> personListCache = null;

        public List<PersonInfo> GetContactList()
        {
            if (personListCache == null)
            {
                personListCache = new List<PersonInfo>();
                manager.Navigator.GoToContactPage();
                ICollection<IWebElement> elementz = driver.FindElements(By.CssSelector("tr[name='entry']"));
                foreach (IWebElement element in elementz)
                {
                    var elem = element.FindElements(By.CssSelector("td"));
                    var firstName = elem[2].Text;
                    var lastName = elem[1].Text;
                    personListCache.Add(new PersonInfo(firstName, lastName));
                }
            }
            return new List<PersonInfo>(personListCache);
        }

        public PersonInfo GetContactInFormationFromTable(int index)
        {
            manager.Navigator.GoToContactPage();

            IList<IWebElement> celss = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));

            string lastName = celss[1].Text;
            string firstName = celss[2].Text;
            string address = celss[3].Text;
            string allPhones = celss[5].Text;

            return new PersonInfo(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones
            };
        }

        public PersonInfo GetContactInFormationFromEditForm(int index)
        {
            manager.Navigator.OpenToHomePage();
            InitContact(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new PersonInfo(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };
        }
        public void InitContact(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
        }
    }
}
