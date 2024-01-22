using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Forms.transactions.StudentAssessment
{
    internal class StudentAssessment
    {
        public int id { get; set; }
        public string id_number { get; set; }
        public string school_year { get; set; }
        public string fee_type { get; set; }
        public decimal amount { get; set; }
        public decimal units { get; set; }
        public decimal computation { get; set; }

        public List<StudentAssessment> GetStudentAssessments()
        {
            var list = new List<StudentAssessment>();
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("select * from student_assessment", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var student = new StudentAssessment
                {
                    id = reader.GetInt32("id"),
                    id_number = reader["id_number"].ToString(),
                    school_year = reader["school_year"].ToString(),
                    fee_type = reader["fee_type"].ToString(),
                    amount = reader.GetDecimal("amount"),
                    units = reader.GetDecimal("units"),
                    computation = reader.GetDecimal("computation")
                };
                list.Add(student);
            }
            return list;
        }
    }
}
