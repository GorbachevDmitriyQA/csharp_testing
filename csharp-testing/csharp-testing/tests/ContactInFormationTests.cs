using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Addressbook;
using NUnit.Framework;

namespace Addressbook
{
    [TestFixture]
    public class ContactInFormationTests : TestBaseAuth
    {
        [Test]
        public void TestContactInFormation()
        {
            PersonInfo formTable = app.ContactHelper.GetContactInFormationFromTable(0);
            PersonInfo formEdit = app.ContactHelper.GetContactInFormationFromEditForm(0);

            Assert.AreEqual(formTable, formEdit);
            Assert.AreEqual(formTable.Address, formEdit.Address);
            Assert.AreEqual(formTable.AllPhones, formEdit.AllPhones);
            
        }
    }
}
