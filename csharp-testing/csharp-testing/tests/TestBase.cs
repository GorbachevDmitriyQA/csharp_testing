using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using AccountTest;
using System.Runtime.CompilerServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Addressbook
{
    public class TestBase 
    {
        protected AppManager app;

        [SetUp]
        public void SetUpAppManager()
        {
            app = new AppManager();
            app.Navigator.OpenToHomePage();
        }

        [TearDown]
        public void StopAppManager()
        {
            app.Driver.Quit();
        }
    }
}
