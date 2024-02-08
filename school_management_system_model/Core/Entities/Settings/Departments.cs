using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Core.Entities
{
    internal class Departments
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string campus { get; set; }
    }
}
