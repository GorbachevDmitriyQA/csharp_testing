
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook
{
    [TestFixture]
    public class RemoveContacts : TestBaseAuth
    {
        [Test]
        
        public void RemoveContact()
        {
            app.Navigator.GoToContactPage();
            app.ContactHelper.VerificationContanct(new PersonInfo());
            List<PersonInfo> oldContact = app.ContactHelper.GetContactList();
            app.ContactHelper.DeleteContact(0);
            List<PersonInfo> newContact = app.ContactHelper.GetContactList();
            oldContact.RemoveAt(0);
            Assert.AreEqual(oldContact, newContact);
            app.AuthUser.Logout();
        }

    }
}
