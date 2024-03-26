using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Addressbook;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
namespace addressbook_test_data_generation
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[3];
            string typeData = args[0];
            List<PersonInfo> persons = new List<PersonInfo>();  
            List<GroupData> groups = new List<GroupData>();
            switch (typeData)
            {
                case "groups":
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }
                if (format == "csv")
                {
                    WriteGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    WriteGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    WriteGroupsToJsonFile(groups, writer);
                }
                else
                {
                    Console.WriteLine("undifiend file format" + format);
                }
                break;
                case "persons":
                for (int i = 0; i < count; i++)
                {
                persons.Add(new PersonInfo()
                {
                LastName = TestBase.GenerateRandomString(10),
                FirstName = TestBase.GenerateRandomString(10),
                Address = TestBase.GenerateRandomString(10),
                HomePhone = TestBase.GenerateRandomString(10),
                WorkPhone = TestBase.GenerateRandomString(10),
                MobilePhone = TestBase.GenerateRandomString(10),
                Email = TestBase.GenerateRandomString(10),
                });
                }
                if (format == "csv")
                {
                    WritePersonToCsvFile(persons, writer);
                }
                else if (format == "xml")
                {
                    WritePersonToXmlFile(persons, writer);
                }
                else if (format == "json")
                {
                    WritePersonToJsonFile(persons, writer);
                }
                else
                {
                    Console.WriteLine("undifiend file format" + format);
                }
                break;
            }
            writer.Close();
        }
        static void WritePersonToJsonFile(List<PersonInfo> persons, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(persons, Newtonsoft.Json.Formatting.Indented));
        }

        static void WritePersonToXmlFile(List<PersonInfo> persons, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<PersonInfo>)).Serialize(writer, persons);
        }

        static void WritePersonToCsvFile(List<PersonInfo> persons, StreamWriter writer)
        {
            foreach (PersonInfo person in persons)
            {
                writer.WriteLine(String.Format("${0},${1},${2},${3},${4},${5},${6}",
                    person.FirstName, person.LastName, person.Address, person.HomePhone,
                    person.WorkPhone, person.MobilePhone, person.Email));
            }
        }

        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
    }

}