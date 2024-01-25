using MySql.Data.MySqlClient;
using school_management_system_model.Classes.Parameters;
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
        public int id { get; set; }
        public string id_number_id {  get; set; }
        public string course_id {  get; set; }
        public string campus_id { get; set; }
        public string curriculum_id { get; set; }
        public string year_level { get; set; }
        public string section_id { get; set; }
        public string semester { get; set; }

        public List<student_course> GetStudentCourses()
        {
            var list = new List<student_course>();
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("select * from student_course", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var id_number = new StudentAccount().GetStudentAccounts().FirstOrDefault(x => x.id == reader.GetInt32("id_number_id")).id_number;
                var course = new Courses().GetCourses().FirstOrDefault(x => x.id == reader.GetInt32("course_id")).code;
                var campus = new Campuses().GetCampuses().FirstOrDefault(x => x.id == reader.GetInt32("campus_id")).code;
                var curriculum = new Curriculums().GetCurriculums().FirstOrDefault(x => x.id == reader.GetInt32("curriculum_id")).code;
                

                var courses = new student_course
                {
                    id = reader.GetInt32("id"),
                    id_number_id = id_number,
                    course_id = course,
                    campus_id = campus,
                    curriculum_id = curriculum,
                    year_level = reader.GetString("year_level"),
                    section_id = reader.GetString("section_id"),
                    semester = reader.GetString("semester")
                };
                list.Add(courses);
            }
            con.Close();
            return list;
        }

        public void AddStudentCourse()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into student_course(id_number_id, course_id, campus_id, curriculum_id, year_level, section_id, semester) " +
                "values(@1,@2,@3,@4,@5,@6,@7)", con);
            cmd.Parameters.AddWithValue("@1", id_number_id);
            cmd.Parameters.AddWithValue("@2", course_id);
            cmd.Parameters.AddWithValue("@3", campus_id);
            cmd.Parameters.AddWithValue("@4", curriculum_id);
            cmd.Parameters.AddWithValue("@5", year_level);
            cmd.Parameters.AddWithValue("@6", section_id);
            cmd.Parameters.AddWithValue("@7", semester);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //public List<SaveStudentAccountsParams> GetStudentIDNumber()
        //{
        //    var list = new List<SaveStudentAccountsParams>();
        //    var con = new MySqlConnection(connection.con());
        //    con.Open();
        //    var cmd = new MySqlCommand("select * from student_accounts", con);
        //    var reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        var student = new SaveStudentAccountsParams
        //        {
        //            id = reader.GetInt32("id"),
        //            id_number = reader["id_number"].ToString()
        //        };
        //        list.Add(student);
        //    }
        //    con.Close();
        //    return list;
        //}
        
    }
}
