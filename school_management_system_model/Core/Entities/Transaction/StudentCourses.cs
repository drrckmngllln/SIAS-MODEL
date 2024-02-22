using MySql.Data.MySqlClient;
using school_management_system_model.Classes.Parameters;
using school_management_system_model.Data.Repositories.Setings.Section;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using school_management_system_model.Forms.transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Core.Entities
{
    internal class StudentCourses
    {
        public int id { get; set; }
        public string id_number { get; set; }
        public string course { get; set; }
        public string campus { get; set; }
        public string curriculum { get; set; }
        public string year_level { get; set; }
        public string section { get; set; }
        public string semester { get; set; }

        
    }
}
