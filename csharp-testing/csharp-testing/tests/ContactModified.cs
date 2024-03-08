using AccountTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook
{
    [TestFixture]
    public class ContactModified : TestBaseAuth
    {
        [Test]
        public void EditContacts()
        {
            PersonInfo newPerson = new PersonInfo("Stiven");
            newPerson.Email = "email.ru";
            newPerson.Address = "Zoton";
            newPerson.LastName = "Pupel";
            app.Navigator.GoToContactPage();
            app.ContactHelper.VerificationContanct(new PersonInfo());
            List<PersonInfo> oldContact = app.ContactHelper.GetContactList();
            if (oldContact[0].FirstName == "Stiven")
            {
                newPerson.FirstName = "Chadd";
            }
            app.ContactHelper.EditContact(0, newPerson);
            app.Navigator.GoToContactPage();
            List<PersonInfo> newContact = app.ContactHelper.GetContactList();
            Assert.AreNotEqual(oldContact, newContact);
            app.AuthUser.Logout();
        }
    }
}
