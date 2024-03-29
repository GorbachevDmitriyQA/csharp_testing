using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook
{
    [TestFixture]
    public class GroupModification : GroupTestBase
    {
        public static IEnumerable<GroupData> GroupEditDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"editGroups.csv");
            foreach (string line in lines)
            {
                string[] parts = line.Split(",");
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });

            }
            return groups;
        }

        [Test, TestCaseSource(nameof(GroupEditDataFromCsvFile))]
        public void EditGroup(GroupData data)
        {
            app.GroupHelper.VerificationGroup(data);
            // Создаем список с имеющимися группами 
            List<GroupData> oldGroup = GroupData.GetAllGroups();
            GroupData toBeEdit = oldGroup[0];

            // Проверяем, что в первая группа не имеет имя = "edit"
            if (toBeEdit.Name == "editName")
            {
                data.Name = GenerateRandomString(10);
                data.Header = GenerateRandomString(10);
                data.Footer = GenerateRandomString(10);
            }
            app.GroupHelper.GroupModificated(toBeEdit, data);
            app.Navigator.OpenGroupPage();
            Assert.AreEqual(oldGroup.Count, app.GroupHelper.GetConuntGroup());

            // Создаем список с имеющимися группами после изменений
            List<GroupData> newGroup = GroupData.GetAllGroups();
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
