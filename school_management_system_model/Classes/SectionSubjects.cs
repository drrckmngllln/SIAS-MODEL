using Microsoft.Reporting.Map.WebForms.BingMaps;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class SectionSubjects
    {
        public int id { get; set; }
        public string unique_id { get; set; }
        public string section_code_id { get; set; }
        public string curriculum_id { get; set; }
        public string course_id { get; set; }
        public string year_level { get; set; }
        public string semester { get; set; }
        public string subject_code { get; set; }
        public string descriptive_title { get; set; }
        public string total_units { get; set; }
        public string lecture_units { get; set; }
        public string lab_units { get; set; }
        public string pre_requisite { get; set; }
        public string time { get; set; }
        public string day { get; set; }
        public string room { get; set; }
        public string instructor_id { get; set; }
        public string status { get; set; }

        public List<SectionSubjects> GetSectionSubjects()
        {
            var list = new List<SectionSubjects>();
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("select * from section_subjects", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var curriculum = new Curriculums().GetCurriculums().FirstOrDefault(x => x.id == reader.GetInt32("curriculum_id"));
                var section = new sections().GetSections().FirstOrDefault(x => x.id == reader.GetInt32("section_code_id"));
                var course = new Courses().GetCourses().FirstOrDefault(x => x.id == reader.GetInt32("course_id"));
                var instructor = new Instructors().GetInstructors().FirstOrDefault(x => x.id == reader.GetInt32("instructor_id"));
                
                var sectionSubjects = new SectionSubjects
                {
                    id = reader.GetInt32("id"),
                    unique_id = reader.GetString("unique_id"),
                    section_code_id = section.section_code,
                    curriculum_id = curriculum.code,
                    course_id = course.code,
                    year_level = reader.GetString("year_level"),
                    semester = reader.GetString("semester"),
                    subject_code = reader.GetString("subject_code"),
                    descriptive_title = reader.GetString("descriptive_title"),
                    total_units = reader.GetString("total_units"),
                    lecture_units = reader.GetString("lecture_units"),
                    lab_units = reader.GetString("lab_units"),
                    pre_requisite = reader.GetString("pre_requisite"),
                    time = reader.GetString("time"),
                    day = reader.GetString("day"),
                    room = reader.GetString("room"),
                    instructor_id = instructor.fullname,
                    status = reader.GetString("status"),
                };
                list.Add(sectionSubjects);
            }
            con.Close();
            return list;
        }

        public void AddSectionSubjects()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into section_subjects(unique_id, section_code_id, curriculum_id, course_id, year_level, semester, subject_code, " +
                "descriptive_title, total_units, lecture_units, lab_units, pre_requisite, time, day, room, instructor_id, status) " +
                "values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17)", con);
            cmd.Parameters.AddWithValue("@1", unique_id);
            cmd.Parameters.AddWithValue("@2", section_code_id);
            cmd.Parameters.AddWithValue("@3", curriculum_id);
            cmd.Parameters.AddWithValue("@4", course_id);
            cmd.Parameters.AddWithValue("@5", year_level);
            cmd.Parameters.AddWithValue("@6", semester);
            cmd.Parameters.AddWithValue("@7", subject_code);
            cmd.Parameters.AddWithValue("@8", descriptive_title);
            cmd.Parameters.AddWithValue("@9", total_units);
            cmd.Parameters.AddWithValue("@10", lecture_units);
            cmd.Parameters.AddWithValue("@11", lab_units);
            cmd.Parameters.AddWithValue("@12", pre_requisite);
            cmd.Parameters.AddWithValue("@13", "Not Set");
            cmd.Parameters.AddWithValue("@14", "Not Set");
            cmd.Parameters.AddWithValue("@15", "Not Set");
            cmd.Parameters.AddWithValue("@16", instructor_id);
            cmd.Parameters.AddWithValue("@17", "Active");

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateSectionSubjects(int id)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update section_subjects set time=@1, day=@2, room=@3, instructor_id=@4 where id='" + id + "'", con);
            cmd.Parameters.AddWithValue("@1", time);
            cmd.Parameters.AddWithValue("@2", day);
            cmd.Parameters.AddWithValue("@3", room);
            cmd.Parameters.AddWithValue("@4", instructor_id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteSectionSubjects(int id)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("delete from section_subjects where id='" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteAllSectionSubjects(int section_code_id)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("delete from section_subjects where section_code_id='" + section_code_id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
