using LinqToDB;
using LinqToDB.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook
{
    public class AddressbookDB :LinqToDB.Data.DataConnection
    {
        //static string connectionString = "Server=localhost;Port=3306;Database=addressbook;Uid=root;Pwd=;charset=utf8;";
        //static string providerName = "MySql.Data.MySqlClient";

        //DataContext db = new DataContext(connectionString);


        public AddressbookDB() : base("Addressbook") { }

        public ITable<GroupData> Groups { get { return GetTable<GroupData>(); } }
        public ITable<PersonInfo> Contacts { get { return GetTable<PersonInfo>(); } }
    }
}
