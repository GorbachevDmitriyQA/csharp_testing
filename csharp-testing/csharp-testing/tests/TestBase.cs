using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using System.Runtime.CompilerServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Text;

namespace Addressbook
{
    public class TestBase 
    {
        protected AppManager app;
        public static bool PERFORM_LONG_UI_CHECKS = false;

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

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }
    }
}
