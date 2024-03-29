
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook
{
    [TestFixture]
    public class RemoveContacts : ContactTestBase
    {
        [Test]
        
        public void RemoveContact()
        {
            app.Navigator.GoToContactPage();
            app.ContactHelper.VerificationContanct(new PersonInfo());
            List<PersonInfo> oldContact = PersonInfo.GetAllContact();
            PersonInfo toBeRemoved = oldContact[0];
            app.ContactHelper.DeleteContact(toBeRemoved);
            List<PersonInfo> newContact = PersonInfo.GetAllContact();
            oldContact.RemoveAt(0);
            Assert.AreEqual(oldContact, newContact);
        }

    }
}
