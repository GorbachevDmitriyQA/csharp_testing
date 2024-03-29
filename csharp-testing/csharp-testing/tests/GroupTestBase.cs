using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook
{
    public class GroupTestBase :TestBaseAuth
    {
        [TearDown]
        public void CompareGroupUi_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<GroupData> fromUi = app.GroupHelper.GetGroupList();
                List<GroupData> fromDb = GroupData.GetAllGroups();
                fromUi.Sort();
                fromDb.Sort();
                Assert.AreEqual(fromUi, fromDb);
            }
        }
    }
}
