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
            //TO DO Добавить что-нибудь что проверяло бы какое имя у первой группы и если оно = edit, то заменить
            // Суть проблемы в том, что проверка упадет из-за того что группа была edit и осталась ей же после модификации. 
            // а мы проверяем что они не равны.
            GroupData newGroupData = new GroupData("edit");
            newGroupData.Footer = "edit";
            newGroupData.Header = "edit";
            app.Navigator.OpenGroupPage();
            app.GroupHelper.VerificationGroup(newGroupData);

            // Создаем список с имеющимися группами 
            List<GroupData> oldGroup = app.GroupHelper.GetGroupList();
            app.GroupHelper.GroupModificated(newGroupData, 0);
            app.Navigator.OpenGroupPage();
            Assert.AreEqual(oldGroup.Count, app.GroupHelper.GetConuntGroup());

            // Создаем список с имеющимися группами после изменений
            List<GroupData> newGroup = app.GroupHelper.GetGroupList();
            Assert.AreNotEqual(newGroup, oldGroup);
        }

    }
}
