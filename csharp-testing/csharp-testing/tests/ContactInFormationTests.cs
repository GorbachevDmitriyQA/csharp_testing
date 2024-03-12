using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Addressbook;
using NUnit.Framework;

namespace csharp_testing.tests
{
    [TestFixture]
    public class ContactInFormationTests : TestBaseAuth
    {
        [Test]
        public void TestContactInFormation()
        {
            AccountData formTable = app.ContactHelper.GetContactInFormationFromTable(0);
            AccountData formEdit = app.ContactHelper.GetContactInFormationFromEditForm(0);
        }
    }
}
