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
        //protected IWebDriver driver;
        //public IDictionary<string, object> vars { get; private set; }
        //private IJavaScriptExecutor js;
        //public string baseURL;

        //protected NavigationHelper navigation;
        //protected LoginHelper loginHelper;
        //protected GroupHelper groupHelper;
        //protected ContactHelper contactHelper;

        protected AppManager app;

        [SetUp]
        public void SetUp()
        {
            app = new AppManager();
           // FirefoxOptions options = new FirefoxOptions();
            //options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
            // options.UseLegacyImplementation = true;
           // driver = new FirefoxDriver(options);
            //baseURL = "http://localhost:8080/addressbook/";
            //loginHelper = new LoginHelper(driver);
            //navigation = new NavigationHelper(driver, baseURL);
           // groupHelper = new GroupHelper(driver);
           // contactHelper = new ContactHelper(driver);
           // driver.Manage().Window.Size = new System.Drawing.Size(2575, 1415);


        }
        [TearDown]
        protected void TearDown()
        {
           app.Stop();
        }
    }
}
