using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using AccountTest;
using System.Runtime.CompilerServices;

namespace Addressbook
{
    public class TestBase
    {
        protected AppManager app;

        [SetUp]
        public void SetUp()
        {
            app = new AppManager();
            app.Navigator.OpenToHomePage();
            app.LoginHelper.Login(new AccountData("admin", "secret"));
        }
        [TearDown]
        protected void TearDown()
        {
           app.Stop();
        }
    }
}
