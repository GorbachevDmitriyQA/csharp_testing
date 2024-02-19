using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook
{
    [TestFixture]
    public class GroupModification : TestBase
    {
        [Test]
        public void EditGroup()
        {
            GroupData newGroupData = new GroupData("edit");
            newGroupData.Footer = "edit";
            newGroupData.Header = "edit";
            app.Navigator.OpenGroupPage();
            app.GroupHelper.SelectedGroup(1);
            app.GroupHelper.GroupModificated(newGroupData);
            app.Navigator.OpenGroupPage();
        }

    }
}
