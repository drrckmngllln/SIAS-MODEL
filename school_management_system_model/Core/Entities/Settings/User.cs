using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Core.Entities.Settings
{
    internal class User
    {
        public int id { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string fullname { get; set; }
        public string employee_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string access_level { get; set; }
        public string department { get; set; }
        public int add { get; set; }
        public int edit { get; set; }
        public int delete { get; set; }
        public int administrator { get; set; }
    }
}
