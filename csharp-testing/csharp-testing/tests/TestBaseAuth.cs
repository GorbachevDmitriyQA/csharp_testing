using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook
{
     
    public class TestBaseAuth : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            app.AuthUser.Login(new AccountData("admin", "secret"));
        }

    }
}
