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

        public void AddStudentCourse()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into student_course(id_number_id, course_id, campus_id, curriculum_id, year_level, section_id, semester) " +
                "values(@1,@2,@3,@4,@5,@6,@7)", con);
            cmd.Parameters.AddWithValue("@1", id_number);
            cmd.Parameters.AddWithValue("@2", course);
            cmd.Parameters.AddWithValue("@3", campus);
            cmd.Parameters.AddWithValue("@4", curriculum);
            cmd.Parameters.AddWithValue("@5", year_level);
            cmd.Parameters.AddWithValue("@6", section);
            cmd.Parameters.AddWithValue("@7", semester);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateStudentCourse(int id)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                con.Open();
                var sql = "update student_course set id_number_id=@1, course_id=@2, campus_id=@3, curriculum_id=@4, year_level=@5, section_id=@6, semester=@7 " +
                    "where id='" + id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@1", id_number);
                    cmd.Parameters.AddWithValue("@2", course);
                    cmd.Parameters.AddWithValue("@3", campus);
                    cmd.Parameters.AddWithValue("@4", curriculum);
                    cmd.Parameters.AddWithValue("@5", year_level);
                    cmd.Parameters.AddWithValue("@6", section);
                    cmd.Parameters.AddWithValue("@7", semester);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void EnrolStudent(int id, string year_level, string section_id)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                con.Open();
                var sql = "update student_course set year_level=@1, section_id=@2 where id='" + id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@1", year_level);
                    cmd.Parameters.AddWithValue("@2", section_id);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}
