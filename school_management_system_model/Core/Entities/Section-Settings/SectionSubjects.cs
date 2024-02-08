using Microsoft.Reporting.Map.WebForms.BingMaps;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Core.Entities
{
    internal class SectionSubjects
    {
        public int id { get; set; }
        public string unique_id { get; set; }
        public string section_code { get; set; }
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
        public string instructor { get; set; }

        //public async Task<List<SectionSubjects>> GetSectionSubjects()
        //{
        //    var list = new List<SectionSubjects>();
        //    var con = new MySqlConnection(connection.con());
        //    await con.OpenAsync();
        //    var cmd = new MySqlCommand("select * from section_subjects", con);
        //    var reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        //var curriculum = new Curriculums().GetCurriculums().FirstOrDefault(x => x.id == reader.GetInt32("curriculum_id"));
        //        var section = new sections().GetSections().FirstOrDefault(x => x.id == reader.GetInt32("section_code_id"));
        //        //var course = new Courses().GetCourses().FirstOrDefault(x => x.id == reader.GetInt32("course_id"));
        //        //var instructor = new Instructors().GetInstructors().FirstOrDefault(x => x.id == reader.GetInt32("instructor_id"));

        //        var sectionSubjects = new SectionSubjects
        //        {
        //            id = reader.GetInt32("id"),
        //            unique_id = reader.GetString("unique_id"),
        //            section_code_id = section.section_code,
        //            //curriculum_id = curriculum.code,
        //            //course_id = course.code,
        //            year_level = reader.GetString("year_level"),
        //            semester = reader.GetString("semester"),
        //            subject_code = reader.GetString("subject_code"),
        //            descriptive_title = reader.GetString("descriptive_title"),
        //            total_units = reader.GetString("total_units"),
        //            lecture_units = reader.GetString("lecture_units"),
        //            lab_units = reader.GetString("lab_units"),
        //            pre_requisite = reader.GetString("pre_requisite"),
        //            time = reader.GetString("time"),
        //            day = reader.GetString("day"),
        //            room = reader.GetString("room"),
        //            instructor_id = reader.GetString("instructor_id"), //instructor.fullname,
        //            status = reader.GetString("status"),
        //        };
        //        list.Add(sectionSubjects);
        //        //if (curriculum != null && section != null && course != null && instructor != null)
        //        //{

        //        //}


        //    }
        //    await con.CloseAsync();
        //    return list;
        //}

        public void AddSectionSubjects()
        {
            
        }

        public void UpdateSectionSubjects(int id)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update section_subjects set time=@1, day=@2, room=@3, instructor_id=@4 where id='" + id + "'", con);
            cmd.Parameters.AddWithValue("@1", time);
            cmd.Parameters.AddWithValue("@2", day);
            cmd.Parameters.AddWithValue("@3", room);
            cmd.Parameters.AddWithValue("@4", instructor);
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
