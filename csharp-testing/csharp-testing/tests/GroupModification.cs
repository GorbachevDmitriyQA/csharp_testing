using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook
{
    [TestFixture]
    public class GroupModification : TestBaseAuth
    {
        [Test]
        public void EditGroup()
        {

            app.Navigator.OpenGroupPage();
            GroupData newGroupData = new GroupData("edit");
            newGroupData.Footer = "edit";
            newGroupData.Header = "edit";
            app.GroupHelper.VerificationGroup(newGroupData);

            // Создаем список с имеющимися группами 
            List<GroupData> oldGroup = app.GroupHelper.GetGroupList();
            GroupData toBeEdit = oldGroup[0];

            // Проверяем, что в первая группа не имеет имя = "edit"
            if (oldGroup[0].Name == "edit")
            {
                newGroupData.Name = "pupsik";
            }
            app.GroupHelper.GroupModificated(newGroupData, 0);
            app.Navigator.OpenGroupPage();
            Assert.AreEqual(oldGroup.Count, app.GroupHelper.GetConuntGroup());

            // Создаем список с имеющимися группами после изменений
            List<GroupData> newGroup = app.GroupHelper.GetGroupList();
            Assert.AreNotEqual(newGroup, oldGroup);

           foreach (GroupData group in newGroup)
            {
                if (group.Id == toBeEdit.Id)
                {
                    Assert.AreNotEqual(toBeEdit.Name, group.Name);
                }
            }
        }

    }
}
