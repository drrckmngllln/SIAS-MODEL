using MySql.Data.MySqlClient;
using school_management_system_model.Classes.Parameters;
using System.Collections.Generic;

namespace school_management_system_model.Classes
{
    internal class CurriculumSubjects
    {
        public int id { get; set; }
        public string uid { get; set; }
        public string curriculum_id { get; set; }
        public string year_level { get; set; }
        public string semester { get; set; }
        public string code { get; set; }
        public string descriptive_title { get; set; }
        public string total_units { get; set; }
        public string lecture_units { get; set; }
        public string lab_units { get; set; }
        public string pre_requisite { get; set; }
        public string total_hrs_per_week { get; set; }

        public List<CurriculumSubjects> GetCurriculumSubjects()
        {
            var list = new List<CurriculumSubjects>();
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("select * from curriculum_subjects", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var curriculumSubject = new CurriculumSubjects
                {
                    id = reader.GetInt32("id"),
                    uid = reader.GetString("uid"),
                    curriculum_id = reader.GetString("curriculum_id"),
                    year_level = reader.GetString("year_level"),
                    semester = reader.GetString("semester"),
                    code = reader.GetString("code"),
                    descriptive_title = reader.GetString("descriptive_title"),
                    total_units = reader.GetString("total_units"),
                    lecture_units = reader.GetString("lecture_units"),
                    lab_units = reader.GetString("lab_units"),
                    pre_requisite = reader.GetString("pre_requisite"),
                    total_hrs_per_week = reader.GetString("total_hrs_per_week")
                };
                list.Add(curriculumSubject);
            }
            con.Close();
            return list;
        }

        public void AddCurriculumSubjects(CurriculumSubjects subjects)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into curriculum_subjects(uid, curriculum_id, year_level, semester, code, descriptive_title, total_units, lecture_units, lab_units, " +
                "pre_requisite, total_hrs_per_week) values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11)", con);
            cmd.Parameters.AddWithValue("@1", subjects.uid);
            cmd.Parameters.AddWithValue("@2", subjects.curriculum_id);
            cmd.Parameters.AddWithValue("@3", subjects.year_level);
            cmd.Parameters.AddWithValue("@4", subjects.semester);
            cmd.Parameters.AddWithValue("@5", subjects.code);
            cmd.Parameters.AddWithValue("@6", subjects.descriptive_title);
            cmd.Parameters.AddWithValue("@7", subjects.total_units);
            cmd.Parameters.AddWithValue("@8", subjects.lecture_units);
            cmd.Parameters.AddWithValue("@9", subjects.lab_units);
            cmd.Parameters.AddWithValue("@10", subjects.pre_requisite);
            cmd.Parameters.AddWithValue("@11", subjects.total_hrs_per_week);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateCurriculumSubjects(CurriculumSubjects subjects)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update curriculum_subjects set uid=@1, year_level=@3, semester=@4, code=@5, descriptive_title=@6, " +
                "total_units=@7, lecture_units=@8, lab_units=@9, pre_requisite=@10, total_hrs_per_week=@11 where id='" + subjects.id + "'", con);
            cmd.Parameters.AddWithValue("@1", subjects.uid);
            cmd.Parameters.AddWithValue("@2", subjects.curriculum_id);
            cmd.Parameters.AddWithValue("@3", subjects.year_level);
            cmd.Parameters.AddWithValue("@4", subjects.semester);
            cmd.Parameters.AddWithValue("@5", subjects.code);
            cmd.Parameters.AddWithValue("@6", subjects.descriptive_title);
            cmd.Parameters.AddWithValue("@7", subjects.total_units);
            cmd.Parameters.AddWithValue("@8", subjects.lecture_units);
            cmd.Parameters.AddWithValue("@9", subjects.lab_units);
            cmd.Parameters.AddWithValue("@10", subjects.pre_requisite);
            cmd.Parameters.AddWithValue("@11", subjects.total_hrs_per_week);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteCurriculumSubjects(int curriculum_id)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                con.Open();
                var cmd = new MySqlCommand("delete from curriculum_subjects where curriculum_id='" + curriculum_id + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
