using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook
{
    public class TestSuiteFixture
    {
        public static AppManager app;

        [SetUp]
        public void InitApplicationManager()
        {
            app = new AppManager();
            app.Navigator.OpenToHomePage();
            app.LoginHelper.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void StopApplicationManager()
        {
            app.Stop();
        }

    }
}
