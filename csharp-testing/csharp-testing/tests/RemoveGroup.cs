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
using NUnit.Framework;

namespace Addressbook
{
    [TestFixture]
    internal class RemoveGroup : GroupTestBase
    {
        [Test]
        public void RemovalGroup()
        {
            app.Navigator.OpenGroupPage();
            app.GroupHelper.VerificationGroup(new GroupData());
            List<GroupData> oldGroup = GroupData.GetAllGroups();
            GroupData toBeRemoved = oldGroup[0];
            app.GroupHelper.RemoveGroup(toBeRemoved);
            Assert.AreEqual(oldGroup.Count - 1, app.GroupHelper.GetConuntGroup());

            List<GroupData> newGroup = GroupData.GetAllGroups();
            oldGroup.RemoveAt(0);
            Assert.AreEqual(oldGroup, newGroup);

            // Проверяем что мы удалили действительно ту группу которую и хотели
            foreach (GroupData group in newGroup)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
            app.AuthUser.Logout();
        }
    }
}