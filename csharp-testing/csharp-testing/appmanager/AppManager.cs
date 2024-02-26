using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Addressbook
{



    public class AppManager 
    {
        protected IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        public string baseURL;
        private static ThreadLocal<AppManager> app = new ThreadLocal<AppManager>();


        protected NavigationHelper navigator;
        protected AuthHelper authHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;


        private AppManager()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
            driver = new FirefoxDriver(options);
            driver.Manage().Window.Maximize();
            //ChromeOptions options = new ChromeOptions();
            //options.BinaryLocation = @"c:\program files (x86)\google\chrome\application\chrome.exe";
            //options.AddArgument("start-maximized");
            //driver = new ChromeDriver(options);
            baseURL = "http://localhost:8080/addressbook/";
            //driver.Manage().Window.Size = new System.Drawing.Size(2575, 1415);
            authHelper = new AuthHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
          
        }
       


        public NavigationHelper Navigator
        {
            get { return navigator; }
        }
        public AuthHelper AuthUser
        {
            get { return authHelper; }
        }
        public GroupHelper GroupHelper
        {
            get { return groupHelper;}
        }
        public ContactHelper ContactHelper
        {
            get { return contactHelper; }
        }

        public IWebDriver Driver
        {
            get { return driver; }
        }

        public static AppManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                AppManager newInstance = new AppManager();
                newInstance.Navigator.OpenToHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }

    }

}
