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
        protected LoginHelper loginHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        protected LogoutHelper logoutHelper;


        private AppManager()
        {
            //FirefoxOptions options = new FirefoxOptions();
            //options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
            //driver = new FirefoxDriver(options);
            //driver.Manage().Window.Maximize();
            ChromeOptions options = new ChromeOptions();
            options.BinaryLocation = @"c:\program files (x86)\google\chrome\application\chrome.exe";
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
            baseURL = "http://localhost:8080/addressbook/";
            //driver.Manage().Window.Size = new System.Drawing.Size(2575, 1415);
            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
            logoutHelper = new LogoutHelper(this);
          
        }
        //При вызове браузер не закрывается
        ~AppManager()
        {
            driver.Quit();
        }

        public NavigationHelper Navigator
        {
            get { return navigator; }
        }
        public LoginHelper LoginHelper
        {
            get { return loginHelper;}
        }
        public GroupHelper GroupHelper
        {
            get { return groupHelper;}
        }
        public ContactHelper ContactHelper
        {
            get { return contactHelper; }
        }
        public LogoutHelper LogoutHelper
        {
            get { return logoutHelper; }
        }

        public IWebDriver Driver
        {
            get { return driver; }
        }

        public static AppManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                app.Value = new AppManager();
            }
            return app.Value;
        }
    }

}
