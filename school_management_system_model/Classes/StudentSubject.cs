using MySql.Data.MySqlClient;
using school_management_system_model.Reports.Datasets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class StudentSubject
    {
        public int id { get; set; }
        public string id_number_id { get; set; }
        public string unique_id { get; set; }
        public string school_year_id { get; set; }
        public string subject_code { get; set; }
        public string descriptive_title { get; set; }
        public string pre_requisite { get; set; }
        public string total_units { get; set; }
        public string lecture_units { get; set; }
        public string lab_units { get; set; }
        public string time { get; set; }
        public string day { get; set; }
        public string room { get; set; }
        public string instructor_id { get; set; }
        public string grade { get; set; }
        public string remarks { get; set; }

        public List<StudentSubject> GetStudentSubjects()
        {
            var list = new List<StudentSubject>();
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("select * from student_subjects", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var id_number = new StudentAccount().GetStudentAccounts().FirstOrDefault(x => x.id == reader.GetInt32("id_number_id"));
                var school_year = new SchoolYear().GetSchoolYears().FirstOrDefault(x => x.id == reader.GetInt32("school_year_id"));
                var instructor = new Instructors().GetInstructors().FirstOrDefault(x => x.id == reader.GetInt32("instructor_id"));
                var studentSubjects = new StudentSubject
                {
                    id = reader.GetInt32("id"),
                    id_number_id = id_number.id_number,
                    unique_id = reader.GetString("unique_id"),
                    school_year_id = school_year.code,
                    subject_code = reader.GetString("subject_code"),
                    descriptive_title = reader.GetString("descriptive_title"),
                    pre_requisite = reader.GetString("pre_requisite"),
                    total_units = reader.GetString("total_units"),
                    lecture_units = reader.GetString("lecture_units"),
                    lab_units = reader.GetString("lab_units"),
                    time = reader.GetString("time"),
                    day = reader.GetString("day"),
                    room = reader.GetString("room"),
                    instructor_id = instructor.fullname,
                    grade = reader.GetString("grade"),
                    remarks = reader.GetString("remarks")
                };
                list.Add(studentSubjects);
            }
            con.Close();
            return list;
        }

        public void SaveSectionSubjects()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into student_subjects(id_number_id, unique_id, school_year_id, subject_code, descriptive_title, " +
                "pre_requisite, total_units, lecture_units, lab_units, time, day, room, instructor_id) " +
                "values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13)", con);
            cmd.Parameters.AddWithValue("@1", id_number_id);
            cmd.Parameters.AddWithValue("@2", unique_id);
            cmd.Parameters.AddWithValue("@3", school_year_id);
            cmd.Parameters.AddWithValue("@4", subject_code);
            cmd.Parameters.AddWithValue("@5", descriptive_title);
            cmd.Parameters.AddWithValue("@6", pre_requisite);
            cmd.Parameters.AddWithValue("@7", total_units);
            cmd.Parameters.AddWithValue("@8", lecture_units);
            cmd.Parameters.AddWithValue("@9", lab_units);
            cmd.Parameters.AddWithValue("@10", time);
            cmd.Parameters.AddWithValue("@11", day);
            cmd.Parameters.AddWithValue("@12", room);
            cmd.Parameters.AddWithValue("@13", instructor_id);
           
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
