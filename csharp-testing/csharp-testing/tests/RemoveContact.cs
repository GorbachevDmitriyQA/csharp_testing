using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook
{
    [TestFixture]
    public class RemoveContacts : TestBase
    {
        [Test]
        
        public void RemoveContact()
        {
            app.Navigator.GoToContactPage();
            app.ContactHelper.DeleteContact(1);
            app.LogoutHelper.LogOut();
        }

    }
}
