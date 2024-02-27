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
            app.ContactHelper.EditContact(1, newPerson);
            app.Navigator.GoToContactPage();
            app.AuthUser.Logout();
        }
    }
}
