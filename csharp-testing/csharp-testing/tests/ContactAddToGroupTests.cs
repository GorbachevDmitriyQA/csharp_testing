using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LinqToDB.Mapping;
using LinqToDB;

namespace Addressbook
{
    public class ContactAddToGroupTests : ContactTestBase
    {
        [Test]
        public void AddContactToGroup()
        {
            List<GroupData> group = GroupData.GetAllGroups();
            GroupData groupAdd = group[0];
            List<PersonInfo> oldList = groupAdd.GetContactInGroup();
            PersonInfo contact = PersonInfo.GetAllContact().Except(oldList).First();

            //Action
            app.ContactHelper.AddContactToGroup(contact, groupAdd);

            List<PersonInfo> newList = groupAdd.GetContactInGroup();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }

    }
}
