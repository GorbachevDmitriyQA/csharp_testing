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
using AccountTest;

namespace Addressbook
{

    [TestFixture]
    public class ContactTest : TestBase
    { 
        [Test]
        public void contact()
        {
            OpenToHomePage();
            CustomizeWindow();
            Login(new AccountData("admin", "secret"));
            PersonInfo personInfo = new PersonInfo("Diman");
            personInfo.Address = "Limbo";
            personInfo.LastName = "Dimansky";
            personInfo.Email = "nownownow@mail.ru";
            CreateNewAccount(personInfo);
            LogOut();

        }
    }
}
