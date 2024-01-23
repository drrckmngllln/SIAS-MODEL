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

        public List<student_course> GetStudentCourses()
        {
            var list = new List<student_course>();
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("select * from student_course", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var id_number = GetStudentIDNumber().FirstOrDefault(x => x.id == reader.GetInt32("id_number")).id_number;
                var course = new Courses().GetCourses().FirstOrDefault(x => x.id == reader.GetInt32("course_id")).code;
                var campus = new Campuses().GetCampuses().FirstOrDefault(x => x.id == reader.GetInt32("campus_id")).code;
                var curriculum = new Curriculums().GetCurriculums().FirstOrDefault(x => x.id == reader.GetInt32("curriculum_id")).code;
                var section = new sections().GetSections().FirstOrDefault(x => x.id == reader.GetInt32("section_id")).section_code;

                var courses = new student_course
                {
                    id = reader.GetInt32("id"),
                    id_number_id = id_number,
                    course_id = course,
                    campus_id = campus,
                    curriculum_id = curriculum,
                    year_level = reader.GetString("year_level"),
                    section_id = reader.GetString("section_id")
                };
                list.Add(courses);
            }
            con.Close();
            return list;
        }
        public List<SaveStudentAccountsParams> GetStudentIDNumber()
        {
            var list = new List<SaveStudentAccountsParams>();
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("select * from student_accounts");
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var student = new SaveStudentAccountsParams
                {
                    id = reader.GetInt32("id"),
                    id_number = reader["id_number"].ToString()
                };
                list.Add(student);
            }
            con.Close();
            return list;
        }
        
    }
}
