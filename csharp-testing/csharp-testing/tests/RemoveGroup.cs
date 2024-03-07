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
using NUnit.Framework;

namespace Addressbook
{
    [TestFixture]
    internal class RemoveGroup : TestBaseAuth
    {
        [Test]
        public void RemovalGroup()
        {
            app.Navigator.OpenGroupPage();
            app.GroupHelper.VerificationGroup(new GroupData());
            List<GroupData> oldGroup = app.GroupHelper.GetGroupList();
            app.GroupHelper.RemoveGroup(0);
            app.Navigator.OpenGroupPage();
            Assert.AreEqual(oldGroup.Count - 1, app.GroupHelper.GetConuntGroup());

            List<GroupData> newGroup = app.GroupHelper.GetGroupList();
            oldGroup.RemoveAt(0);
            Assert.AreEqual(oldGroup, newGroup);
            app.AuthUser.Logout();
        }
    }
}