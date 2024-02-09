using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Core.Entities
{
    internal class LabFeeSubjects
    {
        public int id { get; set; }
        public string lab_fee { get; set; }
        public string subject_code { get; set; }
        public string descriptive_title { get; set; }
    }
}
