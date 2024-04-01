using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LinqToDB.Mapping;
using LinqToDB;
using Google.Protobuf;

namespace Addressbook
{
    public class RemoveContactFromGroup : ContactTestBase
    {
        [Test]
        
        public void RemoveContactsFromGroup()
        {
            List<GroupData> groups = GroupData.GetAllGroups();
            GroupData groupRemove = groups[0];
            List <PersonInfo> oldListContanct = groupRemove.GetContactInGroup();
            PersonInfo contactsRemove = oldListContanct[0];

            //TO DO
            //1. Заняться оптимизацией и улучшайзингом/добавлением проверок в методе или тесте
            app.ContactHelper.RemoveContactFromGroup(contactsRemove, groupRemove);

            List<PersonInfo> newListContanct = groupRemove.GetContactInGroup();
            foreach (PersonInfo person in newListContanct)
            {
                if (contactsRemove.Id == person.Id)
                {
                    throw new Exception("Removed contact from group has been failed");
                }
            }
            Assert.AreNotEqual(oldListContanct, newListContanct);

        }

    }
}
