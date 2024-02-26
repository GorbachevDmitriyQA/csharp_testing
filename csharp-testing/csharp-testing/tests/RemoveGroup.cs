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
            app.GroupHelper.RemoveGroup(1);
            app.Navigator.OpenGroupPage();
            app.AuthUser.Logout();
        }
    }
}