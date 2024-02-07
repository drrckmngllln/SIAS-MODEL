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

        public List<StudentCourses> GetStudentCourses()
        {
            var list = new List<StudentCourses>();
            using (var con = new MySqlConnection(connection.con()))
            {
                con.Open();
                var sql = "select * from student_course";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //var studentCourses = new StudentCourses
                            //{
                            //    id = reader.GetInt32("id"),
                            //    id_number = reader.GetString("id"),
                            //    course = reader.GetString("course_id"),
                            //    campus = reader.GetString("campus_id"),
                            //    curriculum = reader.GetString("curriculum_id"),
                            //    year_level = reader.GetString("year_level"),
                            //    section = reader.GetString("section_id"),
                            //    semester = reader.GetString("semester")
                            //};
                            //list.Add(studentCourses);
                            var id_number_id = reader.GetString("id") == null
                                ? "No ID Number"
                                : new StudentAccount().GetStudentAccounts()
                                .FirstOrDefault(x => x.id == reader.GetInt32("id_number_id"))
                                .id_number;
                            var course_id = reader.GetString("course_id") == null
                                ? "No Course"
                                : new Courses().GetCourses()
                                .FirstOrDefault(x => x.id == reader.GetInt32("course_id"))
                                .code;
                            var campus_id = reader.GetString("campus_id") == null
                                ? "No Campus"
                                : new Campuses().GetCampuses()
                                .FirstOrDefault(x => x.id == reader.GetInt32("campus_id"))
                                .code;
                            var curriculum_id = reader.GetString("curriculum_id") == null
                                ? "No Curriculum"
                                : new Curriculums().GetCurriculums()
                                .FirstOrDefault(x => x.id == reader.GetInt32("curriculum_id"))
                                .code;
                            var section_id = reader.GetString("section_id") == "Not Set"
                                ? "Not Set"
                                : new sections().GetSections()
                                .FirstOrDefault(x => x.id == reader.GetInt32("section_id"))
                                .section_code;

                            var studentCourses = new StudentCourses
                            {
                                id = reader.GetInt32("id"),
                                id_number = id_number_id,
                                course = course_id,
                                campus = campus_id,
                                curriculum = curriculum_id,
                                year_level = reader.GetString("year_level"),
                                section = section_id,
                                semester = reader.GetString("semester")
                            };
                            list.Add(studentCourses);
                        }
                    }
                }
                con.Close();
                return list;
            }
        }

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
