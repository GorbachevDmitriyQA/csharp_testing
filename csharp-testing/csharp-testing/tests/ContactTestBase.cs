using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook
{
    public class ContactTestBase :TestBaseAuth
    {
        [TearDown]
        public void CompareGroupUi_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<PersonInfo> fromUi = app.ContactHelper.GetContactList();
                List<PersonInfo> fromDb = PersonInfo.GetAllContact();
                fromUi.Sort();
                fromDb.Sort();
                Assert.AreEqual(fromUi, fromDb);

            }
        }
    }
}
