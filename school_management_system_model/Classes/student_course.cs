using MySql.Data.MySqlClient;
using school_management_system_model.Forms.transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class student_course
    {
        public string id_number {  get; set; }
        public string course {  get; set; }
        public string curriculum { get; set; }
        public string year_level { get; set; }
        public string section { get; set; }

        public void loadRecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_course where id_number='" + id_number + "'", con);
            da.Fill(frm_student_enrollment.instance.dt);
        }
    }
}
