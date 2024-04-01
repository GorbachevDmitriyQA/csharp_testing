﻿// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Xml.Serialization;
using Newtonsoft.Json;
using LinqToDB;

namespace Addressbook
{

    [TestFixture]
    public class CreateGroupTest : GroupTestBase
    {
        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string line in lines)
            {
                string[] parts = line.Split(",");
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });

            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.xml"));
            
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"groups.json"));
        }


        [Test, TestCaseSource(nameof(GroupDataFromCsvFile))]

        public void GroupTest(GroupData data)
        {

            List <GroupData> oldGroup = GroupData.GetAllGroups();

            //Подебажить посмотреть на логику сортировки 
            app.GroupHelper.Create(data);

            //Используем быструю проверку по кол-ву групп. Если совпадает с ожидаемым тогда имеет смысл идти дальше
            Assert.AreEqual(oldGroup.Count + 1, app.GroupHelper.GetConuntGroup());

            List<GroupData> newGroup = GroupData.GetAllGroups();
            oldGroup.Add(data);
            oldGroup.Sort();
            newGroup.Sort();
            Assert.AreEqual(oldGroup, newGroup);
        }

        [Test]
        public void TestDbConnection()
        {
            foreach (PersonInfo person in GroupData.GetAllGroups()[1].GetContactInGroup())
            {
                System.Console.Out.WriteLine(person);
            };
        }
    }
}