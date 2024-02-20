﻿using AccountTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook
{
    [TestFixture]
    public class ContactModified : TestBase
    {
        [Test]
        public void EditContacts()
        {
            PersonInfo newPerson = new PersonInfo("Stiven");
            newPerson.Email = "email.ru";
            newPerson.Address = null;
            newPerson.LastName = null;
            app.Navigator.GoToContactPage();
            app.ContactHelper.EditContact(3, newPerson);
            app.Navigator.GoToContactPage();
            app.LogoutHelper.LogOut();
        }
    }
}
