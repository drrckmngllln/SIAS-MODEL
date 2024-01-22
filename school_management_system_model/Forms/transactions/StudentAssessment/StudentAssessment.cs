using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Forms.transactions.StudentAssessment
{
    internal class StudentAssessment : BaseEntity
    {
        public string id_number { get; set; }
        public string school_year { get; set; }
        public string fee_type { get; set; }
        public string amount { get; set; }
        public decimal units { get; set; }
        public decimal computation { get; set; }

        //public List<StudentAssessment> GetAssessments()
        //{
        //    var list = new List<StudentAssessment>();
        //    var con = new MySqlConnection(connection.con());
        //    con.Open();
        //    var cmd = new MySqlCommand("select * from student_assessment join ")
        //}
    }
}
