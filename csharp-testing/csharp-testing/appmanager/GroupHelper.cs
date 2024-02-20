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
            TypeFillCreateGroup(By.Name("group_name"), groupData.Name);
            TypeFillCreateGroup(By.Name("group_header"), groupData.Header);
            TypeFillCreateGroup(By.Name("group_footer"), groupData.Footer);
        }

        private void TypeFillCreateGroup(By locator, string text)
        {
            if(text != null)
            {
                driver.FindElement(locator).Click();
                driver.FindElement(locator).SendKeys(text);
            }
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
            TypeFillEditGroup(By.Name("group_name"), groupData.Name);
            TypeFillEditGroup(By.Name("group_header"), groupData.Header);
            TypeFillEditGroup(By.Name("group_footer"), groupData.Footer);
        }

        private void TypeFillEditGroup(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }
    }
}
