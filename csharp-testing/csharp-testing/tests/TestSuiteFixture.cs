using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook
{
    public class TestSuiteFixture
    {
        [SetUp]
        public void InitApplicationManager()
        {

                AppManager app = AppManager.GetInstance();
                app.Navigator.OpenToHomePage();
                app.LoginHelper.Login(new AccountData("admin", "secret"));
        }
    }
}
