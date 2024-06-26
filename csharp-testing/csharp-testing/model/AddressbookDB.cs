﻿using Addressbook;
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

        public AddressbookDB() : base("MySql.Data.MySqlClient",
            "Server=127.0.0.1;Port=3306;Database=addressbook;Uid=root;Pwd=;charset=utf8;Allow Zero Datetime=true") { }

        public ITable<GroupData> Groups { get { return GetTable<GroupData>(); } }
        public ITable<PersonInfo> Contacts { get { return GetTable<PersonInfo>(); } }

        public ITable<GroupRelationContact> GCR { get { return GetTable<GroupRelationContact>(); } }
    }
}


