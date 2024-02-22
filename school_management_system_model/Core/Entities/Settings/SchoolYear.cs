using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Core.Entities
{
    internal class SchoolYear
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string school_year_from { get; set; }
        public string school_year_to { get; set; }
        public string semester { get; set; }
        public string is_current { get; set; }

        
    }
}
