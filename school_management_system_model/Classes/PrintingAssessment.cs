using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class PrintingAssessment
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string school_year { get; set; }

        public string course { get; set; }
        public string campus { get; set; }
        public string curriculum { get; set; }
        public string year_level { get; set; }
        public string section { get; set; }
        public string semester { get; set; }

        public void loadStudentAccounts(string idNumber)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_accounts where id_number='" + idNumber + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            
        }
    }
}
