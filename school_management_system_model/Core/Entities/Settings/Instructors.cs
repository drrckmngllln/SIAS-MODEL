using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Core.Entities
{
    internal class Instructors
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string department_id { get; set; }
        public string position { get; set; }
    }
}
