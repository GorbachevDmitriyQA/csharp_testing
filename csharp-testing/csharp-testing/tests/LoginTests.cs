using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]

        public void LoginWithValidCredentials()
        {
            app.AuthUser.Logout();

            AccountData admin = new AccountData("admin", "secret");
            app.AuthUser.Login(admin);

            Assert.IsTrue(app.AuthUser.IsLoggedIn(admin));


        }

        [Test]

        public void LoginWithInvalidCredentials()
        {
            app.AuthUser.Logout();

            AccountData admin = new AccountData("admin", "qwe");
            app.AuthUser.Login(admin);

            Assert.IsFalse(app.AuthUser.IsLoggedIn(admin));


        }
    }
}
