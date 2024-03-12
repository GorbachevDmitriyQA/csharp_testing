﻿// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace Addressbook
{

    [TestFixture]
    public class ContactTest : TestBaseAuth
    { 
        [Test]
        public void Contact()
        {
            PersonInfo personInfo = new PersonInfo("TestName");
            personInfo.Address = "TestName";
            personInfo.LastName = "Dimansky";
            personInfo.Email = "nownownow@mail.ru";
            app.Navigator.GoToContactPage();
            List<PersonInfo> oldContact = app.ContactHelper.GetContactList();
            app.Navigator.GoToNewContactPage();
            app.ContactHelper.Create(personInfo);
            List<PersonInfo> newContact = app.ContactHelper.GetContactList();
            Assert.AreEqual(oldContact.Count + 1, newContact.Count);
            app.AuthUser.Logout();

        }
    }
}
