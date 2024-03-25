using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Addressbook;
using System.IO;
namespace addressbook_test_data_generation
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writter = new StreamWriter(args[1]);
            for (int i = 0; i < count; i++)
            {
                writter.WriteLine(String.Format("${0},${1},${2}",
                      TestBase.GenerateRandomString(10),
                      TestBase.GenerateRandomString(10),
                      TestBase.GenerateRandomString(10)));
            }
            writter.Close();
        }
    }
}