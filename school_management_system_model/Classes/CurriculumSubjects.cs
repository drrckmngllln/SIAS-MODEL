using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class CurriculumSubjects
    {
        public int id { get; set; }
        public string uid { get; set; }
        public int curriculum_id { get; set; }
        public int year_level { get; set; }
        public int semester { get; set; }
        public string code { get; set; }
        public string descriptive_title { get; set; }
        public decimal total_units { get; set; }
        public decimal lecture_units { get; set; }
        public decimal lab_units { get; set; }
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
                    curriculum_id = reader.GetInt32("curriculum_id"),
                    year_level = reader.GetInt32("year_level"),
                    semester = reader.GetInt32("semester"),
                    code = reader.GetString("code"),
                    descriptive_title = reader.GetString("descriptive_title"),
                    total_units = reader.GetDecimal("total_units"),
                    lecture_units = reader.GetDecimal("lecture_units"),
                    lab_units = reader.GetDecimal("lab_units"),
                    pre_requisite = reader.GetString("pre+requisite"),
                    total_hrs_per_week = reader.GetString("total_hrs_per_week")
                };
                list.Add(curriculumSubject);
            }
            con.Close();
            return list;
        }

        public async Task<int> AddCurriculumSubjects(CurriculumSubjects subjects)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("insert into curriculum_subjects(uid, curriculum, year_level, semester, code, descriptive_title, total_units, lecture_units, lab_units, " +
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
            int rowsAffected = await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
            return rowsAffected;
        }
    }
}
