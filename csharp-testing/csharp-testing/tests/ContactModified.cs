
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook
{
    [TestFixture]
    public class ContactModified : ContactTestBase
    {
        public static IEnumerable<PersonInfo> PersonEditDataFromCsvFile()
        {
            List<PersonInfo> persons = new List<PersonInfo>();
            string[] lines = File.ReadAllLines(@"editContacts.csv");
            foreach (string line in lines)
            {
                string[] parts = line.Split(",");
                persons.Add(new PersonInfo()
                {
                    LastName = parts[0],
                    FirstName = parts[1],
                    Address = parts[2],
                    HomePhone = parts[3],
                    WorkPhone = parts[4],
                    MobilePhone = parts[5],
                    Email = parts[6]
                });
            }
            return persons;
        }


        [Test, TestCaseSource(nameof(PersonEditDataFromCsvFile))]
        public void EditContacts(PersonInfo person)
        {
            app.Navigator.GoToContactPage();
            app.ContactHelper.VerificationContanct(new PersonInfo());
            List<PersonInfo> oldContact = PersonInfo.GetAllContact();
            PersonInfo toBeEdit = oldContact[0];
            if (toBeEdit.FirstName == "Ksenya")
            {
                person.FirstName = GenerateRandomString(10);
                person.LastName = GenerateRandomString(10);
                person.HomePhone = GenerateRandomString(10);
                person.WorkPhone = GenerateRandomString(10);
                person.MobilePhone = GenerateRandomString(10);
                person.Email = GenerateRandomString(10);
                person.Address = GenerateRandomString(10);
            }
            app.ContactHelper.EditContact(toBeEdit, person);
            app.Navigator.GoToContactPage();
            List<PersonInfo> newContact = PersonInfo.GetAllContact();

            foreach(PersonInfo persons in newContact)
            {
                if (persons.Id == toBeEdit.Id)
                {
                    Assert.AreNotEqual(person.FirstName, toBeEdit.FirstName);
                }
            }
            Assert.AreNotEqual(oldContact, newContact);
        }
    }
}
