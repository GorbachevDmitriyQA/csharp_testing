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
    /// <summary>
    /// qweqweqwe
    /// </summary>
    public class AppManager 
    {
        protected IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        public string baseURL;

        protected NavigationHelper navigator;
        protected AuthHelper authHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        public AppManager()
        {

            ChromeOptions options = new ChromeOptions();
            options.BinaryLocation = @"c:\program files (x86)\google\chrome\application\chrome.exe";
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
            baseURL = "http://localhost:8080/addressbook/";
            authHelper = new AuthHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }
        public IWebDriver Driver
        {
            get { return driver; }
        }
        public NavigationHelper Navigator
        {
            get { return navigator; }
        }
        public AuthHelper AuthUser
        {
            get { return authHelper; }
            //Comment
        }
        public GroupHelper GroupHelper
        {
            get { return groupHelper;}
        }
        public ContactHelper ContactHelper
        {
            get { return contactHelper; }
        }

    }

}
