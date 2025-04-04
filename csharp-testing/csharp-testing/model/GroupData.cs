using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        [Column(Name = "group_name")]
        public string Name { get; set; } = "default";
        [Column(Name = "group_header")]
        public string Header { get; set; } = "default";
        [Column(Name = "group_footer")]
        public string Footer { get; set; } = "default";
        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }
        /// <summary>
        /// qwewqe
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>

        public int CompareTo(GroupData other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }
        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
            Console.WriteLine("aaaaaCCCCCC");
        }


        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public GroupData()
        {

        }
        public GroupData(string name)
        {
            Name = name;
        }
        public GroupData(string name, string header, string footer)
        {
            Name = name;
            Header = header;
            Footer = footer;
        }

        /// <summary>
        /// Запрос из БД вынесен в отдельный метод для удобства
        /// Запрос вынесен в конструкцию using для удобства завершения работы с процессом.
        /// Процесс (db.Close()) завершается автоматически
        /// </summary>
        /// <returns></returns>
        public static List<GroupData> GetAllGroups()
        {

            using (AddressbookDB db = new AddressbookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }

        public List<PersonInfo> GetContactInGroup()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                // Альтеранативный вариант запроса

                //return (from c in db.Contacts
                //        from grc in db.GCR.Where(p => p.GroupId == Id
                //        && p.ContactId == c.Id)
                //        select c).Distinct().ToList();

                return (from c in db.Contacts
                        where c.Deprecated == "0000-00-00 00:00:00"
                        from gcr in db.GCR
                        where gcr.GroupId == Id
                        && gcr.ContactId == c.Id
                        select c).Distinct().ToList();
            }
        }

    }
}
