﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Mapping;

namespace Addressbook
{
    [Table(Name = "address_in_groups")]
    public class GroupRelationContact
    {
        [Column(Name = "group_id")]
        public string GroupId { get; set; }
        
        [Column(Name = "id")]
        public string ContactId { get; set; }

    }
}
