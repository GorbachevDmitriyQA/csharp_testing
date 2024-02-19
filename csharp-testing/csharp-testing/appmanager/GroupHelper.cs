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
    public class GroupHelper : HelperBase
    {
        public GroupHelper(AppManager manager) : base(manager) { }

        public void Create(GroupData groupData)
        {
            manager.Navigator.OpenGroupPage();
            InitNewGroutCreation();
            FillGroupForm(groupData);
            SubmitGroupCreation();
            manager.Navigator.OpenGroupPage();
        }

        private void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        private void FillGroupForm(GroupData groupData)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).SendKeys(groupData.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).SendKeys(groupData.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).SendKeys(groupData.Footer);
        }

        private void InitNewGroutCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        public void RemoveGroup(int groupSelect)
        {
            SelectedGroup(groupSelect);
            driver.FindElement(By.Name("delete")).Click();
        }

        public void SelectedGroup(int groupSelect)
        {
            driver.FindElement(By.XPath("(//input[@name ='selected[]'])[" + groupSelect + "]")).Click();
        }

        public void GroupModificated(GroupData groupData)
        {
            GoToEditGroup();
            EditGroupForm(groupData);
            SubmitUpdateGroup();
        }
        public void GoToEditGroup()
        {
            driver.FindElement(By.Name("edit")).Click();
        }

        public void SubmitUpdateGroup()
        {
            driver.FindElement(By.Name("update")).Click();
        }

        public void EditGroupForm(GroupData groupData)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).SendKeys(groupData.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).SendKeys(groupData.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).SendKeys(groupData.Footer);
        }
    }
}
