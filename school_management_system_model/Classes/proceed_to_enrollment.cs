using MySql.Data.MySqlClient;
using school_management_system_model.Forms.transactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Classes
{
    internal class proceed_to_enrollment
    {
        public int id { get; set; }
        public string id_number {  get; set; }
        public string course {  get; set; }
        public string curriculum { get; set; }
        public string campus { get; set; }
        public string year_level { get; set; }
        public string section { get; set; }
        public string semester { get; set; }
        public string section_code { get; set; }
        public int grade { get; set; }  
        public string number_of_students {  get; set; }

        public DataTable loadStudentIdAndCourse()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_course where id_number='" + id_number + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public string getCampus()
        {
            var con = new MySqlConnection (connection.con());
            var da = new MySqlDataAdapter("select * from courses where code='" + course + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0]["campus"].ToString();
        }

        public DataTable loadCourses()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from courses", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable loadSection(string course, string semester, string year_level)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from sections where course='"+ course +"' and semester='"+ semester +"' and year_level='"+year_level+"' and status='Available'" , con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable loadCurriculum()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from curriculums where course='" + course + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable loadSubjects(string sectionCode, string semester)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from section_subjects where section_code='"+ sectionCode +"' and semester='"+semester+"'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void saveStudentCourse()
        {
            // student course
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update student_course set id_number=@1, course=@2, curriculum=@3, year_level=@4, section=@5, " +
                "semester=@6, campus=@7 where id_number='" + id_number + "'", con);
            cmd.Parameters.AddWithValue("@1", id_number);
            cmd.Parameters.AddWithValue("@2", course);
            cmd.Parameters.AddWithValue("@3", curriculum);
            cmd.Parameters.AddWithValue("@4", year_level);
            cmd.Parameters.AddWithValue("@5", section);
            cmd.Parameters.AddWithValue("@6", semester);
            cmd.Parameters.AddWithValue("@7", campus);
            cmd.ExecuteNonQuery();
            con.Close();
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Enrollment Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public DataTable addCustomSubject()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from section_subjects where id='" + id + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
